using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class CatSpawning : MonoBehaviour
{

    public GameObject CatPlayer;
    public Realtime realtime;
    public Transform spawnLocation;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned && realtime.connected)
        {
            spawned = true;
            GameObject catPlayer = Instantiate(CatPlayer, spawnLocation.position, spawnLocation.rotation);
            //GameObject pointLight = Instantiate(catPointLight, spawnLocation.position, spawnLocation.rotation);
            //pointLight.parent = catPlayer;
            GameObject catModel = Realtime.Instantiate("CatModel", spawnLocation.position, spawnLocation.rotation);
            catPlayer.GetComponentInChildren<ParallelMovement>().SetOther(catModel.transform.GetChild(0));
            catPlayer.GetComponent<CatController>().SetCatModel(catModel);
            catPlayer.GetComponent<cat>().SetCatModel(catModel);
        }
    }
}
