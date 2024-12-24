using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : PoolManager<EnemyCtrl>
{
    [SerializeField] protected EnemyManager _enemyManager;
    [SerializeField] protected float _speedSpawn = 1f;

    private void Start()
    {
        Invoke(nameof(SpawnEnemy), _speedSpawn);
    }

    private void SpawnEnemy()
    {
        Invoke(nameof(SpawnEnemy), _speedSpawn);
        Spawn(_enemyManager.EnemyPrefab.GetRandomEnemyPrefab(), new Vector3(0f, 0f, 45f), Quaternion.identity);
    }

    protected override void LoadComponents()
    {
        if (_enemyManager != null) return;
        _enemyManager = GetComponentInParent<EnemyManager>();
        Debug.Log("Load: " + transform.name);
    }
}
