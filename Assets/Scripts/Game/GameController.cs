using UnityEngine;
using Utility.Zenject;
using Zenject;

public class GameController : MonoBehaviour, IGameController, IInjectable<IUIController>
{
    public const int MaxLivesCount = 3;

    [SerializeField] private Ball ball = null;

    private IUIController uiController;

    private int lives;
    private int score;

    [Inject]
    public void Construct(IUIController uiController)
    {
        this.uiController = uiController;
    }

    private void Start()
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
        uiController.UpdateLivesDisplay(lives);

        if (lives <= 0)
            StartNewGame();
        else
            ball.ResetPosition();
    }
}