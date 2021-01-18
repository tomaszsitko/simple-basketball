using SimpleBasketball.Camera;
using UnityEngine;
using Utility.Zenject;
using Zenject;

namespace SimpleBasketball.Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour, IInjectable<IGameController, ICameraController>
    {
        private const string BasketColliderTag = "Basket";
        private const string GroundColliderTag = "Ground";

        private IGameController gameController;
        private ICameraController cameraController;

        protected Rigidbody2D rb;
        protected Vector3 startPosition;

        protected bool interactable;

        [Inject]
        public void Construct(IGameController gameController, ICameraController cameraController)
        {
            this.gameController = gameController;
            this.cameraController = cameraController;
        }

        private void Awake()
        {
            startPosition = transform.position;

            rb = GetComponent<Rigidbody2D>();
        }

        public void ResetPosition()
        {
            interactable = true;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            transform.position = startPosition;
        }

        private void OnMouseDown()
        {
            if (interactable)
                cameraController.StartDrawShootLine(transform.position);
        }

        private void OnMouseUp()
        {
            if (interactable)
            {
                interactable = false;
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
            if (collision.gameObject.tag == GroundColliderTag)
                gameController.OnMissedShoot();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == BasketColliderTag)
                gameController.OnHitShoot();
        }
    }
}