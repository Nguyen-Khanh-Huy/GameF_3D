using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusicGamePlay : AudioCtrl
{
    public override string GetName()
    {
        return "AudioMusic";
    }
    protected override void LoadComponents()
    {
        _audioSource.loop = true;
        _audioSource.spatialBlend = 0;
        base.LoadComponents();
    }
}
