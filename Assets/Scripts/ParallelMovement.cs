using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallelMovement : MonoBehaviour
{
    public Transform other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = other.position;
        Vector3 eulerRotationLocal = transform.eulerAngles;
        Vector3 eulerRotationOther = other.transform.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotationLocal.x, eulerRotationOther.y, eulerRotationOther.z);
    }

    public void SetOther(Transform otherObj) {
        other = otherObj;
    }
}
