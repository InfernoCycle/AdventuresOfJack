using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;

    [Header("Magic")]
    [SerializeField] private float magicGained;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    public bool healPlayer;

    private bool InvulnerableCalled;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        InvulnerableCalled = false;
    }

    public void Invulnerable()
    {
        InvulnerableCalled = true;
        StartCoroutine(Invulnerability());
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            //iframes
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                if (tag.Equals("Enemy") || tag.Equals("FinalEnemy"))
                {
                    gameObject.SetActive(false);
                   GameObject temp =  GameObject.FindGameObjectWithTag("Player");
                    temp.GetComponent<PlayerMovement>().HealPlayer(1.0f);
                    temp.GetComponent<PlayerMovement>().RegainMana(1.5f);
                }

                if (tag.Equals("FinalEnemy"))
                {
                    GetComponent<PauseAndGoBack>().showDeathScreen();
                    gameObject.SetActive(false);
                }

                //player dead

                if (tag.Equals("Player"))
                {
                    GetComponent<PauseAndGoBack>().showDeathScreen();
                    gameObject.SetActive(false);
                }
                anim.SetTrigger("die");

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(7, 8, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (InvulnerableCalled)
            {
                spriteRend.color = Color.white;
            }
            else
            {
                spriteRend.color = new Color(1f, 0f, 0f, 0.5f);
            }
            InvulnerableCalled = false;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        //invulnerable
        Physics2D.IgnoreLayerCollision(7, 8, false);
        invulnerable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        healPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
