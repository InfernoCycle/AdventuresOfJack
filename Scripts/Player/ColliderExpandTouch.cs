using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExpandTouch : MonoBehaviour
{

    private Health enemyHealth;
    [SerializeField] private float ExtendRange;

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxcollider;

    [Header("Player Parameters")]
    [SerializeField] private LayerMask playerLayer;


    // Update is called once per frame
    void Update()
    {
        
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(boxcollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxcollider.bounds.size.x * range, boxcollider.bounds.size.y, boxcollider.bounds.size.z));
    }

    private void DamageEnemy()
    {
        //if player still in range stop
        if (EnemyInSight())
        {
            //damage player health
            enemyHealth.TakeDamage(damage);
        }
    }


}
