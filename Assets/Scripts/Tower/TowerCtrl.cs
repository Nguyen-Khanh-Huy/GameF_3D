using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : PISMonoBehaviour
{
    [SerializeField] private TowerFire _towerFire;
    [SerializeField] private TowerTarget _towerTarget;
    [SerializeField] private BulletCtrl _bullet;
    [SerializeField] private Transform _rotate;
    [SerializeField] private Transform _firePoint1;
    [SerializeField] private Transform _firePoint2;

    public TowerTarget TowerTarget { get => _towerTarget; set => _towerTarget = value; }
    public BulletCtrl Bullet { get => _bullet; }
    public Transform Rotate { get => _rotate; set => _rotate = value; }
    public Transform FirePoint1 { get => _firePoint1; }
    public Transform FirePoint2 { get => _firePoint2; }

    protected override void LoadComponents()
    {
        if (_towerFire != null && _towerTarget != null && _bullet != null && _rotate != null && _firePoint1 != null && _firePoint2 != null) return;
        _towerFire = GetComponentInChildren<TowerFire>();
        _towerTarget = GetComponentInChildren<TowerTarget>();
        _bullet = Resources.Load<BulletCtrl>("Other/Bullet");
        _rotate = transform.Find("Model/Rotate");
        _firePoint1 = transform.Find("Model/Rotate/MGMain/FirePoint1");
        _firePoint2 = transform.Find("Model/Rotate/MGMain/FirePoint2");
        Debug.Log("Load: " + transform.name);
    }
}
