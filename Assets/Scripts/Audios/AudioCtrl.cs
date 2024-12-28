using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioCtrl : PoolObj<AudioCtrl>
{
    [SerializeField] public AudioSource AudioSource;
    protected override void LoadComponents()
    {
        if (AudioSource != null) return;
        AudioSource = GetComponent<AudioSource>();
        Debug.Log("Load: " + transform.name);
    }

    protected virtual void OnEnable()
    {
        SetInfor();
    }
    protected abstract void SetInfor();
}
