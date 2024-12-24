using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj<EnemyCtrl>
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private MovingPoints _movingPoints;
    [SerializeField] private EnemyMoving _enemyMoving;
    [SerializeField] private ItemManager _itemManager;
    [SerializeField] private int _hp = 3;

    public Animator Anim { get => _anim; }
    public NavMeshAgent Agent { get => _agent; }
    public MovingPoints MovingPoints { get => _movingPoints; set => _movingPoints = value; }
    public EnemyMoving EnemyMoving { get => _enemyMoving; }
    public ItemManager ItemManager { get => _itemManager; }
    public int Hp { get => _hp; set => _hp = value; }

    protected override void LoadComponents()
    {
        if (_anim != null && _agent != null && _movingPoints != null && _enemyMoving != null && _itemManager != null) return;
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _movingPoints = GameObject.Find("MovingPoints").GetComponent<MovingPoints>();
        _enemyMoving = GetComponentInChildren<EnemyMoving>();
        _itemManager = GameObject.Find("ItemsManager").GetComponent<ItemManager>();
        Debug.Log("Load: " + transform.name);
    }
}
