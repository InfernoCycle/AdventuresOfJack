using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(KeybindSettings.firer == null)
        {
            KeybindSettings.firer = "Q";
        }
        if(KeybindSettings.sworder == null)
        {
            KeybindSettings.sworder = "Z";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //attack on click
        if (Input.GetKey(KeybindSettings.firer.ToLower()) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        if(Input.GetKey(KeybindSettings.sworder.ToLower()) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack2();
        }
        cooldownTimer += Time.deltaTime;
    }

    public void Attack()
    {
        if(GetComponent<Magic>().currentMagic != 0)
        {
            GetComponent<Magic>().LoseMana(0.5f);
            anim.SetTrigger("Attack1");
            cooldownTimer = 0;

            fireballs[FindFireball()].transform.position = firePoint.position;
            fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        }
    }

    private void Attack2()
    {
        anim.SetTrigger("SwordAttack");
        cooldownTimer = 0;
    }

    private int FindFireball()
    {
        for (int i=0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
