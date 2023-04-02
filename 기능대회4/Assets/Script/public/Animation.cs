using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : SingleTone<Animation>
{
    public Animator animator;
    public IEnumerator AniPlay(string aniName ,float count)
    {
        animator.SetBool(aniName, true);
        yield return new WaitForSeconds(count);
        animator.SetBool(aniName, false);
    }
}
