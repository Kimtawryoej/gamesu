using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public List<Slider> slider;
    public List<Text> text;
    public List<Text> ItemText;
    public GameObject parent;
    void Start()
    {
        parent.SetActive(false);
        StartCoroutine(SaveCheck());

    }

    // Update is called once per frame
    void Update()
    {
        slider[0].value = Player.Instance.Hp / 150;
        slider[1].value = Player.Instance.Fuel / 60;
        slider[2].value = Skill.Instance.time / 10;
        slider[3].value = Skill.Instance.time2 / 15;
    }
    IEnumerator SaveCheck()
    {
        while (true)
        {
            ItemText.Add(text[1]);
            yield return new WaitUntil(()=> Item.Instance.PreITEMS.Count > 0);
            yield return new WaitForSeconds(1* Item.Instance.PreITEMS.Count+1);
            for (int i = 1; i < Item.Instance.PreITEMS.Count; i++)
            {
                ItemText.Add(Instantiate(text[1], text[1].transform.position + new Vector3(0, 150*i, 0), Quaternion.identity));
                
            }
            parent.SetActive(true);
            for (int i = 0; i < ItemText.Count; i++)
            {
                ItemText[i].transform.SetParent(parent.transform);
                ItemText[i].text = Item.Instance.PreITEMS[i] + "¹ßµ¿";
            }
            yield return new WaitForSeconds(2);
            for (int i = 1; i < ItemText.Count; i++)
            {
                Destroy(ItemText[i].gameObject);
            }
            Item.Instance.PreITEMS.Clear();
            ItemText.Clear();
            parent.SetActive(false);
        }
    }
}
