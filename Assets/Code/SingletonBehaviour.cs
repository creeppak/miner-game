using System;
using UnityEngine;

public abstract class SingletonBehaviour<TImpl> : MonoBehaviour
    where TImpl : MonoBehaviour
{
    public static TImpl Instance { get; private set; }
    
    public virtual void Awake()
    {
        if (Instance) throw new Exception("2 instances");
        Instance = this as TImpl;
    }
}