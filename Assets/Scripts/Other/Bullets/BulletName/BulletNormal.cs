using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNormal : BulletCtrl
{
    [SerializeField] private float _speedBullet = 100;

    protected override void BulletMoving()
    {
        transform.Translate(this._speedBullet * Time.deltaTime * Vector3.forward);
    }

    public override string GetName()
    {
        return "BulletNormal";
    }
}
