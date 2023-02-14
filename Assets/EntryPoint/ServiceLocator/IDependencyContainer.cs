namespace EntryPoint.ServiceLocator
{
    public interface IDependencyContainer
    {
        T GetDependency<T>();
        
        string Name { get; }
    }
}