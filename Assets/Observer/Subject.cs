using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    public List<IObserver> observers = new List<IObserver>();
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyObserver(EnemyAction action)
    {
        observers.ForEach((o) => { o.OnNotify(action); });
    }
}
