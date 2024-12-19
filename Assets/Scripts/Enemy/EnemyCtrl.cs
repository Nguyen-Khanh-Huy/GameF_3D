using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private TowerCtrl _towerCtrl;

    public Animator Anim { get => _anim; }
    public NavMeshAgent Agent { get => _agent; }

    protected override void LoadComponent()
    {
        if (_anim != null && _agent != null && _towerCtrl != null) return;
        _anim = GetComponentInChildren<Animator>();
        _agent= GetComponent<NavMeshAgent>();
        _towerCtrl = GameObject.Find("TowerCtrl").GetComponent<TowerCtrl>();
        Debug.Log("Load: " + transform.name);
    }
    protected void OnDisable()
    {
        _towerCtrl.TowerTarget.ListEnemyTarget.Remove(this);
    }
}
