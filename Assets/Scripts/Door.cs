using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int keysRequired = 3;
    public int keysGathered = 0;
    public KeyEventManager manager;
    public ControllerSwitcher switcher;

    void Start()
    {
        if (manager)
            manager.AddListener(OnKey);
    }

    public void OnKey(Key key, string tag)
    {
        if (tag == gameObject.tag && tag != "Untagged")
        {
            key.gameObject.tag = "Untagged";
            Debug.Log(gameObject.tag);
            Destroy(key.gameObject, 0.5f);
            keysGathered += 1;
        }

    }

    void Update() {
        if (keysGathered == keysRequired)
        {
            StartCoroutine("MyEvent");
        }
    }

    private IEnumerator MyEvent()
    {
        yield return new WaitForSeconds(0.5f); // wait half a second
                                               // do things
        if (switcher.XRActive)
        {
            SceneManager.LoadScene("YouLoseVR");
        }
        else
        {
            SceneManager.LoadScene("YouWin");
        }
    }

}
