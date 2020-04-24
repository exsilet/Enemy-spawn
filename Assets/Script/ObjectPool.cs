using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _contains;
    [SerializeField] private int _capasity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capasity; i++)
        {
            GameObject spawned = Instantiate(prefab, _contains.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetOject (out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }
}
