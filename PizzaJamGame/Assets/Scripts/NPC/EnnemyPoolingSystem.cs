using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPoolingSystem : MonoBehaviour
{
    
    public static EnnemyPoolingSystem Instance;

    // Public
    public GameObject EnnemyPrefab;
    public List<GameObject> pooledObjects;

    // Private
    [SerializeField] private int amountToPool;
    


    private void Awake()
    {
        Instance = this;
        Fill(amountToPool);
    }
    

    private void Fill(int n)
    {
        for (int i=0; i < n; i++)
        {
            GameObject obj = Instantiate(EnnemyPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;

    }

    public void Append(int n)
    {
        amountToPool += n;
        Fill(n);
    }


}
