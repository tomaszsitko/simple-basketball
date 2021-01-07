namespace Utility.Zenject
{
    public interface IInjectable<TParam>
    {
        void Construct(TParam param);
    }
}