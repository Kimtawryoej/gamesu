using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public List<GameObject> TargetPosition = new List<GameObject>();
    //public List<GameObject> TargetPosition2 { 

    //    set {
    //        for (int i = 0; i < value.Count; i++)
    //            TargetPosition.Add (value [i]);
    //    } 
    //}
    int targetCount = 0;
    void Start()
    {
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Move()
    {
        yield return new WaitUntil(() => TimeBar.Instance.TimeSliderSet != 0);
        Vector3 position = transform.position;
        while (true)
        {
            Vector3 target = TargetPosition[targetCount].transform.position;
            transform.position = Vector3.Lerp(position, target, TimeBar.Instance.TimeSliderSet);
            yield return null;
        }
    }
}
