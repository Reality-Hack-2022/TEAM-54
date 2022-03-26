using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class DebugScript : MonoBehaviour
{
    private Vector3 origPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Debug1()
    {
        Debug.Log(transform.position);
    }

    public void HackySack()
    {
        origPosition = transform.position;
        Invoke("ResetPos", 1.0f);
    }

    void ResetPos()
    {
        GetComponent<RealtimeView>().RequestOwnership();
        GetComponent<RealtimeTransform>().RequestOwnership();
        transform.position = origPosition;
        GetComponent<RealtimeView>().ClearOwnership();
        GetComponent<RealtimeTransform>().ClearOwnership();
    }
}
