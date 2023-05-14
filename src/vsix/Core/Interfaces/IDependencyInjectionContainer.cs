namespace StartPagePlus.Core.Interfaces
{
    public interface IDependencyInjectionContainer
    {
        void AddSingleton<TService>();

        void AddSingleton<TService>(TService implementation);

        void AddSingleton<TService, TImplementation>();

        T GetInstance<T>();
    }
}