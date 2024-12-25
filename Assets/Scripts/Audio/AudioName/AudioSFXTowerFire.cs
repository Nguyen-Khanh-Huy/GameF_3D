using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXTowerFire : AudioCtrl
{
    public override string GetName()
    {
        return "TowerFire";
    }
    protected override void LoadComponents()
    {
        _audioSource.loop = false;
        _audioSource.spatialBlend = 1;
        _audioSource.minDistance = 5;
        base.LoadComponents();
    }

    private void OnEnable()
    {
        Invoke(nameof(DespawnAudioSFX), 1f);
    }

    private void DespawnAudioSFX()
    {
        PoolManager<AudioCtrl>.Ins.Despawn(this);
    }
}
