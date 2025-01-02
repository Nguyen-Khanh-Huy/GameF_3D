using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlow : TowerCtrl
{
    [SerializeField] private TowerFireSlow _towerFireSlow;
    [SerializeField] private Transform _rotate;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletCtrl _bulletSlow;
    [SerializeField] private EffectCtrl _muzzleSlow;

    public Transform Rotate { get => _rotate; set => _rotate = value; }
    public Transform FirePoint { get => _firePoint; }
    public BulletCtrl BulletSlow { get => _bulletSlow; }
    public EffectCtrl MuzzleSlow { get => _muzzleSlow; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (_towerFireSlow != null && _rotate != null && _firePoint != null && _bulletSlow != null && _muzzleSlow != null) return;
        _towerFireSlow = GetComponentInChildren<TowerFireSlow>();
        _rotate = transform.Find("Model/Rotate");
        _firePoint = transform.Find("Model/Rotate/Gun/FirePoint");
        _bulletSlow = Resources.Load<BulletCtrl>("TowerBullets/BulletSlow");
        _muzzleSlow = Resources.Load<EffectCtrl>("Muzzle/MuzzleSlow");
    }
}
