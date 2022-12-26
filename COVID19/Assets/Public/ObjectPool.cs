using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class objectpool : MonoSingleton<objectpool>
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
                returnObject = Instantiate(pool.prefab); // 새로 생긴 prefab을 returnObject 에 넣고  딕셔너리에 기존에 생긴 prefab이 아닌 새로 만든 prefab을 넣어준다 
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
