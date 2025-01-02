using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : PISMonoBehaviour
{
    [SerializeField] private Transform _weaponPoint;
    public Transform WeaponPoint { get => _weaponPoint; }

    protected override void LoadComponents()
    {
        if (_weaponPoint != null) return;
        _weaponPoint = transform.Find("WeaponPoint");
        transform.localPosition = new Vector3(0.09f, -0.12f, 0.017f);
        transform.localRotation = Quaternion.Euler(6f, -1.4f, 35f);
    }
}
