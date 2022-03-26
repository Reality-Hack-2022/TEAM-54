using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private Vector3 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        prevPosition = transform.position;
        animator.SetFloat("speed", 5f);
    }
}
