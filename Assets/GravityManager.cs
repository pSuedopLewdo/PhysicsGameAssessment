using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityManager : MonoBehaviour
{
    public GameObject player;
    public CharacterController cc;
    public Vector3 moveDir;
    public bool flipped;
    public Image image;
    
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        cc = player.GetComponent<CharacterController>();
        flipped = false;
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !flipped)
        {
            flipped = true;
            Physics.gravity = new Vector3(0, 9.81f, 0);
            image.color = Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.G) && flipped)
        {
            flipped = false;
            Physics.gravity = new Vector3(0, -9.81f, 0);
            image.color = Color.blue;
        }

        //cc.Move(moveDir);
    }
}
