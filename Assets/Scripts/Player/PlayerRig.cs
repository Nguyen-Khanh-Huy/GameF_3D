using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRig : PISMonoBehaviour
{
    [SerializeField] private PlayerCtrl _player;
    [SerializeField] private float _defaulDistance = 2.5f;
    [SerializeField] private float _aimDistance = 1.3f;
    [SerializeField] private bool _isAim;

    public bool IsAim { get => _isAim; }

    private void Update()
    {
        Aim();
        ChangeRotationPlayer();
    }

    protected override void LoadComponents()
    {
        if (_player != null) return;
        _player = GetComponentInParent<PlayerCtrl>();
    }

    private void Aim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isAim = true;
            _player.VThirdPersonCamera.defaultDistance = _aimDistance;
            _player.Rig.weight = 1;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _isAim = false;
            _player.VThirdPersonCamera.defaultDistance = _defaulDistance;
            _player.Rig.weight = 0;
        }
    }

    private void ChangeRotationPlayer()
    {
        if (_isAim)
        {
            Vector3 currentRotation = _player.transform.rotation.eulerAngles;
            _player.transform.rotation = Quaternion.Euler(currentRotation.x, _player.VThirdPersonCamera.transform.rotation.eulerAngles.y, currentRotation.z);
        }
    }
}
