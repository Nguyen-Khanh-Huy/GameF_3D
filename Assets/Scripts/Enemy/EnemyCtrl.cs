using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PISMonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;

    public Animator Anim { get => _anim; }
    public NavMeshAgent Agent { get => _agent; }

    public abstract string GetName();

    protected override void LoadComponent()
    {
        if (_anim != null && _agent != null) return;
        _anim = GetComponentInChildren<Animator>();
        _agent= GetComponent<NavMeshAgent>();
        Debug.Log("Load Component");
    }
}
