using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    class Pool
    {
       public GameObject prefab;
        public Stack<GameObject> stack  = new Stack<GameObject>();
        public  Pool(GameObject _prefab)
        {
            prefab = _prefab;
        }
    }
    Dictionary<GameObject,Pool> PoolDicionary = new Dictionary<GameObject, Pool> ();

    public GameObject Pool2(GameObject prefab, Vector3 position = default , Quaternion rotation = default)
    {
        GameObject Same;
        if(!PoolDicionary.ContainsKey(prefab))
        {
            PoolDicionary.Add(prefab, new Pool (prefab));
        }
        Pool pool = PoolDicionary[prefab];
        if(pool.stack.Count != 0 )
        {
           Same =  pool.stack.Pop();
            Same.SetActive(true);
        }
        else
        {
            Same = Instantiate(pool.prefab);
           
        }
        Same.transform.SetPositionAndRotation(position,rotation);
        return Same;
    }

    public void  return2(GameObject gameObject)
    {
        gameObject.SetActive(false);
        transform.SetParent(transform);
        PoolDicionary[gameObject].stack.Push(gameObject);
    }


}
