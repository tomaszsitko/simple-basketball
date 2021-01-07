using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour, IUIController
{
    [SerializeField] private Image lifePrefab = null;
    [SerializeField] private Transform livesParent = null;
    [SerializeField] private Text scoreText = null;

    private List<Image> livesGameObj = new List<Image>();

    private void Start()
    {
        livesGameObj = livesParent.InstatiateChildren(lifePrefab, GameController.MaxLivesCount);
    }

    public void Init()
    {
        livesGameObj.ForEach(x => x.gameObject.SetActive(true));
        UpdateScoreDisplay(0);
    }

    public void UpdateLivesDisplay(int lives)
    {
        livesGameObj.Find(x => x.gameObject.activeSelf).gameObject.SetActive(false);
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = score.ToString();
    }
}