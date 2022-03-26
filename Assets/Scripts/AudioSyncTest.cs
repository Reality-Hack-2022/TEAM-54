using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncTest : MonoBehaviour
{
    public int audioInd;
    public int increment = 0;
    private int prevIncrement = 0;

    private AudioSync _audioSync;

    private void Awake() {
        // Get a reference to the color sync component
        _audioSync = GetComponent<AudioSync>();
    }

    private void Update() {
        // If the color has changed (via the inspector), call SetColor on the color sync component.
        if (increment != prevIncrement) {
            _audioSync.PlayClip(audioInd, transform.position);
            prevIncrement = increment;
        }
    }
}
