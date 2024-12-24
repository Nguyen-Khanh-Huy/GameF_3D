using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioSFXCtrl : PoolObj<AudioSFXCtrl>
{
    private AudioSource _soundSFX;
    protected override void LoadComponents()
    {
        //
    }
}
