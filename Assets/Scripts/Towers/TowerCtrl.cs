using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : PISMonoBehaviour
{
    [SerializeField] private TowerFire _towerFire;
    [SerializeField] private TowerTarget _towerTarget;
    [SerializeField] private BulletCtrl _bullet;
    [SerializeField] private EffectCtrl _muzzleNormal;
    [SerializeField] private Transform _rotate;
    [SerializeField] private Transform _firePoint1;
    [SerializeField] private Transform _firePoint2;

    public TowerTarget TowerTarget { get => _towerTarget; }
    public BulletCtrl Bullet { get => _bullet; }
    public EffectCtrl MuzzleNormal { get => _muzzleNormal; }
    public Transform Rotate { get => _rotate; }
    public Transform FirePoint1 { get => _firePoint1; }
    public Transform FirePoint2 { get => _firePoint2; }

    protected override void LoadComponents()
    {
        if (_towerFire != null && _towerTarget != null && _bullet != null && _muzzleNormal != null && _rotate != null && _firePoint1 != null && _firePoint2 != null) return;
        _towerFire = GetComponentInChildren<TowerFire>();
        _towerTarget = GetComponentInChildren<TowerTarget>();
        _bullet = Resources.Load<BulletCtrl>("Bullets/BulletNormal");
        _muzzleNormal = Resources.Load<EffectCtrl>("Muzzle/MuzzleNormal");
        _rotate = transform.Find("Model/Rotate");
        _firePoint1 = transform.Find("Model/Rotate/MGMain/FirePoint1");
        _firePoint2 = transform.Find("Model/Rotate/MGMain/FirePoint2");
        Debug.Log("Load: " + transform.name);
    }
}
