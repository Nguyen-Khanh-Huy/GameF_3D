using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlow : BulletCtrl
{
    [SerializeField] private TowerFireSlow _towerFireSlow;

    [SerializeField] private Transform target;

    protected override void OnEnable()
    {
        _speedBullet = 6f;
        _despawnByTime = 4f;
        base.OnEnable();
        target = _towerFireSlow.TowerSlow.TowerTarget.Target.transform;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            UpdateHpEnemy(enemy);
        }
    }

    protected override void BulletMoving()
    {
        if (target == null && _speedBullet == 0f) return;
        Vector3 targetUpdate = target.position + Vector3.up;
        transform.LookAt(targetUpdate);
        transform.position = Vector3.MoveTowards(transform.position, targetUpdate, _speedBullet * Time.deltaTime);
        if(transform.position == targetUpdate)
        {
            DespawnBullet();
        }
    }

    public override string GetName()
    {
        return "BulletSlow";
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (_towerFireSlow != null) return;
        _towerFireSlow = GameObject.Find("TowerFireSlow").GetComponent<TowerFireSlow>();
    }
}
