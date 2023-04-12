using UnityEngine;

public class ClickToDrag : MonoBehaviour
{
    public float forceAmount = 500;

    public Rigidbody _dragObject;

    private Vector3 _originalPosition;
    private float _selectionDistance;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out var hit, Mathf.Infinity))
            {
                _selectionDistance = Vector3.Distance(ray.origin, hit.point);

                _dragObject = hit.rigidbody;
                _originalPosition = hit.collider.transform.position;
            }
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _dragObject = null;
        }

    }

    private void FixedUpdate()
    {
        if (!_dragObject) return;

        var mousePositionOffset = _camera.ScreenToWorldPoint(new Vector3
        (Input.mousePosition.x, Input.mousePosition.y, _selectionDistance)) - _originalPosition;

        _dragObject.velocity = (_originalPosition + mousePositionOffset - _dragObject.transform.position) * (forceAmount * Time.deltaTime);
    }
}