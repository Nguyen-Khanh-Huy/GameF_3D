using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : PoolManager<EnemyCtrl>
{
    [SerializeField] protected EnemyPrefab _enemyPrefab;
    [SerializeField] protected float _speedSpawn;
    [SerializeField] protected float _timeSpawn;

    private void FixedUpdate()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        _timeSpawn += Time.deltaTime;
        if(_timeSpawn >= _speedSpawn)
        {
            _timeSpawn = 0;
            Spawn(_enemyPrefab.GetRandomEnemyPrefab(), new Vector3(0, 2, 45), Quaternion.identity);
        }
    }
    protected override void LoadComponent()
    {
        if(_enemyPrefab != null) return;
        _enemyPrefab = GetComponent<EnemyPrefab>();
        Debug.Log("Load: " + transform.name);
    }
}
