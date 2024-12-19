using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : PISMonoBehaviour
{
    [SerializeField] protected TowerFire _towerFire;
    [SerializeField] protected TowerTarget _towerTarget;
    [SerializeField] private Transform _rotate;
    [SerializeField] private Transform _firePoint1;
    [SerializeField] private Transform _firePoint2;

    public TowerTarget TowerTarget { get => _towerTarget; set => _towerTarget = value; }
    public Transform Rotate { get => _rotate; set => _rotate = value; }

    protected override void LoadComponent()
    {
        if (_towerFire != null && _towerTarget != null && _rotate != null && _firePoint1 != null && _firePoint2 != null) return;
        _towerFire = GetComponentInChildren<TowerFire>();
        _towerTarget = GetComponentInChildren<TowerTarget>();
        _rotate = transform.Find("Model/Rotate");
        _firePoint1 = transform.Find("Model/Rotate/MGMain/FirePoint1");
        _firePoint2 = transform.Find("Model/Rotate/MGMain/FirePoint2");
        Debug.Log("Load: " + transform.name);
    }
}
