using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class PoolItem
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _amount;

    public int Amount => _amount;
    public GameObject Prefab => _prefab;
}
public class Pool : MonoBehaviour
{
    [SerializeField] private List<PoolItem> _items;
    [SerializeField] protected List<GameObject> _pooledItem;

    public GameObject Get(string tag)
    {
        var filter = _pooledItem.Where(p =>!p.activeInHierarchy && p.tag == tag);
        var index = Random.Range(0, filter.Count());
        GameObject result = filter.ElementAt(index);
        return result;
    }

    public void InitializeTile()
    {
        _pooledItem = new List<GameObject>();

        foreach (PoolItem item in _items)
        {
            for (int i = 0; i < item.Amount; i++)
            {
                GameObject obj = Instantiate(item.Prefab);
                obj.SetActive(false);
                _pooledItem.Add(obj);
            }
        }
    }
}
