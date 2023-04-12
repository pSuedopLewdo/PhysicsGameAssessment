using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed = false;
    public GameObject[] unlocks;
    public GameObject activeButton, pressedButton;

    private void Awake()
    {
        activeButton = GetComponentInChildren<ActiveButton>().gameObject;
        pressedButton = GetComponentInChildren<PressedButton>().gameObject;
    }

    private void Start()
    {
        isPressed = false;
        activeButton.SetActive(true);
        pressedButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        activeButton.SetActive(false);
        pressedButton.SetActive(true);
        Unlock();
        isPressed = true;
        Debug.Log(other);
    }

    private void Unlock()
    {
        foreach (var obj in unlocks)
        {
            obj.SetActive(false);
        }
    }
    
}
