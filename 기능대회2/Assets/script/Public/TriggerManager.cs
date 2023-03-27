using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : SingleTone<TriggerManager>
{
    public GameObject g;
    public Table table;
    public static TriggerManager Instance;
    Dictionary<string,GameObject> choice = new Dictionary<string, GameObject> ();
    public GameObject partical;
    public Monster mons;
    private void Start()
    {
        Instance = this;
        table.scroe = 0;
        table.Name = "";
        table.Time = 0;
        //choice = new Dictionary<string, GameObject>
        //{
        //    {"Monter",mons.gameObject}
        //};
    }
    //public  string[] Tag = new string[] {"Monster","Boss","Meteor"};
   
}
