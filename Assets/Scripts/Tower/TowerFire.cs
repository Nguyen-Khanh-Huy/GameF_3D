using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : PISMonoBehaviour
{
    [SerializeField] private TowerCtrl _towerCtrl;

    private void Update()
    {
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if(_towerCtrl.TowerTarget.Target == null) return;
        _towerCtrl.Rotate.LookAt(_towerCtrl.TowerTarget.Target.transform);
    }

    protected override void LoadComponent()
    {
        if (_towerCtrl != null) return;
        _towerCtrl = GetComponentInParent<TowerCtrl>();
        Debug.Log("Load: " + transform.name);
    }
}
