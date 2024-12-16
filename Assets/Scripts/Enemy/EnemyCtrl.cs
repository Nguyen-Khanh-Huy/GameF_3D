using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;

    public Animator Anim { get => _anim; }
    public NavMeshAgent Agent { get => _agent; }

    public abstract string GetName();
    private void Start()
    {
        LoadComponent();
    }
    private void Reset()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        if (_anim != null || _agent != null) return;
        _anim = GetComponentInChildren<Animator>();
        _agent= GetComponentInChildren<NavMeshAgent>();
        Debug.Log("Load Component");
    }
}
