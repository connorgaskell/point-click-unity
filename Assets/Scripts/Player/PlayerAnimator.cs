using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour {

    NavMeshAgent nav;
    Animator animator;

    void Start() {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        float speedPercent = nav.velocity.magnitude / nav.speed;
        animator.SetFloat("speedPercent", speedPercent, 0.1f, Time.deltaTime);
    }
}
