using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand;
}
public class ObjectPool : MonoBehaviour {

    public static ObjectPool instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    public void Init()
    {

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < itemsToPool.Count; i++)
        {
            for (int j = 0; j < itemsToPool[i].amountToPool; j++)
            {
                GameObject obj = Instantiate(itemsToPool[i].objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    //instantiate objects to pool first
    private void Awake()
    {
        instance = this;
        
    }

    public GameObject GetPooledObject(string tag)
    {
        //find inactive objects in pool
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
                return pooledObjects[i];
        }
        for (int i = 0; i < itemsToPool.Count; i++)
        {
            if (itemsToPool[i].objectToPool.tag != tag)
                continue;
            if (itemsToPool[i].shouldExpand)
            {
                GameObject obj = Instantiate(itemsToPool[i].objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                return obj;
            }
        }
        return null;
    }
}
