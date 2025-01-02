using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCtrl : PISMonoBehaviour
{
    [SerializeField] private PlayerRig _playerRig;
    [SerializeField] private Weapons _weapon;
    [SerializeField] private vThirdPersonCamera _vThirdPersonCamera;
    [SerializeField] private Rig _rig;

    public PlayerRig PlayerRig { get => _playerRig; }
    public Weapons Weapon { get => _weapon; }
    public vThirdPersonCamera VThirdPersonCamera { get => _vThirdPersonCamera; set => _vThirdPersonCamera = value; }
    public Rig Rig { get => _rig; set => _rig = value; }

    protected override void LoadComponents()
    {
        if (_playerRig != null && _weapon != null && _vThirdPersonCamera != null && _rig != null) return;
        _playerRig = GetComponentInChildren<PlayerRig>();
        _weapon = transform.Find("Model").GetComponentInChildren<Weapons>();
        _vThirdPersonCamera = GameObject.Find("CameraFollow").GetComponent<vThirdPersonCamera>();
        _rig = transform.Find("Model").GetComponentInChildren<Rig>();
    }
}
