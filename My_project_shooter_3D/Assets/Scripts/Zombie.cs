using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
        Player player;
    CapsuleCollider capsuleCollider;
    Animator animator;
    MovementAnimator movementAnimator;
    bool dead;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
        navMeshAgent.updateRotation = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        movementAnimator = GetComponent<MovementAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dead) return;
        navMeshAgent.SetDestination(player.transform.position);
        transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
        navMeshAgent.stoppingDistance = 0.3F;
    }
        public void Kill(){
            if(!dead){
                dead = true;
                Destroy(capsuleCollider);
                Destroy(movementAnimator);
                Destroy(navMeshAgent);
                GetComponentInChildren<ParticleSystem>().Play();
                animator.SetTrigger("dead");
                Destroy(gameObject,6); //удалить объект зомби через 3 сек

            }
        }
}
