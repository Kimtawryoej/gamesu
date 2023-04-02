using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    public Animator animaton;
    public static Camera Instance;
    // Update is called once per frame
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(Enumerator());
        animaton = GetComponent<Animator>();
        gameObject.GetComponent<Animator>().enabled = false;
    }
    IEnumerator Enumerator()
    {
        yield return null;
        yield return new WaitUntil(() => Bos.Instance.gameObject.activeSelf);
        camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        Scrpt.Instance.transform.position = new Vector3(-0.71f, -17.28f, -16.49f);
        yield return null;
        yield return new WaitUntil(() => gameObject.GetComponent<Animator>().enabled);
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Animator>().enabled = false;
        camera.transform.rotation = Quaternion.Euler(21.899f, 0, 0);
        Scrpt.Instance.transform.position = new Vector3(0, 0, 0);
        Scrpt.Instance.gameObject.GetComponent<Animator>().enabled = true;
    }
}
