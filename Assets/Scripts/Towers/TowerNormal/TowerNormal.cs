using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNormal : TowerCtrl
{
    [SerializeField] private TowerFireNormal _towerFireNormal;
    [SerializeField] private Transform _rotate;
    [SerializeField] private Transform _firePoint1;
    [SerializeField] private Transform _firePoint2;
    [SerializeField] private BulletCtrl _bulletNormal;
    [SerializeField] private EffectCtrl _muzzleNormal;

    public Transform Rotate { get => _rotate; set => _rotate = value; }
    public Transform FirePoint1 { get => _firePoint1; set => _firePoint1 = value; }
    public Transform FirePoint2 { get => _firePoint2; set => _firePoint2 = value; }
    public BulletCtrl BulletNormal { get => _bulletNormal; }
    public EffectCtrl MuzzleNormal { get => _muzzleNormal; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (_towerFireNormal != null && _rotate != null && _firePoint1 != null && _firePoint2 != null && _bulletNormal != null && _muzzleNormal != null) return;
        _towerFireNormal = GetComponentInChildren<TowerFireNormal>();
        _rotate = transform.Find("Model/Rotate");
        _firePoint1 = transform.Find("Model/Rotate/Gun/FirePoint1");
        _firePoint2 = transform.Find("Model/Rotate/Gun/FirePoint2");
        _bulletNormal = Resources.Load<BulletCtrl>("Bullets/BulletNormal");
        _muzzleNormal = Resources.Load<EffectCtrl>("Muzzle/MuzzleNormal");
    }
}
