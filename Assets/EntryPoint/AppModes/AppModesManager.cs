using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EntryPoint.AppModes
{
    public class AppModesManager : MonoBehaviour, IModeManager
    {
        public IAppMode CurrentMode { get; private set; }

        private Dictionary<string, IAppMode> _modesMap;

        private Queue<string> _modesQueue;

        private bool _loadingInProgress;

        private void Awake()
        {
            GenerateModesMap();
        }

        public void InitFirst(string modeName)
        {
            var mode = _modesMap[modeName];
            _loadingInProgress = true;
            StartupMode(mode);
        }

        public bool ChangeModeTo(string modeName)
        {
            if (CurrentMode.Name == modeName)
                return false;
            
            if (_loadingInProgress)
                return false;

            if(TryGetModeByName(modeName, out var mode) == false)
                return false;
            
            _loadingInProgress = true;
            CurrentMode.Unload(() => StartupMode(mode));
            
            return true;
        }

        private void StartupMode(IAppMode mode)
        {
            CurrentMode = mode;
            _loadingInProgress = true;
            mode.Load(() => _loadingInProgress = false);
        }

        private void GenerateModesMap()
        {
            _modesMap ??= new Dictionary<string, IAppMode>();
            foreach (var mode in GetComponentsInChildren<IAppMode>()) 
                _modesMap.Add(mode.Name, mode);
        }

        private bool TryGetModeByName(string modeName, out IAppMode mode)
        {
            if (_modesMap.TryGetValue(modeName, out mode)) 
                return true;
            
            Debug.LogError($"Missing mode with name {modeName}");
            return false;
        }
    }
}