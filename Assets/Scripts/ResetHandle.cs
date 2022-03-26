using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHandle : MonoBehaviour
{
    public Transform handle;
    public float finalDist = 0.5f;

    public void GrabEnd()
    {
        /*Vector3 directionToHandle = transform.position - handle.position;
        float angle = Vector3.Angle(handle.forward, directionToHandle);
        int direction = Mathf.Abs(angle) < 90 ? 1 : -1;
        transform.localPosition = new Vector3(0, 0, direction*finalDist);
        Debug.Log(new Vector3(0, 0, direction*finalDist));*/
        transform.position = handle.position;
        transform.rotation = handle.rotation;
        transform.localScale = new Vector3(1,1,1);
        Rigidbody rbHandle = handle.GetComponent<Rigidbody>();
        rbHandle.velocity = Vector3.zero;
        rbHandle.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        // if(Vector3.Distance(handle.position, transform.position) > 0.4f)
        // {

        // }
    }
}
