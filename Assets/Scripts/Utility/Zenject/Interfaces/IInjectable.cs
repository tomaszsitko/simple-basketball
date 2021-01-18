namespace Utility.Zenject
{
    public interface IInjectable<TParam>
    {
        void Construct(TParam param);
    }

    public interface IInjectable<TParam1, TParam2>
    {
        void Construct(TParam1 param1, TParam2 param2);
    }
}