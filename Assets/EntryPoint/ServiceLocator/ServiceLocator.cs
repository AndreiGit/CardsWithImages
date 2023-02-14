using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EntryPoint.ServiceLocator
{
    public class ServiceLocator : MonoBehaviour, IServiceLocator
    {
        private const string DependencyContainerTag = "Dependency container";
        
        private List<IDependencyContainer> m_RegisteredContainers;

        public void RegisterContainer(IDependencyContainer container)
        {
            m_RegisteredContainers ??= new List<IDependencyContainer>();
            if(m_RegisteredContainers.Contains(container) == false)
                m_RegisteredContainers.Add(container);
        }
        
        public void UnregisterContainer(IDependencyContainer container)
        {
            m_RegisteredContainers.Remove(container);
            m_DependenciesCash?.Clear();
        }

        private Dictionary<Type, object> m_DependenciesCash;
        
        public T Resolve<T>() where T : class
        {
            if (this is T) return this as T;

            m_DependenciesCash ??= new Dictionary<Type, object>();
            
            if (m_DependenciesCash.ContainsKey(typeof(T)))
                return (T)m_DependenciesCash[typeof(T)];

            T dependency = FindDependencyFromContainers<T>();
            if (dependency == null)
            {
                Debug.LogError($"Can't resolve dependency {typeof(T)}");
                return null;                
            }

            m_DependenciesCash.Add(typeof(T), dependency);
            return dependency;
        }


        private T FindDependencyFromContainers<T>() where T : class
        {
            var dependency = TryFindDependency<T>();
            if (dependency != null) 
                return dependency;

            if(FindUnregisteredContainers())
                dependency = TryFindDependency<T>();
            
            return dependency;
        }

        private T TryFindDependency<T>() where T : class
        {
            m_RegisteredContainers ??= new List<IDependencyContainer>();
            
            foreach (var container in m_RegisteredContainers)
            {
                T dependency = container.GetDependency<T>();
                if (dependency != null)
                    return dependency;
            }

            return null;
        }

        private bool FindUnregisteredContainers()
        {
            var unregisteredContainers = 
                GameObject.FindGameObjectsWithTag(DependencyContainerTag)
                    .Select(container => container.GetComponent<IDependencyContainer>())
                    .Where(container => !m_RegisteredContainers.Contains(container))
                    .ToList();

            if (unregisteredContainers.Any() == false)
                return false;
            
            m_RegisteredContainers.AddRange(unregisteredContainers);
            return true;
        }

        public void RegisterService<T>(object service)
        {
            m_DependenciesCash ??= new Dictionary<Type, object>();
            m_DependenciesCash.Add(typeof(T), service);
        }
    }
}