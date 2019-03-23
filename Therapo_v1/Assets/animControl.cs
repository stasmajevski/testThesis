using UnityEngine;

public class animControl : MonoBehaviour
{
    public Animator animator;

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        animator.Play("idle");

        if (Input.GetKeyDown(KeyCode.Q)) animator.Play("attack");

        if (Input.GetKeyDown(KeyCode.Mouse0)) animator.Play("walk");

        if (Input.GetKeyDown(KeyCode.Mouse1)) animator.Play("die");
    }
}