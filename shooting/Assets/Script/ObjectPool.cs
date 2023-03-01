using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : Connection<ObjectPool>
{
    public class Pool
    {
        public GameObject prefab;
        public Pool(GameObject _prefab)
        {
            prefab = _prefab;
        }
        public Stack<GameObject> poolStack = new Stack<GameObject>();
    }
    Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();

    public GameObject objectpool(Vector2 position, GameObject prefab, Quaternion elur)
    {
        GameObject gameObject;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new Pool(prefab));
        }
        Pool pool = pools[prefab];
        if(pool.poolStack.Count >0)
        {
          gameObject = pool.poolStack.Pop();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject = Instantiate(pool.prefab);
            Debug.Log("ww");
            gameObject.SetActive(true);
            pools.Add(gameObject,pool);
        }
        gameObject.transform.SetPositionAndRotation(position, elur);
        return gameObject;
    }

    public void Return(GameObject gameObject)
    {

        gameObject.SetActive(false);
        gameObject.transform.SetParent(transform);
        pools[gameObject].poolStack.Push(gameObject);
    }
}
