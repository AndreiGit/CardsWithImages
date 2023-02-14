using System;

namespace EntryPoint.ServiceLocator
{
    public interface IServiceLocator
    {
        T Resolve<T>() where T : class;

        void RegisterContainer(IDependencyContainer container);

        void UnregisterContainer(IDependencyContainer container);

        void RegisterService<T>(Object service);
    }
}