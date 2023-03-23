using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.ParticleSystem;


public class MainUi : MonoBehaviour
{
    public GameObject partical;
    Loadingscene load = new Loadingscene();
    Animator animator;
    public void OnclickButton()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name;
        if (ButtonName == "Start")
        {
            animator.SetBool("Destory", true);
            StartCoroutine(ani());
        }
        if (ButtonName == "Ranking")
            SceneManager.LoadScene("Ranking");
    }
    IEnumerator Partical()
    {
        Instantiate(partical, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        yield return new WaitForSeconds(0.1f);
        load.Scene("SampleScene");
    }
    IEnumerator ani()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("MainDestory") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        MainPlayer.Instance.animator.SetBool("연출", true);
        MainBoss.Instance.animator.SetBool("Move", true);
        yield return new WaitUntil(() => MainPlayer.Instance.animator.GetCurrentAnimatorStateInfo(1).IsName("연출") && MainPlayer.Instance.animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 1f);
        StartCoroutine(Partical());
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}
