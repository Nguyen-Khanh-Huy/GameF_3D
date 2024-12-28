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
            Transform getFirePoint = GetFirePoint();
            PoolManager<BulletCtrl>.Ins.Spawn(_towerCtrl.Bullet, getFirePoint.position, getFirePoint.rotation);
            EffectCtrl muzzleNormal = PoolManager<EffectCtrl>.Ins.Spawn(_towerCtrl.MuzzleNormal, getFirePoint.position, getFirePoint.rotation);
            muzzleNormal.transform.SetParent(getFirePoint);
            AudioManager.Ins.SpawnSFX(typeof(AudioSFXTowerFire), getFirePoint.position);
        }
    }

    private Transform GetFirePoint()
    {
        //_firePointCount++;
        //if(_firePointCount > 1)
        //{
        //    _firePointCount = 0;
        //}
        _firePointCount = (_firePointCount + 1) % 2;
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
