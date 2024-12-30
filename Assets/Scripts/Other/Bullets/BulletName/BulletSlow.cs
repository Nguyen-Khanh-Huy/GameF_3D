using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : BulletCtrl
{
    [SerializeField] private TowerFireSlow _towerFireSlow;
    [SerializeField] private HitSlow _hitSlow;

    [SerializeField] private EnemyCtrl target;

    protected override void OnEnable()
    {
        _speedBullet = 6f;
        _despawnByTime = 4f;
        base.OnEnable();
        target = _towerFireSlow.TowerSlow.TowerTarget.Target;
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
        if (target == null && _speedBullet == 0f) return;
        Vector3 targetUpdate = target.transform.position + Vector3.up;
        transform.LookAt(targetUpdate);
        transform.position = Vector3.MoveTowards(transform.position, targetUpdate, _speedBullet * Time.deltaTime);
        if(transform.position == targetUpdate)
        {
            DespawnBullet();
        }
    }

    private void SpawnHitSlow(EnemyCtrl enemy)
    {
        if(enemy.Hp > 0)
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
        if (_towerFireSlow != null && _hitSlow != null) return;
        _towerFireSlow = GameObject.Find("TowerFireSlow").GetComponent<TowerFireSlow>();
        _hitSlow = Resources.Load<HitSlow>("Hits/HitSlow");
    }
}
