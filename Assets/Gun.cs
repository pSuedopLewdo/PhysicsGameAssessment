using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public SelectionManager sm;
    public Ragdoll rd;
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sm._selection == null) return;
        target = sm._selection;
        if (Input.GetMouseButtonDown(0) && target != null && target.GetComponent<Ragdoll>())
        {
            Debug.Log("Shoot");
            Ragdoll();
        }
    }
    

    public void Ragdoll()
    {
        Rigidbody[] bodies;
        bodies = target.gameObject.GetComponentsInChildren<Rigidbody>();
        rd = target.gameObject.GetComponent<Ragdoll>();
        foreach (var rb in bodies)
        {
            rb.isKinematic = false;
        }
        rd.BeenHit();
        rd.gameObject.GetComponent<BoxCollider>().enabled = false;
        rd = null;
        
    }
}
