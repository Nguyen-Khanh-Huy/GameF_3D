using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerCtrl : PISMonoBehaviour
{
    [SerializeField] private TowerTarget _towerTarget;
    public TowerTarget TowerTarget { get => _towerTarget; }
    
    protected override void LoadComponents()
    {
        if (_towerTarget != null) return;
        _towerTarget = GetComponentInChildren<TowerTarget>();
        Debug.Log("Load: " + transform.name);
    }
}
