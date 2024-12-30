using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : BulletCtrl
{
    [SerializeField] private HitSlow _hitSlow;
    [SerializeField] private Transform target;

    [SerializeField] private float _speedBullet = 6f;
    [SerializeField] private float _despawnByTime = 4f;
    private bool _isGetTarget;

    protected override void OnEnable()
    {
        _isGetTarget = false;
        Invoke(nameof(DespawnBullet), _despawnByTime);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            UpdateHpEnemy(enemy);
            SpawnHitSlow(enemy);
        }
    }
    protected override void BulletMoving()
    {
        if (!_isGetTarget && TowerFireSlow != null)
        {
            _isGetTarget = true;
            target = TowerFireSlow.TowerSlow.TowerTarget.Target.transform;
        }

        if (target == null) return;
        Vector3 targetUpdate = target.position + Vector3.up;
        transform.LookAt(targetUpdate);
        transform.position = Vector3.MoveTowards(transform.position, targetUpdate, _speedBullet * Time.deltaTime);
        if (transform.position == targetUpdate)
        {
            DespawnBullet();
        }
    }

    private void SpawnHitSlow(EnemyCtrl enemy)
    {
        if (enemy.Hp > 0)
        {
            EffectCtrl hitSpawn = PoolManager<EffectCtrl>.Ins.Spawn(_hitSlow, enemy.transform.position, Quaternion.identity);
            hitSpawn.transform.SetParent(enemy.transform);
            enemy.Agent.speed = 1.2f;
            enemy.EnemyMoving.TimeChangeSpeed = 0f;
        }
    }

    public override string GetName()
    {
        return "BulletSlow";
    }

    protected override void LoadComponents()
    {
        if (_hitSlow != null) return;
        _hitSlow = Resources.Load<HitSlow>("Hits/HitSlow");
    }
}
