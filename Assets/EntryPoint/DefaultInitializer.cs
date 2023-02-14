using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntryPoint
{
    public class DefaultInitializer : MonoBehaviour, IModeInitializer
    {
        public IEnumerator InitializeMode(string sceneName, Action onInitializationCompleted)
        {
            yield return LoadScene(sceneName);
            onInitializationCompleted.Invoke();
        }

        public IEnumerator ExitFromMode(string sceneName, Action onExitCompleted)
        {
            yield return UnloadScene(sceneName);
            onExitCompleted.Invoke();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (!operation.isDone)
                yield return null;
        }

        private IEnumerator UnloadScene(string sceneName)
        {
            var operation = SceneManager.UnloadSceneAsync(sceneName);
            while (!operation.isDone)
            {
                yield return null;
            }
        }
    }
}