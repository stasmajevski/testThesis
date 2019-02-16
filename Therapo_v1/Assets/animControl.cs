using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControl : MonoBehaviour {
    public Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.Play("attack");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("walk");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.Play("die");
        }
    }
}
