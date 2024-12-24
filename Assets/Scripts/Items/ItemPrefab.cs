using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefab : PISMonoBehaviour
{
    [SerializeField] private List<ItemCtrl> _listItemPrefabs = new();
    protected override void LoadComponents()
    {
        GetItemPrefab(typeof(ItemAxe));
        if (_listItemPrefabs.Count > 0) return;
        _listItemPrefabs.Clear();
        ItemCtrl[] itemPrefabs = Resources.LoadAll<ItemCtrl>("Items");
        foreach (ItemCtrl itemPrefab in itemPrefabs)
        {
            if (itemPrefab != null)
            {
                _listItemPrefabs.Add(itemPrefab);
            }
        }
        Debug.Log("Load: " + transform.name);
    }

    public ItemCtrl GetItemPrefab(Type itemPrefab)
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
