using NUnit.Framework;
using Zenject;

namespace SimpleBasketball.Tests
{
    public abstract class SetupTestFixture
    {
        protected static DiContainer Container;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Container = new DiContainer(StaticContext.Container);

            BindMocks();
        }

        public abstract void BindMocks();

        public static void Inject(params object[] obj)
        {
            foreach (object o in obj)
                Container.Inject(o);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            StaticContext.Clear();
        }
    }
}