using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : PISMonoBehaviour
{
    [SerializeField] private EnemyCtrl _enemyCtrl;
    [SerializeField] private MovingPoint _movingPoint;
    [SerializeField] private int _pointIdx = 0;
    [SerializeField] private bool _isFinish;
    
    private void Update()
    {
        Moving();
    }
    protected override void LoadComponent()
    {
        if (_enemyCtrl != null && _movingPoint != null) return;
        _enemyCtrl = GetComponentInParent<EnemyCtrl>();
        _movingPoint = GameObject.Find("MovingPoint").GetComponent<MovingPoint>();
        Debug.Log("Load Component");
    }
    private void Moving()
    {
        ChangeState();
        if (_isFinish) 
        {
            _enemyCtrl.Agent.isStopped = true;
            return;
        }
        MovingNextPoint();
    }
    private void MovingNextPoint()
    {
        Vector3 CurPoint = _movingPoint.ListPoint[_pointIdx];
        float DistancePoint = Vector3.Distance(transform.position, CurPoint);

        if (DistancePoint <= 1f) _pointIdx++;
        if (_pointIdx > _movingPoint.ListPoint.Count - 1) _isFinish = true;
        _enemyCtrl.Agent.SetDestination(CurPoint);
    }
    private void SetState(EnemyState state)
    {
        _enemyCtrl.Anim.SetInteger("State", (int)state);
    }
    private void ChangeState()
    {
        SetState(_enemyCtrl.Agent.isStopped ? EnemyState.Idle : EnemyState.Walk);
    }
}
