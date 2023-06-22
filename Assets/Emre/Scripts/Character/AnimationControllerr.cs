using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerr : MonoBehaviour
{
     Animator controllerr;


    // Update is called once per frame

    private void Start()
    {
        controllerr=GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            controllerr.SetBool("Hit", true);
            StartCoroutine(ResetAnim());
        }
    }


    IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(0.1f);
        controllerr.SetBool("Hit", false);
    }
}
