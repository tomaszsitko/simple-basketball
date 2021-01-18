using SimpleBasketball.UI;
using UnityEngine;
using Utility.Zenject;
using Zenject;

namespace SimpleBasketball.Game
{
    public class GameController : MonoBehaviour, IGameController, IInjectable<IUIController>
    {
        public const int MaxLivesCount = 3;

        [SerializeField] protected Ball ball = null;

        protected IUIController uiController;

        protected int lives;
        protected int score;

        [Inject]
        public void Construct(IUIController uiController)
        {
            this.uiController = uiController;
        }

        protected void Start()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            score = 0;
            lives = MaxLivesCount;

            uiController.Init();
            ball.ResetPosition();
        }

        public void OnHitShoot()
        {
            score++;
            ball.ResetPosition();
            uiController.UpdateScoreDisplay(score);
        }

        public void OnMissedShoot()
        {
            lives--;
            uiController.DecreaseLivesDisplay();

            if (lives <= 0)
                StartNewGame();
            else
                ball.ResetPosition();
        }
    }
}