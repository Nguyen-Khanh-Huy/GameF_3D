using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MovingPoint : MonoBehaviour
{
    [SerializeField] private List<Vector3> _listPoint = new List<Vector3>();
    public List<Vector3> ListPoint { get => _listPoint; set => _listPoint = value; }

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
        if (_listPoint.Count > 0 ) return;
        foreach (Transform child in transform)
        {
            _listPoint.Add(child.position);
        }
        Debug.Log("Load Component");
    }
}
