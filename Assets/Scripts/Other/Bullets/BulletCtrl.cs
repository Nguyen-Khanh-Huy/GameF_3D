using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletCtrl : PoolObj<BulletCtrl>
{
    [SerializeField] private float _speedBullet = 100;

    private void Update()
    {
        transform.Translate(this._speedBullet * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            DespawnBullet();
            UpdateHpEnemy(enemy);
        }
    }

    private void OnEnable()
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
