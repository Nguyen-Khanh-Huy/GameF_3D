using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : PISMonoBehaviour
{
    [SerializeField] private EnemyCtrl _enemyCtrl;
    [SerializeField] private float _despawnByTime = 3f;

    [SerializeField] private bool _isSpawnedItem;
    protected override void LoadComponents()
    {
        if (_enemyCtrl != null) return;
        _enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log("Load: " + transform.name);
    }

    private void FixedUpdate()
    {
        DespawnEnemy();
    }

    private void DespawnEnemy()
    {
        if (_enemyCtrl.Hp > 0) return;
        SpawnItems();
        StartCoroutine(DelayDespawnEnemy());
    }

    private IEnumerator DelayDespawnEnemy()
    {
        yield return new WaitForSeconds(_despawnByTime);
        _enemyCtrl.Hp = 3;
        _enemyCtrl.Agent.speed = 3.5f;
        _enemyCtrl.EnemyMoving.PointIdx = 0;
        _isSpawnedItem = false;
        PoolManager<EnemyCtrl>.Ins.Despawn(_enemyCtrl);
    }

    private void SpawnItems()
    {
        if (!_isSpawnedItem)
        {
            _isSpawnedItem = true;
            _enemyCtrl.ItemManager.SpawnItems(_enemyCtrl);
        }
    }
}
