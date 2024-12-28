using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : PISMonoBehaviour
{
    [SerializeField] private EnemyPrefab _enemyPrefab;
    [SerializeField] private EnemyPool _enemyPool;

    [SerializeField] protected float _speedSpawn = 2f;
    public EnemyPrefab EnemyPrefab { get => _enemyPrefab; }
    public EnemyPool EnemyPool { get => _enemyPool; }

    private void Start()
    {
        Invoke(nameof(SpawnEnemy), _speedSpawn);
    }

    protected override void LoadComponents()
    {
        if (_enemyPrefab != null && _enemyPool != null) return;
        _enemyPrefab = GetComponentInChildren<EnemyPrefab>();
        _enemyPool = GetComponentInChildren<EnemyPool>();
        Debug.Log("Load: " + transform.name);
    }

    private void SpawnEnemy()
    {
        Invoke(nameof(SpawnEnemy), _speedSpawn);
        EnemyCtrl enemyPrefab = _enemyPrefab.GetRandomEnemyPrefab();
        PoolManager<EnemyCtrl>.Ins.Spawn(enemyPrefab, new Vector3(0f, 0.5f, 45f), Quaternion.identity);
    }
}
