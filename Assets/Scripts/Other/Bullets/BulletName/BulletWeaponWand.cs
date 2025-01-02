using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeaponWand : BulletCtrl
{
    [SerializeField] private HitWeaponWand _hitWeaponWand;
    [SerializeField] private vThirdPersonCamera _vThirdPersonCamera;
    [SerializeField] private float _speedBullet = 20f;
    [SerializeField] private float _despawnByTime = 6f;

    private Vector3 cameraForward;
    private bool _isGetDirection;
    protected override void OnEnable()
    {
        _isGetDirection = false;
        Invoke(nameof(DespawnBullet), _despawnByTime);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            UpdateHpEnemy(enemy);
            if (enemy.Hp <= 0) return;
            SpawnHitSlow(enemy);
            DespawnBullet();
        }
    }
    protected override void BulletMoving()
    {
        if (!_isGetDirection)
        {
            _isGetDirection = true;
            cameraForward = _vThirdPersonCamera.transform.TransformDirection(Vector3.forward);
        }
        transform.Translate(_speedBullet * Time.deltaTime * cameraForward);
    }

    private void SpawnHitSlow(EnemyCtrl enemy)
    {
        if (enemy.Hp > 0)
        {
            EffectCtrl hitSpawn = PoolManager<EffectCtrl>.Ins.Spawn(_hitWeaponWand, enemy.transform.position, Quaternion.identity);
            hitSpawn.transform.SetParent(enemy.transform);
        }
    }
    public override string GetName()
    {
        return "BulletWeaponWand";
    }

    protected override void LoadComponents()
    {
        if (_hitWeaponWand != null && _vThirdPersonCamera != null) return;
        _vThirdPersonCamera = GameObject.Find("CameraFollow").GetComponent<vThirdPersonCamera>();
        _hitWeaponWand = Resources.Load<HitWeaponWand>("Hits/HitWeaponWand");
    }
}
