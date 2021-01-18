using NUnit.Framework;
using SimpleBasketball.Camera;
using SimpleBasketball.Game;
using SimpleBasketball.UI;
using Zenject;

namespace SimpleBasketball.Tests
{
    [SetUpFixture]
    public class PlayModeSetupFixture : SetupTestFixture
    {
        public override void BindMocks()
        {
            Container.Bind<IUIController>().FromSubstitute();
            Container.Bind<ICameraController>().FromSubstitute();
            Container.Bind<IGameController>().FromSubstitute();
        }
    }
}