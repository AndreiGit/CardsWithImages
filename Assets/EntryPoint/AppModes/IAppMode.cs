using System;

namespace EntryPoint.AppModes
{
    public interface IAppMode
    {
        public void Load(Action onLoadCompleted);

        public void Unload(Action onUnloadCompleted);
        
        string Name { get; }
        
        IModeInitializer ModeInitializer { get; }
    }
}