using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj<EnemyCtrl>
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private TowerCtrl _towerCtrl;
    [SerializeField] private MovingPoint _movingPoint;
    [SerializeField] private EnemyMoving _enemyMoving;
    [SerializeField] private int _hp = 3;

    public Animator Anim { get => _anim; }
    public NavMeshAgent Agent { get => _agent; }
    public TowerCtrl TowerCtrl { get => _towerCtrl;}
    public MovingPoint MovingPoint { get => _movingPoint; set => _movingPoint = value; }
    public EnemyMoving EnemyMoving { get => _enemyMoving; }
    public int Hp { get => _hp; set => _hp = value; }

    protected override void LoadComponents()
    {
        if (_anim != null && _agent != null && _towerCtrl != null && _movingPoint != null && _enemyMoving != null) return;
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _towerCtrl = GameObject.Find("TowerCtrl").GetComponent<TowerCtrl>();
        _movingPoint = GameObject.Find("MovingPoint").GetComponent<MovingPoint>();
        _enemyMoving = GetComponentInChildren<EnemyMoving>();
        Debug.Log("Load: " + transform.name);
    }
}
