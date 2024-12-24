using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : PISMonoBehaviour
{
    [SerializeField] private EnemyPrefab _enemyPrefab;
    [SerializeField] private EnemyPool _enemyPool;

    public EnemyPrefab EnemyPrefab { get => _enemyPrefab; }
    public EnemyPool EnemyPool { get => _enemyPool; }

    protected override void LoadComponents()
    {
        if (_enemyPrefab != null && _enemyPool != null) return;
        _enemyPrefab = GetComponentInChildren<EnemyPrefab>();
        _enemyPool = GetComponentInChildren<EnemyPool>();
        Debug.Log("Load: " + transform.name);
    }
}
