using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiHover : MonoBehaviour
{
    Animator ani;
    [SerializeField]
    List<GameObject> ACTION = new List<GameObject>();
    PointerEventData eventData = new PointerEventData(EventSystem.current);
    List<RaycastResult> results = new List<RaycastResult>();
    [SerializeField]
    GameObject cardHap;
    public GameObject[] ActionCard;
    int SavePoint;
    Dictionary<string, Action> Card = new Dictionary<string, Action>();
    public void  ClickCard()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        foreach(var a in Card)
        {
            if(clickObject.name == a.Key)
            {
                a.Value();
            }
        }
    }
    private void Start()
    {
        ani = GetComponent<Animator>();
        Action CardMove1 = () => { Instantiate(ACTION[0],new Vector3(0,0,0),Quaternion.identity); };
        Action CardMove2 = () => { Instantiate(ACTION[1],new Vector3(0, 0, 0), Quaternion.identity); };
        Action CardMove3 = () => { Instantiate(ACTION[2],new Vector3(0, 0, 0), Quaternion.identity); };
        Card = new Dictionary<string, Action>
        {
            {"ActionCard",CardMove1},
            {"ActionCard (1)",CardMove2},
            {"ActionCard (2)",CardMove3},
        };
    }
    private void Update()
    {



        eventData.position = Input.mousePosition;
        EventSystem.current.RaycastAll(eventData, results);
        foreach (RaycastResult r in results)
        {
            GameObject CheckgameObject = r.gameObject;
            for (int i = 0; i < ActionCard.Length; i++)
            {
                if (CheckgameObject == ActionCard[i])
                {
                    ActionCard[i].gameObject.transform.localScale = new Vector3(2, 2, 2);
                    SavePoint = i;
                }
                else
                    ActionCard[i].gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            

        }
        if (results.Count == 0)
        {
            ActionCard[SavePoint].gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
