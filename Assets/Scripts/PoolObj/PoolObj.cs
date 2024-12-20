using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PoolObj<T> : PISMonoBehaviour where T : PoolObj<T>
{
    //[SerializeField] protected PoolManager<T> _poolManager;
    public abstract string GetName();

    //protected override void LoadComponent()
    //{
    //    if (_poolManager != null) return;
    //    _poolManager = GetComponentInParent<PoolManager<T>>();
    //}
}
