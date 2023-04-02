using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strttackj : SingleTone<Strttackj>
{
    public LineRenderer lineRenderer;
    public Material m_Material;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Line(Vector3 Myposition,Vector3 targetPosition)
    {
        lineRenderer.SetPosition(0, Myposition);
        lineRenderer.SetPosition(1, targetPosition);
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
}
