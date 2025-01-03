using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : PISMonoBehaviour
{
    [SerializeField] private PlayerCtrl _player;
    [SerializeField] private BulletCtrl _bulletWeaponWand;
    [SerializeField] private float _speedFire = 0.5f;
    private float _timeFire;
    protected override void LoadComponents()
    {
        if (_player != null && _bulletWeaponWand != null) return;
        _player = GetComponentInParent<PlayerCtrl>();
        _bulletWeaponWand = Resources.Load<BulletCtrl>("WeaponBullets/BulletWeaponWand");
    }

    private void Update()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        if (!_player.PlayerRig.IsAim || _player.Weapon.GetWeapon() == null) return;
        _timeFire += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if (_timeFire >= _speedFire)
            {
                _timeFire = 0;
                PoolManager<BulletCtrl>.Ins.Spawn(_bulletWeaponWand, _player.Weapon.GetWeapon().WeaponPoint.transform.position, Quaternion.identity);
            }
        }
    }
}
