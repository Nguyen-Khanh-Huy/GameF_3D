using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFireSlow : PISMonoBehaviour
{
    [SerializeField] private TowerSlow _towerSlow;
    [SerializeField] private float _speedFire = 1.5f;

    public TowerSlow TowerSlow { get => _towerSlow; }
    
    private float _timeFire;

    private void Update()
    {
        LookAtTarget();
        FireBullet();
    }

    private void FireBullet()
    {
        if (_towerSlow.TowerTarget.Target == null) return;
        _timeFire += Time.deltaTime;
        if (_timeFire >= _speedFire)
        {
            _timeFire = 0;
            BulletCtrl bulletSlow = PoolManager<BulletCtrl>.Ins.Spawn(_towerSlow.BulletSlow, _towerSlow.FirePoint.position, _towerSlow.FirePoint.rotation);
            bulletSlow.TowerFireSlow = this;
            
            EffectCtrl muzzleNormal = PoolManager<EffectCtrl>.Ins.Spawn(_towerSlow.MuzzleSlow, _towerSlow.FirePoint.position, _towerSlow.FirePoint.rotation);
            muzzleNormal.transform.SetParent(_towerSlow.FirePoint);
            
            AudioManager.Ins.SpawnSFX(typeof(AudioSFXTowerFireSlow), _towerSlow.FirePoint.position);
        }
    }

    private void LookAtTarget()
    {
        if (_towerSlow.TowerTarget.Target == null) return;
        _towerSlow.Rotate.LookAt(_towerSlow.TowerTarget.Target.transform);
    }

    protected override void LoadComponents()
    {
        if (_towerSlow != null) return;
        _towerSlow = GetComponentInParent<TowerSlow>();
        Debug.Log("Load: " + transform.name);
    }
}
