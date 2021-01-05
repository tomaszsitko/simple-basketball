using UnityEngine;

public class Ball : MonoBehaviour
{
    private const string BasketColliderTag = "Basket";

    protected bool Interactable { get; set; }

    private Vector3 startPosition;
    private Rigidbody2D rb;
    private CameraController cameraController;

    private void Awake()
    {
        startPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    public void ResetPosition()
    {
        Interactable = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        transform.position = startPosition;
    }

    private void OnMouseDown()
    {
        if (Interactable)
            cameraController.StartDrawShootLine();
    }

    private void OnMouseUp()
    {
        if (Interactable)
        {
            Interactable = false;
            cameraController.StopShootDrawLine();
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector3 diff = transform.position - cameraController.ToWorldCoordinates(Input.mousePosition);
        rb.isKinematic = false;
        rb.AddForce(diff);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != BasketColliderTag)
            GameController.Instance.OnMissedShoot();
    }
}