using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolItem : MonoBehaviour
{
    public static ObjectPoolItem ObjectPoolItemInstance;
    
    [SerializeField] private List<GameObject> _listObjectPool;
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private int _objectPoolSize;

    private void Awake()
    {
        ObjectPoolItemInstance = this;
    }

    private void Start()
    {
        _listObjectPool = new List<GameObject>();
        for (int i = 0; i < _objectPoolSize; i++)
        {
            GameObject gameObject = Instantiate(_objectPrefab);
            gameObject.SetActive(false);
            _listObjectPool.Add(gameObject);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < _listObjectPool.Count; i++)
        {
            if (!_listObjectPool[i].activeInHierarchy)
            {
                return _listObjectPool[i];
            }
        }

        return null;
    }
}
