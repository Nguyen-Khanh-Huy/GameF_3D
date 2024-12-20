using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PISMonoBehaviour : MonoBehaviour
{
    protected virtual void Start()
    {
        LoadComponent();
    }

    protected virtual void Reset()
    {
        LoadComponent();
    }

    protected abstract void LoadComponent();
}
