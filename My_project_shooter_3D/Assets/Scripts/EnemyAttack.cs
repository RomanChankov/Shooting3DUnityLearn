using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRadius = 0.4f;
    public int damage = 1;
    public float attackCooldown = 2.0f;
    private float lastAttackTime;
    private Animator animator;
    private Transform player;
    private PlayerHealth playerHealth;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= attackRadius && Time.time >= lastAttackTime + attackCooldown) {
            AttackPlayer();
        }
    }
    
    void AttackPlayer() {
        animator.SetTrigger("attack");
        lastAttackTime = Time.time;
    }
    public void DealDamage() {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= attackRadius) {
            playerHealth.TakeDamage(damage);
        }
    }

}
