using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXTowerFire : AudioCtrl
{
    public override string GetName()
    {
        return "AudioTowerFire";
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Invoke(nameof(DespawnAudioSFX), 1f);
    }

    private void DespawnAudioSFX()
    {
        PoolManager<AudioCtrl>.Ins.Despawn(this);
    }

    protected override void SetInfor()
    {
        AudioSource.loop = false;
        AudioSource.spatialBlend = 1;
        AudioSource.minDistance = 5;
    }
}
