using SimpleBasketball.Game;
using SimpleBasketball.Helpers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleBasketball.UI
{
    public class UIController : MonoBehaviour, IUIController
    {
        [SerializeField] protected Image lifePrefab = null;
        [SerializeField] protected Transform livesParent = null;
        [SerializeField] protected Text scoreText = null;

        protected List<Image> livesGameObj = new List<Image>();

        protected void Start()
        {
            livesGameObj = livesParent.InstatiateChildren(lifePrefab, GameController.MaxLivesCount);
        }

        public void Init()
        {
            livesGameObj.ForEach(x => x.gameObject.SetActive(true));
            UpdateScoreDisplay(0);
        }

        public void UpdateScoreDisplay(int score)
        {
            scoreText.text = score.ToString();
        }

        public void DecreaseLivesDisplay()
        {
            livesGameObj.Find(x => x.gameObject.activeSelf).gameObject.SetActive(false);
        }
    }
}