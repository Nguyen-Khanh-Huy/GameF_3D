using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFireNormal : PISMonoBehaviour
{
    [SerializeField] private TowerNormal _towerNormal;
    [SerializeField] private float _speedFire = 0.5f;

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
        if(_towerNormal.TowerTarget.Target == null) return;
        _timeFire += Time.deltaTime;
        if (_timeFire >= _speedFire)
        {
            _timeFire = 0;
            Transform getFirePoint = GetFirePoint();
            PoolManager<BulletCtrl>.Ins.Spawn(_towerNormal.BulletNormal, getFirePoint.position, getFirePoint.rotation);
            EffectCtrl muzzleNormal = PoolManager<EffectCtrl>.Ins.Spawn(_towerNormal.MuzzleNormal, getFirePoint.position, getFirePoint.rotation);
            muzzleNormal.transform.SetParent(getFirePoint);
            AudioManager.Ins.SpawnSFX(typeof(AudioSFXTowerFireNormal), getFirePoint.position);
        }
    }

    private Transform GetFirePoint()
    {
        _firePointCount = (_firePointCount + 1) % 2;
        _firePoint = _firePointCount == 0 ? _towerNormal.FirePoint1 : _towerNormal.FirePoint2;
        return _firePoint;
    }

    private void LookAtTarget()
    {
        if(_towerNormal.TowerTarget.Target == null) return;
        _towerNormal.Rotate.LookAt(_towerNormal.TowerTarget.Target.transform);
    }

    protected override void LoadComponents()
    {
        if (_towerNormal != null) return;
        _towerNormal = GetComponentInParent<TowerNormal>();
        Debug.Log("Load: " + transform.name);
    }
}
