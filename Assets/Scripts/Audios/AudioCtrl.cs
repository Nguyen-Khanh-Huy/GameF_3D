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
    protected abstract void SetInfor();

    protected virtual void OnEnable()
    {
        SetInfor();
        DespawnSFX();
    }

    protected virtual void OnDisable()
    {
        CancelInvoke(nameof(DelayDespawnSFX));
    }

    private void DespawnSFX()
    {
        if (this is AudioMusicGamePlay) return;
        Invoke(nameof(DelayDespawnSFX), 0.5f);
    }

    private void DelayDespawnSFX()
    {
        PoolManager<AudioCtrl>.Ins.Despawn(this);
    }
}
