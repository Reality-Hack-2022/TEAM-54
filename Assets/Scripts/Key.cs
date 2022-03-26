using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public bool useGravity;
    public KeyEventManager eventManager;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag != "Untagged")
        {
            eventManager.uKeyEvent.key = this;
            eventManager.hit(other.gameObject.tag);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grab(Transform parent)
    {
        transform.parent = parent;
    }

    public void Release()
    {
        transform.parent = null;
    }
}
