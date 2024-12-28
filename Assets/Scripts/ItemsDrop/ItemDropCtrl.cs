using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class ItemDropCtrl : PoolObj<ItemDropCtrl>
{
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        ItemFalling();
    }

    protected override void LoadComponents()
    {
        if (_rb != null) return;
        _rb = GetComponent<Rigidbody>();
        Debug.Log("Load: " + transform.name);
    }

    private void ItemFalling()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        _rb.AddForce(randomDirection * 3f, ForceMode.Impulse);
    }

    private void OnEnable()
    {
        Invoke(nameof(DespawnItem), 5f);
    }

    private void DespawnItem()
    {
        PoolManager<ItemDropCtrl>.Ins.Despawn(this);
    }
}
