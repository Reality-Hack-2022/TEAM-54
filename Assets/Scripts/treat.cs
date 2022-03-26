using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treat : MonoBehaviour
{
    private cat catObject;
    private TreatManager _manager;
    private TreatEffect _effect;

    [SerializeField] private bool triggerActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if (catObject == null)
        {
            GameObject hopefullyCat = GameObject.FindWithTag("DisplacedPlayer");
            if (hopefullyCat != null)
                catObject = hopefullyCat.GetComponent<cat>();
        }
        if (other.CompareTag("Player") && catObject != null)
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerActive)
        {
            catObject.eatTreat();
            _manager.eatTreat(this.transform.parent.gameObject, _effect, catObject);
            Destroy(gameObject);
        }
    }

    public void SetTreatManager(TreatManager manager)
    {
        _manager = manager;
    }

    public void SetTreatEffect(TreatEffect effect)
    {
        _effect = effect;
    }
}
