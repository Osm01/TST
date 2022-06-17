using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void PlayButton()
    {
        StartCoroutine(TimeAnimation());
    }
    IEnumerator TimeAnimation()
    {
        animator.SetBool("Waving", true);
        yield return new WaitForSeconds(2);
        animator.SetBool("Waving", false);
    }
}
