using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusicGamePlay : AudioCtrl
{
    public override string GetName()
    {
        return "AudioMusicGamePlay";
    }

    protected override void SetInfor()
    {
        AudioSource.loop = true;
        AudioSource.spatialBlend = 0;
    }
}
