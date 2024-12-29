using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : BulletCtrl
{
    private bool isCollided;
    protected override void OnEnable()
    {
        _speedBullet = 80f;
        _despawnByTime = 2f;
        isCollided = false;
        base.OnEnable();
    }

    //protected override void OnTriggerEnter(Collider other)
    //{
    //    base.OnTriggerEnter(other);
    //    EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
    //    if (enemy != null && enemy.Hp > 0)
    //    {
    //        DespawnBullet();
    //    }
    //}

    protected override void BulletMoving()
    {
        if (_speedBullet == 0f) return;
        transform.Translate(_speedBullet * Time.deltaTime * Vector3.forward);
        BulletRayCast();
    }

    private void BulletRayCast()
    {
        if (Physics.SphereCast(transform.position, 0.1f, Vector3.forward, out RaycastHit hitInfo, _speedBullet * Time.deltaTime))
        {
            EnemyCtrl enemy = hitInfo.collider.GetComponentInParent<EnemyCtrl>();
            if (enemy != null && enemy.Hp > 0 && !isCollided)
            {
                isCollided = true;
                DespawnBullet();
                UpdateHpEnemy(enemy);
            }
        }
    }

    public override string GetName()
    {
        return "BulletNormal";
    }
}
