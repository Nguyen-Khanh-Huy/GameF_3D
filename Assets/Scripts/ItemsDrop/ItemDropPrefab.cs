using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropPrefab : PISMonoBehaviour
{
    [SerializeField] private List<ItemDropCtrl> _listItemPrefabs = new();
    protected override void LoadComponents()
    {
        GetItemPrefab(typeof(ItemDropAxe));
        if (_listItemPrefabs.Count > 0) return;
        _listItemPrefabs.Clear();
        ItemDropCtrl[] itemPrefabs = Resources.LoadAll<ItemDropCtrl>("ItemsDrop");
        foreach (ItemDropCtrl itemPrefab in itemPrefabs)
        {
            if (itemPrefab != null)
            {
                _listItemPrefabs.Add(itemPrefab);
            }
        }
        Debug.Log("Load: " + transform.name);
    }

    public ItemDropCtrl GetItemPrefab(Type itemPrefab)
    {
        foreach (var inList in _listItemPrefabs)
        {
            if (itemPrefab.IsAssignableFrom(inList.GetType()))
            {
                return inList;
            }
        }
        return null;
    }
}
