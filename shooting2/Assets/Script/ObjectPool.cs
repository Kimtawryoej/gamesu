using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Connection<ObjectPool>
{
    // Start is called before the first frame update
    public class Pool
    {
        public GameObject prefab;
        public Pool(GameObject _Prefab)
        {
            prefab = _Prefab;
        }
        public Stack<GameObject> poolStack = new Stack<GameObject>();
    }
    Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();
    // Update is called once per frame
    public GameObject objectpool(GameObject prefab, Vector3 position, Quaternion elur)
    {
        GameObject gameObject;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new Pool(prefab));
        }
        Pool pool = pools[prefab];
        if (pool.poolStack.Count > 0)
        {
            gameObject = pool.poolStack.Pop();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject = Instantiate(pool.prefab);
            gameObject.SetActive(true);
            pools.Add(gameObject, pool);
        }
        gameObject.transform.SetPositionAndRotation(position, elur);
        return gameObject;
    }

    public void RETURN(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(transform);
        pools[gameObject].poolStack.Push(gameObject);
    }
}
