using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolManager<T> : PISMonoBehaviour where T : PoolObj
{
    [SerializeField] protected int _spawnCount = 0;
    [SerializeField] protected List<T> _listPool = new();

    public virtual T Spawn(T prefab)
    {
        T newObj = this.GetObjFromPool(prefab);
        if (newObj == null)
        {
            newObj = Instantiate(prefab);
            _spawnCount++;
            UpdateName(prefab.transform, newObj.transform);
            newObj.transform.SetParent(transform);
        }
        return newObj;
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this._listPool)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            AddObjToPool(obj);
        }
    }

    protected virtual void UpdateName(Transform prefab, Transform newObject)
    {
        newObject.name = prefab.name + "_" + _spawnCount;
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
