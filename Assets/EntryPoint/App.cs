using EntryPoint.AppModes;
using EntryPoint.ServiceLocator;
using UnityEngine;

namespace EntryPoint
{
    public class App : MonoBehaviour
    {
        public static App Instance => s_instance;
        private static App s_instance;

        private IServiceLocator _serviceLocator;
        private IModeManager _modeManager;

        [SerializeField] private bool _debug;
        [SerializeField] private string _firstMode;
        public void Awake()
        {
            if (s_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            s_instance = this;
            _modeManager = GetComponent<IModeManager>();
        }

        private void Start()
        {
            if(_debug)
                return;
            
            _modeManager.InitFirst(_firstMode);
        }

        public bool ChangeModeTo(string modeName) => _modeManager.ChangeModeTo(modeName);
        
        public IAppMode ActiveMode => _modeManager.CurrentMode;
        
        public T GetService<T>() where T : class
        {
            _serviceLocator ??= GetComponent<IServiceLocator>();
            return _serviceLocator.Resolve<T>();
        }

        public void RegisterService<T>(object service)
        {
            _serviceLocator ??= GetComponent<IServiceLocator>();
            _serviceLocator.RegisterService<T>(service);
        }
    }
}