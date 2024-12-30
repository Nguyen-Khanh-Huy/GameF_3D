using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : BulletCtrl
{
    [SerializeField] private float _speedBullet = 80f;
    [SerializeField] private float _despawnByTime = 2f;

    private bool isCollided;
    protected override void OnEnable()
    {
        isCollided = false;
        Invoke(nameof(DespawnBullet), _despawnByTime);
    }

    protected override void BulletMoving()
    {
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
