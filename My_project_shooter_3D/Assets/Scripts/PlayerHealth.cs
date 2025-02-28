using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    private Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Текущее здоровье: {currentHealth}");
        if(currentHealth <= 0) {
            Die();}
        }
        void Die() {
        animator.SetTrigger("dead");
    }
}
