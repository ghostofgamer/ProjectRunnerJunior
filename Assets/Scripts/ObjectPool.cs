using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    [SerializeField] protected SpeedTimer _speedTimer;
    
    protected List<GameObject> _pool = new List<GameObject>();
    protected List<GameObject> _poolCoin = new List<GameObject>();
    protected List<GameObject> _poolHouse = new List<GameObject>();
    protected List<GameObject> _poolYacht = new List<GameObject>();
    protected List<GameObject> _poolPier = new List<GameObject>();
    protected List<GameObject> _poolCharacters = new List<GameObject>();
    protected List<GameObject> _poolPalms = new List<GameObject>();


    protected void Initialize(GameObject[] prefab, List<GameObject> list)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefab.Length);
            GameObject spawned = Instantiate(prefab[randomIndex], _container.transform);
            spawned.SetActive(false);
            spawned.GetComponent<EnemyMover>().Init(_speedTimer);
            list.Add(spawned);
        }
    }

    protected void Initialize(GameObject prefab, List<GameObject> list)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            spawned.GetComponent<EnemyMover>().Init(_speedTimer);
            list.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result, List<GameObject> list)
    {
        var filteredEnemy = list.Where(p => p.activeSelf == false);
        var index = Random.Range(0, filteredEnemy.Count());
        result = filteredEnemy.ElementAt(index);
        return result != null;

        //result = list.FirstOrDefault(p => p.activeSelf == false);
        //return result != null;
    }
}
