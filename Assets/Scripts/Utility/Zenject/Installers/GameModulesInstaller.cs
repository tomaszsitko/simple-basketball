using UnityEngine;

namespace Utility.Zenject
{
    [CreateAssetMenu(fileName = "GameModules", menuName = "Installers/GameModulesInstaller")]
    public class GameModulesInstaller : BaseScriptableObjectInstaller<GameModulesInstaller>
    {
        public override void InstallBindings()
        {
            InstallGame();
            InstallCamera();
            InstallUI();
        }

        private void InstallGame()
        {
            Container.Bind<IGameController>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallCamera()
        {
            Container.Bind<ICameraController>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallUI()
        {
            Container.Bind<IUIController>().FromComponentInHierarchy().AsSingle();
        }
    }
}