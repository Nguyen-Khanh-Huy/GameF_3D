using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public abstract class BulletCtrl : PoolObj<BulletCtrl>
{
    protected TowerFireSlow _towerFireSlow;
    public TowerFireSlow TowerFireSlow { get => _towerFireSlow; set => _towerFireSlow = value; }

    private void Update()
    {
        BulletMoving();
    }

    protected abstract void BulletMoving();

    protected virtual void OnTriggerEnter(Collider other)
    {
        // For Override BulletSlow
    }

    protected virtual void OnEnable()
    {
        // For Override
    }

    protected virtual void OnDisable()
    {
        CancelInvoke(nameof(DespawnBullet));
    }

    protected virtual void DespawnBullet()
    {
        PoolManager<BulletCtrl>.Ins.Despawn(this);
    }

    protected virtual void UpdateHpEnemy(EnemyCtrl enemy)
    {
        if (enemy.Hp <= 0) return;
        enemy.Hp--;
    }
    
    protected override void LoadComponents()
    {
        // Nothing
    }
}
