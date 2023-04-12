using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public Transform barrel;

    public GameObject selected;
    public ClickToDrag drag;
    public LineRenderer LineRenderer;
    public Material shootMat, dragMat;
    public bool isDragging;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            //creates ray from mouse coordinates "Locked at centre"
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //get new world pos of barrel
            var position = barrel.transform.position;
            LineRenderer.enabled = true;

            if (drag != null)
            {
                var dragCentre = CentrePoint(drag.gameObject);
                Draw(position, dragCentre);
                return;
            }
            
            //if it doesnt hit anything
            if (!Physics.Raycast(ray, out var hit))
            {
                var mousePos = ray.GetPoint(100);

                Debug.Log(mousePos);
                //if it doesnt hit anything
                Draw(position, mousePos);
                Debug.Log("No Hit!");
                return;
            }

            selected = hit.transform.gameObject;
            
            if (hit.transform.gameObject.GetComponentInParent<ClickToDrag>() && drag == null)
            {
                drag = hit.transform.gameObject.GetComponentInParent<ClickToDrag>();
            }
            
            //IF IT DOES HIT && Selectable is not dragging
            if (selected.CompareTag("Selectable") && drag == null)
            {
                var dragCentre = CentrePoint(selected.gameObject);
                Draw(position, dragCentre);
            }
            else
            {
                Draw(position, hit.point);
            }
        }
        else
        {
            LineRenderer.enabled = false;
            selected = null;
            drag = null;
        }
    }

    public void Draw(Vector3 start, Vector3 end)
    {
        // set the color of the line
        LineRenderer.material = drag == null ? shootMat : dragMat;

        // set the position
        LineRenderer.SetPosition(0, start);
        LineRenderer.SetPosition(1, end);
    }

    public Vector3 CentrePoint(GameObject obj)
    {
        var point = new Vector3();
        var parent = obj.GetComponentInParent<Ragdoll>().gameObject;
        var children = parent.GetComponentsInChildren<Transform>();

        
        foreach (var child in children)
        {
            point += child.position;
        }
        point /= children.Length;

        return point;
    }
}
