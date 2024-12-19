using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : PISMonoBehaviour
{
    [SerializeField] private List<EnemyCtrl> _listEnemyPrefabs = new();

    public List<EnemyCtrl> ListEnemyPrefabs { get => _listEnemyPrefabs; }

    protected override void LoadComponent()
    {
        if (_listEnemyPrefabs.Count == transform.childCount) return;
        foreach (Transform child in transform)
        {
            _listEnemyPrefabs.Add(child.GetComponent<EnemyCtrl>());
        }
        Debug.Log("Load: " + transform.name);
    }

    public EnemyCtrl GetRandomPrefab()
    {
        int rand = Random.Range(0, this._listEnemyPrefabs.Count);
        return this._listEnemyPrefabs[rand];
    }
}
