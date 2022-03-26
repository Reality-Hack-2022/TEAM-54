using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryGoal : MonoBehaviour
{
    public BoxCollider m_Collider;
    public GameObject key;
    public float distanceAbove = 0;
    public float shrink = 0;
    public float size = 0;
    public int requiredBoxes = 0;
    public LayerMask layerMask;
    public GameObject particleSystem;
    public bool drawGizmos;

    private bool spawned = false;

    private int boxCount;
    private Collider[] m_hits;

    void Start()
    {
     
    }

    void OnDrawGizmos()
    {
        if (m_Collider && drawGizmos)
            Gizmos.DrawCube(transform.position + Vector3.up * (distanceAbove + size/2), m_Collider.size + new Vector3(-shrink, size, -shrink));
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapBox(transform.position + Vector3.up * (distanceAbove + size / 2), (m_Collider.size + new Vector3(-shrink, size, -shrink)) / 2, Quaternion.identity, layerMask);
        if (hits.Length >= requiredBoxes && !spawned)
        {
            m_hits = hits;
            StartCoroutine("MyEvent");
        }
    }

    private IEnumerator MyEvent()
    {
        yield return new WaitForSeconds(0.5f); // wait half a second
                                                // do things
        key.SetActive(true);
        key.transform.parent = null;
        particleSystem.SetActive(true);
        spawned = true;
        if (m_hits != null)
        {
            foreach (Collider hit in m_hits)
            {
                Destroy(hit.gameObject);
            }
        }
        m_hits = null;
    }

}
