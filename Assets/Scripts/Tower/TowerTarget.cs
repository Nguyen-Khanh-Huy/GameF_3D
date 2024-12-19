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
            foreach (EnemyCtrl enemyIdx in _listEnemyTarget)
            {
                float distance = Vector3.Distance(transform.position, enemyIdx.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    _target = enemyIdx;
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
}
