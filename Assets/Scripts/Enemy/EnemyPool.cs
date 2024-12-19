using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : PoolManager<EnemyCtrl>
{
    [SerializeField] protected EnemyPrefab _enemyPrefab;

    protected override void LoadComponent()
    {
        if(_enemyPrefab != null) return;
        _enemyPrefab = GetComponent<EnemyPrefab>();
        Debug.Log("Load: " + transform.name);
    }
}
