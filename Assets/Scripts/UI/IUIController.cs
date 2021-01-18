namespace SimpleBasketball.UI
{
    public interface IUIController
    {
        void Init();
        void DecreaseLivesDisplay();
        void UpdateScoreDisplay(int score);
    }
}