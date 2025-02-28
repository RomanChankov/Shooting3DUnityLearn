using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementAnimator : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator animator;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // полчаем скорость движения объекта, записываем в параметр анимации speed
        animator.SetFloat("speed", navMeshAgent.velocity.magnitude);
    }
}
