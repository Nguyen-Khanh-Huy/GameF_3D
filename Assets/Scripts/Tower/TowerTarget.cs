using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    [SerializeField] private EnemyCtrl _target;
    [SerializeField] private List<EnemyCtrl> _listEnemyTarget;
    public EnemyCtrl Target { get => _target;}
    public List<EnemyCtrl> ListEnemyTarget { get => _listEnemyTarget; set => _listEnemyTarget = value; }

    private void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null && !_listEnemyTarget.Contains(enemy))
        {
            _listEnemyTarget.Add(enemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            float minDistance = Mathf.Infinity;
            foreach (EnemyCtrl enemyInList in _listEnemyTarget)
            {
                float distance = Vector3.Distance(transform.position, enemyInList.transform.position);
                if (minDistance > distance)
                {
                    minDistance = distance;
                    _target = enemyInList;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            _listEnemyTarget.Remove(enemy);
        }

        if (_listEnemyTarget.Count == 0)
        {
            _target = null;
        }
    }

    public void RemoveListTarget(EnemyCtrl enemy)
    {
        _listEnemyTarget.Remove(enemy);
    }
}
