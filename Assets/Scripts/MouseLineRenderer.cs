using UnityEngine;

public class MouseLineRenderer : MonoBehaviour
{
    public Transform player;


    private LineRenderer _lineRenderer;
    public void Start()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _initialPosition = player.position;
        _lineRenderer.SetVertexCount(1);
        _lineRenderer.SetWidth(0.1f, 0.1f);
        _lineRenderer.enabled = true;
    }

    private Vector3 _initialPosition;
    private Vector3 _currentPosition;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initialPosition = player.position;
            _lineRenderer.SetPosition(0, _initialPosition);
            _lineRenderer.SetVertexCount(1);
            _lineRenderer.enabled = true;
        }

        _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
        _lineRenderer.SetVertexCount(2);
        _lineRenderer.SetPosition(1, _currentPosition);
    }

    private Vector3? GetCurrentMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);

        }

        return null;
    }

}