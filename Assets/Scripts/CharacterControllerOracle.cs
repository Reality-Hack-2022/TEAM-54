using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class CharacterControllerOracle : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        realtimeTransform = GetComponent<RealtimeTransform>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.enabled = realtimeTransform.isOwnedLocallySelf;
    }
}
