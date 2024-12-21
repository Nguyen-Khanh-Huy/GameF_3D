using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : PISMonoBehaviour
{
    [SerializeField] private TowerCtrl _towerCtrl;
    [SerializeField] private float _speedFire;

    private Transform _firePoint;
    private int _firePointCount = 0;
    private float _timeFire;

    private void Update()
    {
        LookAtTarget();
        FireBullet();
    }

    private void FireBullet()
    {
        if(_towerCtrl.TowerTarget.Target == null) return;
        _timeFire += Time.deltaTime;
        if (_timeFire >= _speedFire)
        {
            _timeFire = 0;
            PoolManager<Bullet>.Ins.Spawn(_towerCtrl.Bullet, GetFirePoint().transform.position, GetFirePoint().transform.rotation);
        }
    }

    private Transform GetFirePoint()
    {
        _firePointCount++;
        if(_firePointCount > 1)
        {
            _firePointCount = 0;
        }
        _firePoint = _firePointCount == 0 ? _towerCtrl.FirePoint1 : _towerCtrl.FirePoint2;
        return _firePoint;
    }

    private void LookAtTarget()
    {
        if(_towerCtrl.TowerTarget.Target == null) return;
        _towerCtrl.Rotate.LookAt(_towerCtrl.TowerTarget.Target.transform);
    }

    protected override void LoadComponents()
    {
        if (_towerCtrl != null) return;
        _towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log("Load: " + transform.name);
    }
}
