using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : PISMonoBehaviour
{
    [SerializeField] private List<EnemyCtrl> _listEnemyPrefabs = new();

    protected override void LoadComponents()
    {
        if (_listEnemyPrefabs.Count > 0) return;
        _listEnemyPrefabs.Clear();
        EnemyCtrl[] enemyPrefabs = Resources.LoadAll<EnemyCtrl>("Enemies");
        foreach (EnemyCtrl enemyPrefab in enemyPrefabs)
        {
            if (enemyPrefab != null)
            {
                _listEnemyPrefabs.Add(enemyPrefab);
            }
        }

        //if (_listEnemyPrefabs.Count == transform.childCount) return;
        //foreach (Transform child in transform)
        //{
        //    _listEnemyPrefabs.Add(child.GetComponent<EnemyCtrl>());
        //}

        Debug.Log("Load: " + transform.name);
    }

    public EnemyCtrl GetRandomEnemyPrefab()
    {
        int rand = Random.Range(0, this._listEnemyPrefabs.Count);
        return this._listEnemyPrefabs[rand];
    }
}
