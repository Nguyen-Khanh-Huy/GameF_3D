using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPoint : MonoBehaviour
{
    protected float maxDistance = 100f;
    protected Collider hitObj;
    [SerializeField] private LayerMask layerMask = 1;

    protected virtual void Update()
    {
        Pointing();
    }

    protected virtual void Pointing()
    {
        Vector3 screenCenter = new(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
        {
            transform.position = hit.point;
            hitObj = hit.collider;
        }
    }
}
