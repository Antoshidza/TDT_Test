using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Source.App.Pooling
{
    public class MonoViewPool<T> : ObjectPool<T>
        where T : Component, new()
    {
        public MonoViewPool(T prefab, Action<T> actionOnGet = null, Action<T> actionOnRelease = null, Action<T> actionOnDestroy = null, bool collectionCheck = true, int defaultCapacity = 1, int maxSize = 10000) 
            : base(() => Object.Instantiate(prefab), 
                instance => 
                {
                    instance.gameObject.SetActive(true);
                    instance.gameObject.hideFlags = HideFlags.None;
                    actionOnGet?.Invoke(instance);
                },
                instance => 
                {
                    instance.gameObject.SetActive(false);
                    instance.gameObject.hideFlags = HideFlags.HideInHierarchy;
                    actionOnRelease?.Invoke(instance);
                }, actionOnDestroy, collectionCheck, defaultCapacity, maxSize)
        {
        }
    }
}