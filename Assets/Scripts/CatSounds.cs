using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour
{
    public int catSoundMinInd = 0;
    public int catSoundMaxInd = 6;
    private AudioSync audioSync;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            int randomClipInd = Random.Range(catSoundMinInd, catSoundMaxInd);
            audioSync.PlayClip(randomClipInd, transform.position);
        }   
    }

    public void SetAudioSync(AudioSync aSync)
    {
        audioSync = aSync;
    }
}
