using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed = false;
    public GameObject[] unlocks;

    private void Start()
    {
        isPressed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        throw new NotImplementedException();
    }
    
}
