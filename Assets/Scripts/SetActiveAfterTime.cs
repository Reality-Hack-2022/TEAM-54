using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveAfterTime : MonoBehaviour
{
    public float timeUntilActive;
    public GameObject gameObj;
    private float nextTime;
    private bool timing = false;

    // Update is called once per frame
    void Update()
    {
        if (!timing)
        {
            if (!gameObj.activeSelf)
            {
                timing = true;
                Reset();
            }
        }
        if (Time.time > nextTime && timing)
        {
            gameObj.SetActive(true);
            timing = false;
        }
    }

    void Reset()
    {
        nextTime = Time.time + timeUntilActive;
    }
}
