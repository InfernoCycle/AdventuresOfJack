using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Firetrap Timers")]
    [SerializeField]private float activationDelay;
    [SerializeField]private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private float cooldownTimer;

    private bool triggered; //
    private bool active;

    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        cooldownTimer = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();
            if (!triggered)
            {
                //trigger the firetrap
                StartCoroutine(ActivateFiretrap());
            }
            if (active)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHealth = null;
        }
    }
    //Use IEnumerator when dealing with delay based code now
    private IEnumerator ActivateFiretrap()
    {
        cooldownTimer = 0;
        //turn the sprite red to notify the player and trigger the trap
        triggered = true;
        //spriteRend.color = Color.red; // turn sprite red

        //Wait for delay, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //turn sprite back to normal
        active = true;
        anim.SetBool("activated", true);

        //wait until x seconds, deactivate trap and reset all variables and animator
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void activate()
    {
        StartCoroutine(ActivateFiretrap());
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(cooldownTimer >= activationDelay)
        {
            activate();
        }
        if (playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
