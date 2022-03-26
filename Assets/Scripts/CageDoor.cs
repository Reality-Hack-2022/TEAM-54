using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDoor : MonoBehaviour
{
    public KeyEventManager manager;
    public GameObject door;

    void Start()
    {
        if (manager)
            manager.AddListener(OnKey);
    }

    public void OnKey(Key key, string tag)
    {
        if (tag == gameObject.tag && tag != "Untagged")
        {
            Debug.Log(gameObject.tag);
            // Destroy(key.gameObject);
            door.SetActive(false);
        }
    }
}
