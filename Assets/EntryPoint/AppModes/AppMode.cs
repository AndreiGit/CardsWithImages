using System;
using UnityEngine;

namespace EntryPoint.AppModes
{
    public class AppMode : MonoBehaviour, IAppMode
    {
        [SerializeField] private string _sceneName;

        private IModeInitializer _initializer;
        private void Awake()
        {
            _initializer = GetComponent<IModeInitializer>();
        }

        public void Load(Action onLoadCompleted)
        {
            StartCoroutine(_initializer.InitializeMode(_sceneName, onLoadCompleted));
        }

        public void Unload(Action onUnloadCompleted)
        {
           StartCoroutine(_initializer.ExitFromMode(_sceneName, onUnloadCompleted));
        }

        public string Name => gameObject.name;
        
        public IModeInitializer ModeInitializer => _initializer;
    }
}