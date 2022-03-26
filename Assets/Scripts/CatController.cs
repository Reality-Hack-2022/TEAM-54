using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class CatController : MonoBehaviour
{
    private RealtimeTransform realtimeTransform;
    private RealtimeView realtimeView;
    public GameObject catModel;

    // Start is called before the first frame update
    void Start()
    {
        realtimeTransform = catModel.GetComponent<RealtimeTransform>();
        realtimeView = catModel.GetComponent<RealtimeView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(realtimeView.ownerID == -1 && realtimeTransform.ownerID == -1)
        {
            Debug.Log("requested");
            Vector3 prevPosition = catModel.transform.position;
            realtimeView.RequestOwnership();
            realtimeTransform.RequestOwnership();
            catModel.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
            catModel.transform.position = prevPosition;
        }
    }

    public void SetCatModel(GameObject model)
    {
        catModel = model;
    }
}
