using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatManager : MonoBehaviour
{
    private List<GameObject> treatSpawnLocations = new List<GameObject>();
    public GameObject[] particlePrefabs;
    public GameObject treatPrefab;

    public float respawnTimer; // how long before a new treat can be spawned
    private float nextTime = 0.0f;
    private int instantiated = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] initialLocations = GameObject.FindGameObjectsWithTag("TreatPlaceholder");

        foreach (GameObject spawnLocation in initialLocations)
        {
            SpawnTreat(spawnLocation.transform);
            instantiated += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (treatSpawnLocations.Count > 0 && Time.time > nextTime)
        {
            int index = Random.Range(0, treatSpawnLocations.Count);
            SpawnTreat(treatSpawnLocations[index].transform);
            treatSpawnLocations.Remove(treatSpawnLocations[index]);
        }
    }

    private void SpawnTreat(Transform where)
    {
        int index = Random.Range(0, particlePrefabs.Length);
        GameObject particleEffect = Instantiate(particlePrefabs[index], where.position, where.rotation);
        GameObject treatObject = Instantiate(treatPrefab, where.position, where.rotation);
        particleEffect.transform.parent = treatObject.transform;
        treatObject.transform.parent = where;
        treat treatComponent = treatObject.GetComponent<treat>();
        TreatEffect effect = particleEffect.GetComponent<TreatEffect>();
        treatComponent.SetTreatManager(this);
        treatComponent.SetTreatEffect(effect);
    }

    public void eatTreat(GameObject placeholder, TreatEffect effect, cat catObject)
    {
        treatSpawnLocations.Add(placeholder);
        nextTime = Time.time + respawnTimer;

        switch(effect.effect)
        {
            case TreatEffect.Effects.JUMP_UP:
                catObject.maxJumpHeight += 1.0f;
                break;
            case TreatEffect.Effects.SPEED_UP:
                catObject.playerSpeed += 0.5f;
                break;
        }
    }
}
