using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class objectpool : Connection<objectpool>
{
    public class pool
    {
        public GameObject prefab;
        public Stack<GameObject> ObjectStack = new Stack<GameObject>();
        public pool(GameObject _prefab)
        {
            prefab = _prefab;
        }
    }
    Dictionary<GameObject, pool> pools = new  Dictionary<GameObject, pool>();
    public GameObject creat(GameObject prefab,Vector3 position)
    {
        GameObject gameObject;
        if (!pools.ContainsKey(prefab))
        {
            pools.Add(prefab, new pool(prefab));
        }
        pool Pool = pools[prefab];
        if(Pool.ObjectStack.Count != 0)
        {
            gameObject = Pool.ObjectStack.Pop();
            gameObject.SetActive(true);
        }
        else
        {
            gameObject = Instantiate(Pool.prefab);
            pools.Add(gameObject, Pool); // 이코드 왜 있는지 꼭알아야함
        }
        gameObject.transform.position = position;
        return gameObject;
    }

    public void creat2(GameObject game)
    {
        game.SetActive(false);
        game.transform.SetParent(transform);
        pools[game].ObjectStack.Push(game);
    }
}
