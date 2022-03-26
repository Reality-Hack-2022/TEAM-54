using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyEventManager : MonoBehaviour
{
    public class KeyUnityEvent : UnityEvent<Key, string>
    {
        public Key key;
    }

    public KeyUnityEvent uKeyEvent = new KeyUnityEvent();


    // Update is called once per frame
    public void AddListener(UnityAction<Key, string> action)
    {
        uKeyEvent.AddListener(action);
    }

    public void hit(string tag)
    {
        uKeyEvent.Invoke(uKeyEvent.key, tag);
    }
}
