using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageHandle : MonoBehaviour
{
    public Transform target;
    Rigidbody rigidbody;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.MovePosition(speed * target.transform.position);
    }
}
