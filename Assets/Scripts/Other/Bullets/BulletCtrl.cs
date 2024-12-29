using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletCtrl : PoolObj<BulletCtrl>
{
    private void Update()
    {
        BulletMoving();
    }

    protected abstract void BulletMoving();

    private void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            DespawnBullet();
            UpdateHpEnemy(enemy);
        }
    }

    protected virtual void OnEnable()
    {
        Invoke(nameof(DespawnBullet), 3f);
    }

    private void DespawnBullet()
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
