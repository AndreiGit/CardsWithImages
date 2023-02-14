using System;
using System.Collections;

namespace EntryPoint
{
    public interface IModeInitializer
    {
        IEnumerator InitializeMode(string sceneName, Action onInitializationCompleted);
        
        IEnumerator ExitFromMode(string sceneName, Action onExitCompleted);

    }
}