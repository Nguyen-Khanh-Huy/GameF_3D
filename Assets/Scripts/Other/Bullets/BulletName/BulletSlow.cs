using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletSlow : BulletCtrl
{
    [SerializeField] private TowerFireSlow _towerFireSlow;
    [SerializeField] private float _speedBullet = 10;
    
    private Transform target;

    protected override void OnEnable()
    {
        target = _towerFireSlow.TowerSlow.TowerTarget.Target.transform;
        base.OnEnable();
    }

    protected override void BulletMoving()
    {
        if (target == null) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speedBullet * Time.deltaTime);
        transform.LookAt(target);
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
