using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : PoolObj<BulletCtrl>
{
    [SerializeField] private float _speedBullet = 100;

    [SerializeField] private ItemCtrl _itemCoin;
    [SerializeField] private ItemCtrl _itemAxe;
    [SerializeField] private ItemCtrl _itemMace;
    [SerializeField] private ItemCtrl _itemSpear;
    [SerializeField] private ItemCtrl _itemWand;

    private int _dropItemAxe = 1;
    private int _dropItemMace = 2;
    private int _dropItemSpear = 3;
    private int _dropItemWand = 4;

    private void Update()
    {
        transform.Translate(this._speedBullet * Time.deltaTime * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyCtrl enemy = other.GetComponentInParent<EnemyCtrl>();
        if (enemy != null)
        {
            DespawnBullet();
            UpdateHpEnemy(enemy);
            SpawnItem(enemy);
        }
    }

    protected override void LoadComponents()
    {
        if (_itemCoin != null && _itemAxe != null && _itemMace != null && _itemSpear != null && _itemWand != null) return;
        _itemCoin = Resources.Load<ItemCtrl>("Items/ItemCoin");
        _itemAxe = Resources.Load<ItemCtrl>("Items/ItemAxe");
        _itemMace = Resources.Load<ItemCtrl>("Items/ItemMace");
        _itemSpear = Resources.Load<ItemCtrl>("Items/ItemSpear");
        _itemWand = Resources.Load<ItemCtrl>("Items/ItemWand");
        Debug.Log("Load: " + transform.name);
    }

    private void OnEnable()
    {
        Invoke(nameof(DespawnBullet), 3f);
    }

    private void DespawnBullet()
    {
        PoolManager<BulletCtrl>.Ins.Despawn(this);
    }

    private void UpdateHpEnemy(EnemyCtrl enemy)
    {
        if (enemy.Hp <= 0) return;
        enemy.Hp--;
    }

    private void SpawnItem(EnemyCtrl enemy)
    {
        if (enemy.Hp > 0) return;
        SpawnWeapons(enemy);
        SpawnCoin(enemy);
    }

    private void SpawnCoin(EnemyCtrl enemy)
    {
        Vector3 randomPosDrop = enemy.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0.5f, Random.Range(-0.5f, 0.5f));
        for (int i = 0; i < 5; i++)
        {
            PoolManager<ItemCtrl>.Ins.Spawn(_itemCoin, randomPosDrop, Quaternion.identity);
        }
    }

    private void SpawnWeapons(EnemyCtrl enemy)
    {
        Vector3 randomPosDrop = enemy.transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f));
        int randomRate = Random.Range(1, 10);

        ItemCtrl[] weapons = { _itemAxe, _itemMace, _itemSpear, _itemWand };
        int[] dropRates = { _dropItemAxe, _dropItemMace, _dropItemSpear, _dropItemWand };

        for (int i = 0; i < weapons.Length; i++)
        {
            if (randomRate <= dropRates[i])
            {
                PoolManager<ItemCtrl>.Ins.Spawn(weapons[i], randomPosDrop, Quaternion.identity);
            }
        }
    }

    public override string GetName()
    {
        return "Bullet";
    }
}
