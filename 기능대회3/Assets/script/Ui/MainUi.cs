using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{
   public void StartClick()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void RankingClick()
    {
        SceneManager.LoadScene("Ranking");
    }
    public void explanation()
    {
        SceneManager.LoadScene("explanation");
    }
}
