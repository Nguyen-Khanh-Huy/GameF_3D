using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioMusicCtrl : PoolObj<AudioMusicCtrl>
{
    private AudioSource _soundMusic;
    protected override void LoadComponents()
    {
        //
    }
}
