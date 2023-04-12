using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public bool beenHit;

    public Rigidbody[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.isKinematic = true;
        }
    }


    public void BeenHit()
    {
        beenHit = true;
        foreach (var rb in rbs)
        {
            rb.AddForce(Vector3.back, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
}
