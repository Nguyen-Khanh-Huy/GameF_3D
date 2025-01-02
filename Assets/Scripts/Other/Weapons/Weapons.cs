using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapons : PISMonoBehaviour
{
    [SerializeField] private int _weaponIdx;
    [SerializeField] private List<WeaponCtrl> _listWeapons = new();

    protected override void LoadComponents()
    {
        if (_listWeapons.Count == transform.childCount) return;
        foreach (Transform child in transform)
        {
            WeaponCtrl weapon = child.GetComponent<WeaponCtrl>();
            if (!_listWeapons.Contains(weapon))
            {
                _listWeapons.Add(weapon);
            }
        }
        Debug.Log("Load: " + transform.name);
    }

    public WeaponCtrl GetWeapon()
    {
        return _listWeapons[_weaponIdx];
    }
}
