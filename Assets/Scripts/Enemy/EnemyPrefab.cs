using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : PISMonoBehaviour
{
    [SerializeField] private List<EnemyCtrl> _listEnemyPrefabs = new();

    protected override void LoadComponent()
    {
        if (_listEnemyPrefabs.Count == transform.childCount) return;
        foreach (Transform child in transform)
        {
            _listEnemyPrefabs.Add(child.GetComponent<EnemyCtrl>());
        }
        Debug.Log("Load: " + transform.name);
    }
}
