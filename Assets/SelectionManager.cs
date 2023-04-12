using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Shader shader;

    public GameObject _selection;

    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponentsInChildren<Renderer>();
            var skinRenderers = _selection.GetComponentsInChildren<SkinnedMeshRenderer>();

            foreach (var selected in skinRenderers)
            {
                selected.material.shader = Shader.Find("Standard");
            }
            
            foreach (var selected in selectionRenderer)
            {
                selected.material.shader = Shader.Find("Standard");
            }
            _selection = null;
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit)) return;
        {
            var selection = hit.transform;
            if (!selection.CompareTag(selectableTag)) return;
            var selectionRenderer = selection.GetComponentsInChildren<Renderer>();
            var skinRenderers = selection.GetComponentsInChildren<SkinnedMeshRenderer>();

            if (selectionRenderer != null)
            {
                foreach (var selected in selectionRenderer)
                {
                    selected.material.shader = shader;
                }
                foreach (var selected in skinRenderers)
                {
                    selected.material.shader = shader;
                }
            }
            _selection = selection.gameObject;
        }
    }
}