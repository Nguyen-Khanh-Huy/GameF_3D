using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioCtrl : PoolObj<AudioCtrl>
{
    [SerializeField] protected AudioSource _audioSource;
    protected override void LoadComponents()
    {
        if (_audioSource != null) return;
        _audioSource = GetComponent<AudioSource>();
        Debug.Log("Load: " + transform.name);
    }
}
