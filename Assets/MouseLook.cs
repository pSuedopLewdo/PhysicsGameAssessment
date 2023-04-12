using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    private RotationalAxis _axis = RotationalAxis.MouseX;
    //make these static after testing that they work 
    //so you can put them on an options menu
    public float sensitivity = 10f;
    public bool invertMouseY = false;
    private readonly Vector2 _clamp = new Vector2(-60f, 60f);
    private float _rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _axis = gameObject.CompareTag("Player") ? RotationalAxis.MouseX : RotationalAxis.MouseY;
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        if (_axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
        }
        else
        {
            _rotationY += Input.GetAxis("Mouse Y") * sensitivity;
            _rotationY = Mathf.Clamp(_rotationY, _clamp.x, _clamp.y);
            transform.localEulerAngles = invertMouseY ? new Vector3(_rotationY, 0, 0) : new Vector3(-_rotationY, 0, 0);
        }

    }
}