using NUnit.Framework;
using Zenject;

namespace SimpleBasketball.Tests
{
    public class TestFixture
    {
        private DiContainer container;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            container = new DiContainer(StaticContext.Container);

            container.Bind<ICameraController>().FromSubstitute();
            container.Bind<IGameController>().FromSubstitute();
            container.Bind<IUIController>().FromSubstitute();
            UnityEngine.Debug.Log("ONE TIME SETUP");
        }

        [SetUp]
        public virtual void Setup()
        {
            container.Inject(this);
            UnityEngine.Debug.Log("start");
        }
    }
}