using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;
using Etra.StarterAssets.Abilities;

public class FallingPlatform : MonoBehaviour
{
    public bool SquidBlock=false;
    ABILITY_Jump ABILITY_Jump;

    private void Start()
    {
        ABILITY_Jump=FindAnyObjectByType<ABILITY_Jump>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SquidBlock == true)
            {
                ABILITY_Jump.abilityEnabled = false;
                StartCoroutine(SquidBlockFallingDelay());
            }
            else
            {
                this.gameObject.transform.DOPunchRotation(Vector3.down, 2, 33, 88).OnComplete(() =>
                {
                    
                    this.transform.DOMoveY(transform.position.y - 15, 3f);
                }
            );

            }

        }
    }
   
    
  IEnumerator SquidBlockFallingDelay()
    {
        yield return new WaitForSeconds(0.3f);
        this.transform.DOMoveY(transform.position.y - 15, 5f);
    }    
       
       
    
}
