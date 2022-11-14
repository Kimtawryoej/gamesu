using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterObjectPool : MonsterMonoSingleton<MonsterObjectPool>
{
    public class Pool
    {
         public GameObject prefab;
        public Pool(GameObject _prefab)
        {
            prefab = _prefab;
        }
        public Stack<GameObject> pool = new Stack<GameObject>();
    }
    Dictionary<GameObject, Pool> pools = new Dictionary<GameObject, Pool>();
    public GameObject GetObject(GameObject prefab,Vector3 position = default, Quaternion quaternion = default)
    {
        GameObject returngameobject = null;
        if(!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new Pool(prefab));
        }
        Pool pool = pools[prefab];
        
        if(pool.pool.Count > 0)
        {
            returngameobject = pool.pool.Pop();
            returngameobject.SetActive(true);
        }
        else
        {
            returngameobject = Instantiate(pool.prefab);
            pools.Add(returngameobject, pool);
        }
        returngameobject.transform.SetParent(null);
        returngameobject.transform.SetPositionAndRotation(position,quaternion);
        return returngameobject;
    }
    public void  Disappear(GameObject Object)
    {
        Object.SetActive(false);
        Object.transform.SetParent(transform);
        pools[Object].pool.Push(Object);
    }

}
