using UnityEngine;

namespace EntryPoint.ServiceLocator
{
    public class DependencyContainer : MonoBehaviour, IDependencyContainer
    {
        [SerializeField] private bool m_SearchInChildren;

        private IServiceLocator m_ServiceLocator;
        private void Awake()
        {
            m_ServiceLocator = App.Instance.GetService<IServiceLocator>();
            m_ServiceLocator.RegisterContainer(this);
        }

        private void OnDestroy()
        {
            if(m_ServiceLocator != null)
                m_ServiceLocator.UnregisterContainer(this);
        }

        public T GetDependency<T>() => m_SearchInChildren ? GetComponentInChildren<T>() : GetComponent<T>();
        
        public string Name => name;
    }
}