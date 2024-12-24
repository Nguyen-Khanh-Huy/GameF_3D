using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MovingPoints : PISMonoBehaviour
{
    [SerializeField] private List<Vector3> _listMovingPoints = new();
    public List<Vector3> ListMovingPoints { get => _listMovingPoints; }

    protected override void LoadComponents()
    {
        if (_listMovingPoints.Count == transform.childCount) return;
        foreach (Transform child in transform)
        {
            _listMovingPoints.Add(child.position);
        }
        Debug.Log("Load: " + transform.name);
    }
}
