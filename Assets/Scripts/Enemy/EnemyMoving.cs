using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : PISMonoBehaviour
{
    [SerializeField] private EnemyCtrl _enemyCtrl;
    [SerializeField] private int _pointIdx = 0;
    [SerializeField] private bool _isFinish;

    public int PointIdx { get => _pointIdx; set => _pointIdx = value; }

    private void Update()
    {
        Moving();
    }

    protected override void LoadComponents()
    {
        Debug.Log(_enemyCtrl.MovingPoint.ListPoint.Count);
        if (_enemyCtrl != null) return;
        _enemyCtrl = GetComponentInParent<EnemyCtrl>();
        Debug.Log("Load: " + transform.name);
    }

    private void Moving()
    {
        ChangeState();
        MovingNextPoint();
    }

    private void MovingNextPoint()
    {
        if (_pointIdx >= _enemyCtrl.MovingPoint.ListPoint.Count)
        {
            _isFinish = true;
            return;
        }
        Vector3 CurPoint = _enemyCtrl.MovingPoint.ListPoint[_pointIdx];
        float DistancePoint = Vector3.Distance(transform.position, CurPoint);
        if (DistancePoint <= 1f) _pointIdx++;
        _enemyCtrl.Agent.SetDestination(CurPoint);
    }

    private void SetState(EnemyState state)
    {
        _enemyCtrl.Anim.SetInteger("State", (int)state);
    }

    private void ChangeState()
    {
        if (_isFinish)
        {
            SetState(EnemyState.Idle);
            _enemyCtrl.Agent.isStopped = true;
            return;
        }

        if (_enemyCtrl.Hp > 0)
        {
            SetState(EnemyState.Walk);
            _enemyCtrl.Agent.isStopped = false;
        }
        else
        {
            SetState(EnemyState.Die);
            _enemyCtrl.Agent.isStopped = true;
        }
    }
}
