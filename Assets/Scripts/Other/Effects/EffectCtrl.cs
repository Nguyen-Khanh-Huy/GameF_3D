using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectCtrl : PoolObj<EffectCtrl>
{
    private void OnEnable()
    {
        Invoke(nameof(DespawnEffect), 0.5f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DespawnEffect));
    }

    private void DespawnEffect()
    {
        PoolManager<EffectCtrl>.Ins.Despawn(this);
    }

    protected override void LoadComponents()
    {
        // Nothing
    }
}
