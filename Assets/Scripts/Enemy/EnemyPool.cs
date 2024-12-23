using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : PoolManager<EnemyCtrl>
{
    [SerializeField] protected EnemyPrefab _enemyPrefab;
    [SerializeField] protected float _speedSpawn;

    private void Start()
    {
        Invoke(nameof(SpawnEnemy), _speedSpawn);
    }

    private void SpawnEnemy()
    {
        Invoke(nameof(SpawnEnemy), _speedSpawn);
        Spawn(_enemyPrefab.GetRandomEnemyPrefab(), new Vector3(0f, 0f, 45f), Quaternion.identity);
    }

    protected override void LoadComponents()
    {
        if (_enemyPrefab != null) return;
        _enemyPrefab = GetComponent<EnemyPrefab>();
        Debug.Log("Load: " + transform.name);
    }
}
