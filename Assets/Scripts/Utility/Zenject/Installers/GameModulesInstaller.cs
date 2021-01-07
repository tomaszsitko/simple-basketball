using UnityEngine;

namespace Utility.Zenject
{
    [CreateAssetMenu(fileName = "GameModules", menuName = "Installers/GameModulesInstaller")]
    public class GameModulesInstaller : BaseScriptableObjectInstaller<GameModulesInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}