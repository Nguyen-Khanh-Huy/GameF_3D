using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PoolObj<T> : PISMonoBehaviour where T : PoolObj<T>
{
    public abstract string GetName();
}
