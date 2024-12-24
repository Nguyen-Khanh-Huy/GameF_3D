using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : PISMonoBehaviour
{
    [SerializeField] private ItemPrefab _itemPrefab;
    [SerializeField] private ItemPool _itemPool;

    private int _dropItemAxe = 1;
    private int _dropItemMace = 2;
    private int _dropItemSpear = 3;
    private int _dropItemWand = 4;

    protected override void LoadComponents()
    {
        if (_itemPrefab != null && _itemPool != null) return;
        _itemPrefab = GetComponentInChildren<ItemPrefab>();
        _itemPool = GetComponentInChildren<ItemPool>();
        Debug.Log("Load: " + transform.name);
    }

    public void SpawnItems(EnemyCtrl enemy)
    {
        if (enemy.Hp > 0) return;
        SpawnWeapons(enemy);
        SpawnCoins(enemy);
    }

    public void SpawnCoins(EnemyCtrl enemy)
    {
        Vector3 randomPosDrop = enemy.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f));
        for (int i = 0; i < 5; i++)
        {
            PoolManager<ItemCtrl>.Ins.Spawn(_itemPrefab.GetItemPrefab(typeof(ItemCoin)), randomPosDrop, Quaternion.identity);
        }
    }

    public void SpawnWeapons(EnemyCtrl enemy)
    {
        Vector3 randomPosDrop = enemy.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f));
        int randomRate = Random.Range(1, 10);

        ItemCtrl[] weapons = {
            _itemPrefab.GetItemPrefab(typeof(ItemAxe)),
            _itemPrefab.GetItemPrefab(typeof(ItemMace)),
            _itemPrefab.GetItemPrefab(typeof(ItemSpear)),
            _itemPrefab.GetItemPrefab(typeof(ItemWand)) };

        int[] dropRates = { _dropItemAxe, _dropItemMace, _dropItemSpear, _dropItemWand };

        for (int i = 0; i < weapons.Length; i++)
        {
            if (randomRate <= dropRates[i])
            {
                PoolManager<ItemCtrl>.Ins.Spawn(weapons[i], randomPosDrop, Quaternion.identity);
            }
        }
    }
}
