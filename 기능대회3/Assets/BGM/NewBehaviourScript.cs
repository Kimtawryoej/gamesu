using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public RawImage[] Image;
    public void RightClickButton()
    {
        foreach (var image in Image)
        {
            if (!image.gameObject.activeSelf)
            {
                image.gameObject.SetActive(true);
                break;
            }
        }
    }
    public void LeftClickButton()
    {
        for (int i = Image.Length-1; i >= 0; i--)
        {
            if (Image[i].gameObject.activeSelf)
            {
                Image[i].gameObject.SetActive(false);
                break;
            }
        }
    }

}
