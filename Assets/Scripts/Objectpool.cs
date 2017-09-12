using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolItem
{
    void OnSpawn();
    void OnReset();
}

public class Objectpool<T> where T : Component, IPoolItem
{

    List<T> items = new List<T>();

    public void CreatePool(int count = 10)
    {

        for (int i = 0; i < count; i++)
        {
            Create();
        }
    }

    public T Create()
    {
        var type = typeof(T);
        GameObject go = new GameObject(type.Name, type);
        T component = go.GetComponent<T>();
        component.gameObject.SetActive(false);
        items.Add(component);
        return component;
    }

    public T Spawn(Vector3 position, Quaternion rotation)
    {
        T comp = default(T);
        for (int i = 0; i < items.Count; i++)
        {
            comp = items[i];
            if (comp.gameObject.activeInHierarchy == false)
            {
                comp.gameObject.SetActive(true);
                comp.transform.position = position;
                comp.transform.rotation = rotation;
            }
        }
        if (comp == null)
        {
            comp = Create();
        }
        items.Remove(comp);
        comp.OnSpawn();
        return comp;
    }

    public void Recycle(T obj)
    {
        obj.gameObject.SetActive(false);
    }
}
