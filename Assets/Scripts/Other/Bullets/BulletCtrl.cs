using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletCtrl : PoolObj<BulletCtrl>
{
    [SerializeField] protected float _speedBullet;
    [SerializeField] protected float _despawnByTime;

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
        // Override _speedBullet and _despawnByTime
        Invoke(nameof(DespawnBullet), _despawnByTime);
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
