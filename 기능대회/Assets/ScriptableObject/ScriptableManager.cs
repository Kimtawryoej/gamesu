using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewData", menuName = "Data/NewData")]
public class ScriptableManager : ScriptableObject
// Start is called before the first frame update
{
    public SpriteRenderer[] Sprites = new SpriteRenderer[2];
    public Scene currentScene;
    public List<GameObject> gobject = new List<GameObject>();
    public void UpdateGameObjectList()
    {
        gobject.Clear();
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject rootObject in rootObjects)
        {
            gobject .AddRange(rootObject.GetComponentsInChildren<Transform>().Select(t => t.gameObject));
        }
    }
    public bool Bool = false;
}
