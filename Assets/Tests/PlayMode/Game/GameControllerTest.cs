using NSubstitute;
using NUnit.Framework;
using SimpleBasketball.Game;
using UnityEngine;

namespace SimpleBasketball.Tests
{
    public class GameControllerTest : GameController
    {
        [OneTimeSetUp]
        public void Setup()
        {
            ball = new GameObject().AddComponent<Ball>();
            SetupTestFixture.Inject(this, ball);
        }

        [Test]
        public void StartTest()
        {
            Start();

            Assert.Zero(score);
            Assert.AreEqual(MaxLivesCount, lives);

            uiController.Received().Init();
        }

        [Test]
        public void OnHitShootTest()
        {
            score = 0;

            OnHitShoot();

            Assert.AreEqual(1, score);
            uiController.Received().UpdateScoreDisplay(1);
        }

        [Test]
        public void OnMissedShootTest()
        {
            lives = 2;

            OnMissedShoot();

            Assert.AreEqual(1, lives);
            uiController.DidNotReceive().Init();
        }

        [Test]
        public void OnMissedShootOnLastLiveTest()
        {
            lives = 1;

            OnMissedShoot();

            Assert.AreEqual(MaxLivesCount, lives);
            uiController.Received().Init();
        }

        [TearDown]
        public void Cleanup()
        {
            uiController.ClearReceivedCalls();
        }
    }
}