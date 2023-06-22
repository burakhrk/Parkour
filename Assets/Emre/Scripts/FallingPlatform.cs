using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;

public class FallingPlatform : MonoBehaviour
{


  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.transform.DOPunchRotation(Vector3.down, 2, 33,88 ).OnComplete(() =>
            {
            Debug.Log("asdasd1231f");
            this.transform.DOMoveY(transform.position.y - 15, 3f);
            }
            );

        }
    }
   
    
  

    
       
       
    
}
