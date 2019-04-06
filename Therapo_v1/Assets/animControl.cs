using System.Collections;
using UnityEngine;

public class animControl : MonoBehaviour
{
    private Animator _animator;
    public GameObject TransparentWall;
    public GameObject TransparentWallSecond;

    // Use this for initialization
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _animator.Play("idle",0);

         if (!TransparentWall.activeSelf) StartCoroutine(StartWalking());
         if (!TransparentWall.activeSelf && !TransparentWallSecond.activeSelf) StartCoroutine(StartJumping());
        if (Input.GetKeyDown(KeyCode.Mouse0)) _animator.Play("walk");
    }

    private IEnumerator StartWalking()
    {
        _animator.Play("walk", 1);
        yield return new WaitForSeconds(5);
        _animator.SetLayerWeight(1, 0);
    }

    private IEnumerator StartJumping()
    {
        _animator.Play("jump", 2);
        yield return new WaitForSeconds(3);
        _animator.SetLayerWeight(2, 0);
    }
}