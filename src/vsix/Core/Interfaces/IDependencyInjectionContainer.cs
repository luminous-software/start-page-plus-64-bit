namespace StartPagePlus.Core.Interfaces
{
    public interface IDependencyInjectionContainer
    {
        void AddSingleton<TService, TImplementation>();

        void AddSingleton<TService>();

        T GetInstance<T>();
    }
}