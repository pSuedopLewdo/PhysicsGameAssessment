using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Assigns the CharacterController to the object this script is on
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    private CharacterController _charC;
    [SerializeField] private Vector3 _moveDir = Vector3.zero;
    [Space(25), Header("Speeds")]
    public float speed = 5f;
    public float gravity = 20f, jumpSpeed = 8f;

    void Start()
    {
        _charC = this.GetComponent<CharacterController>();
    }
    void Update()
    {

        if (_charC.isGrounded)
        {
            //_moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* speed);
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= speed;

            if (Input.GetButton("Jump"))
            {
                _moveDir.y = jumpSpeed;
            }
        }
        _moveDir.y -= gravity * Time.deltaTime;
        _charC.Move(_moveDir * Time.deltaTime);

    }
}


