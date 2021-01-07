using UnityEngine;

[RequireComponent(typeof(UnityEngine.Camera))]
public class CameraController : MonoBehaviour, ICameraController
{
    private static readonly Color LineColor = new Color(0f, 0f, 0f, 1f);

    [SerializeField] private Material lineMaterial = null;
    [SerializeField] private Transform ballTransform = null;

    private Camera cam;

    private bool draw;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void StartDrawShootLine()
    {
        draw = true;
    }

    public void StopShootDrawLine()
    {
        draw = false;
    }

    public Vector3 ToWorldCoordinates(Vector3 position)
    {
        Vector3 posToConvert = new Vector3(position.x, position.y, cam.nearClipPlane);
        return cam.ScreenToWorldPoint(posToConvert);
    }

    private void OnPostRender()
    {
        if (draw)
            DrawLine();
    }

    private void DrawLine()
    {
        GL.Begin(GL.LINES);
        lineMaterial.SetPass(0);
        GL.Color(LineColor);
        GL.Vertex(ballTransform.position);
        GL.Vertex(GetEndPosition());
        GL.End();
    }

    private Vector3 GetEndPosition()
    {
        Vector3 mousePosition = ToWorldCoordinates(Input.mousePosition);
        return ballTransform.position - mousePosition;
    }
}