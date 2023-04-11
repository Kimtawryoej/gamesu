using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiHover : MonoBehaviour
{
    Animator ani;
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
        Action CardMove1 = () => { Debug.Log("행동1"); };
        Action CardMove2 = () => { Debug.Log("행동2"); };
        Action CardMove3 = () => { Debug.Log("행동3"); };
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
