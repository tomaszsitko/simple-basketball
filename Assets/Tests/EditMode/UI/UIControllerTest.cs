using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using SimpleBasketball.UI;

namespace SimpleBasketball.Tests
{
    public class UIControllerTest : UIController
    {
        [OneTimeSetUp]
        public void Setup()
        {
            lifePrefab = new GameObject().AddComponent<Image>();
            livesParent = new GameObject().transform;
            scoreText = new GameObject().AddComponent<Text>();

            Start();
        }

        [Test]
        public void InitTest()
        {
            livesGameObj.ForEach(x => x.gameObject.SetActive(false));

            Init();

            Assert.True(livesGameObj.TrueForAll(x => x.gameObject.activeSelf));
            Assert.AreEqual("0", scoreText.text);
        }

        [Test]
        public void UpdateLivesDisplayTest()
        {
            livesGameObj.ForEach(x => x.gameObject.SetActive(true));

            DecreaseLivesDisplay();

            Assert.IsFalse(livesGameObj[0].gameObject.activeSelf);
            Assert.IsTrue(livesGameObj[1].gameObject.activeSelf);
            Assert.IsTrue(livesGameObj[1].gameObject.activeSelf);

        }
    }
}