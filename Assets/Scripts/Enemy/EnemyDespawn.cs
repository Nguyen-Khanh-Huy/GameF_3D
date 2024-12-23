using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : PISMonoBehaviour
{
    [SerializeField] private EnemyCtrl _enemyCtrl;
    [SerializeField] private float _despawnByTime = 3f;

    protected override void LoadComponents()
    {
        if (_enemyCtrl != null) return;
        _enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log("Load: " + transform.name);
    }

    private void Update()
    {
        DespawnEnemy();
    }

    private void DespawnEnemy()
    {
        if (_enemyCtrl.Hp > 0) return;
        _enemyCtrl.TowerCtrl.TowerTarget.RemoveInListTowerTarget(_enemyCtrl);
        Invoke(nameof(DelayDespawnEnemy), _despawnByTime);
    }

    private void DelayDespawnEnemy()
    {
        _enemyCtrl.Hp = 3;
        _enemyCtrl.EnemyMoving.PointIdx = 0;
        PoolManager<EnemyCtrl>.Ins.Despawn(_enemyCtrl);
    }
}
