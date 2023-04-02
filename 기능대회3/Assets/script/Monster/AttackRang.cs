using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRang : MonoBehaviour
{
    public static AttackRang Instance { get; private set; }
    public Material m_Material;
    [SerializeField]
    GameObject Rangposition;
    public LineRenderer lineRenderer;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, Bos.Instance.transform.position);
        lineRenderer.SetPosition(1, Rangposition.transform.position);

        //transform.eulerAngles = Bos.Instance.transform.eulerAngles + new Vector3(0,90,0);
    }
    IEnumerator attack()
    {
        yield return null;
        yield return new WaitForSeconds(3);
        m_Material.color = Color.red;
        yield return new WaitForSeconds(2);
        m_Material.color = Color.blue;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {

        if (m_Material.color == Color.red)
        {
            Debug.Log("¾ß");
            Scrpt.Instance.Attack = 0.1f;
            Scrpt.Instance.HpManager(150);
        }


    }
    private void OnTriggerStay(Collider collision)
    {
        if (m_Material.color == Color.red)
        {
            Debug.Log("¾ß");
            Scrpt.Instance.Attack = 0.1f;
            Scrpt.Instance.HpManager(150);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        Scrpt.Instance.Attack = 1;
    }
}
