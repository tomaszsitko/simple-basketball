using UnityEngine;

public class GameController : MonoBehaviour
{
    public const int MaxLivesCount = 3;

    public static GameController Instance;

    [SerializeField] private Ball ball = null;
    private UIController uiController;

    private int lives;
    private int score;

    private void Start()
    {
        Instance = this;
        uiController = GetComponent<UIController>();

        StartNewGame();
    }

    public void StartNewGame()
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