using Zenject;

namespace Utility.Zenject
{
    public abstract class BaseScriptableObjectInstaller<T> : ScriptableObjectInstaller<T> where T : BaseScriptableObjectInstaller<T>
    {
        public static void InstallFromResourceForTestMode(string resourcePath, DiContainer container)
        {
            var installer = ScriptableObjectInstallerUtil.CreateInstaller<T>(resourcePath, container);
            container.Inject(installer);
        }
    }
}