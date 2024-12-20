using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolManager<T> : Singleton<PoolManager<T>> where T : PoolObj<T>
{
    [SerializeField] protected int _spawnCount = 0;
    [SerializeField] protected List<T> _listPool = new();

    protected override void Start()
    {
        DontDestroy(false);
    }
    //public virtual T Spawn(T prefab, Vector3 postion)
    //{
    //    T newObj = Spawn(prefab);
    //    newObj.transform.position = postion;
    //    return newObj;
    //}

    public virtual T Spawn(T prefab, Vector3 postion, Quaternion rotation)
    {
        T newObj = GetObjectFromPool(prefab);
        if (newObj == null)
        {
            newObj = Instantiate(prefab, postion, rotation);
            _spawnCount++;
            UpdateName(prefab.transform, newObj.transform);
            newObj.transform.SetParent(transform);
        }
        else
        {
            newObj.transform.SetPositionAndRotation(postion, rotation);
        }
        newObj.gameObject.SetActive(true);
        return newObj;
    }

    protected virtual T GetObjectFromPool(T prefab)
    {
        foreach (T inPoolObj in _listPool)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }

    public virtual void Despawn(T prefab)
    {
        prefab.gameObject.SetActive(false);
        AddObjToPool(prefab);
    }

    //public virtual void Despawn(T obj)
    //{
    //    if (obj is MonoBehaviour monoBehaviour)
    //    {
    //        monoBehaviour.gameObject.SetActive(false);
    //        AddObjToPool(obj);
    //    }
    //}

    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = _spawnCount + "_" + prefab.name;
    }

    protected virtual void AddObjToPool(T obj)
    {
        _listPool.Add(obj);
    }

    protected virtual void RemoveObjFromPool(T obj)
    {
        _listPool.Remove(obj);
    }

    protected virtual void ResetSpawnCount()
    {
        if (_listPool.Count <= 0)
            _spawnCount = 0;
    }
}
