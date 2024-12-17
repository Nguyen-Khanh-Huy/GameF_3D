using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MovingPoint : MonoBehaviour
{
    [SerializeField] private List<Vector3> _listPoint = new();
    public List<Vector3> ListPoint { get => _listPoint; }

    private void Start()
    {
        LoadComponent();
    }
    private void Reset()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        if (_listPoint.Count == transform.childCount) return;
        foreach (Transform child in transform)
        {
            _listPoint.Add(child.position);
        }
        Debug.Log("Load: " + transform.name);
    }
}
