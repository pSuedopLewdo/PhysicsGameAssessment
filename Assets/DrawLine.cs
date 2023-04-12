using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform barrel;

    public GameObject selected;
    public ClickToDrag drag;
    public LineRenderer LineRenderer;
    public bool isDragging;

    // Update is called once per frame
    void Update()
    {
        if (drag == null || drag._dragObject == null)
        {
            isDragging = false;
        }
        else
        {
            isDragging = true;
        }
        if (Input.GetMouseButton(0))
        {
            //enables the line renderer
            LineRenderer.enabled = true;
            //creates ray from mouse coordinates "Locked at centre"
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if it doesnt hit anything
            if (!Physics.Raycast(ray, out var hit))
            {
                //if it doesnt hit anything
                Draw(barrel.transform.position, new Vector3(Vector3.forward.x, Vector3.forward.y, 100));
                return;
            }

            //hit object
            selected = hit.transform.gameObject;
            //hit dragObject
            if (selected.transform.gameObject.GetComponentInParent<ClickToDrag>())
            {
                drag = selected.transform.gameObject.GetComponentInParent<ClickToDrag>();
            }
            var position = barrel.transform.position;
            
            //get centre point of hit object
            Draw(position, selected.transform.position);
        }
        else
        {
            LineRenderer.enabled = false;
            selected = null;
        }
    }

    public void Draw(Vector3 start, Vector3 end)
    {
        // set the color of the line

        LineRenderer.startColor = Color.red;
        LineRenderer.endColor = Color.blue;

        // set width of the renderer
        LineRenderer.startWidth = 0.1f;
        LineRenderer.endWidth = 0.1f;

        // set the position
        LineRenderer.SetPosition(0, start);
        LineRenderer.SetPosition(1, end);
    }
}
