using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolObj<Bullet>
{
    [SerializeField] private float _speedBullet;
    private void Update()
    {
        transform.Translate(this._speedBullet * Time.deltaTime * Vector3.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            PoolManager<Bullet>.Ins.Despawn(this);
            PoolManager<EnemyCtrl>.Ins.Despawn(enemy);
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(DespawnBullet), 3f);
    }

    private void DespawnBullet()
    {
        PoolManager<Bullet>.Ins.Despawn(this);
    }

    public override string GetName()
    {
        return "Bullet";
    }

    protected override void LoadComponents()
    {
        // Nothing
    }
}
