using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoSingleton<ObjectPool>
{
 
    
    public class Pool
    {
        public GameObject prefab { get; private set; }
        public Stack<GameObject> poolStack = new Stack<GameObject>();
       

        public Pool(GameObject _prefab) 
        {
            prefab = _prefab;
        }
        
    }

   
    private Dictionary<GameObject, Pool> poolDictionary = new Dictionary<GameObject, Pool>();


    public GameObject GetObject(GameObject prefab, Vector3 position = default, Quaternion rotation = default)
    {
        GameObject returnObject;
        if (!poolDictionary.ContainsKey(prefab))
        {

            poolDictionary.Add(prefab, new Pool(prefab));
        }

       
            Pool pool = poolDictionary[prefab];

            if (pool.poolStack.Count > 0)
            {
                returnObject = pool.poolStack.Pop();
                returnObject.SetActive(true);

            }
            else
            {
                returnObject = Instantiate(pool.prefab);
                poolDictionary.Add(returnObject, pool);
            }
            returnObject.transform.SetPositionAndRotation(position, rotation);
            return returnObject;
        


    }
    

    
        public void ReturnObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
            gameObject.transform.SetParent(transform);
            poolDictionary[gameObject].poolStack.Push(gameObject);
        }

   

}
