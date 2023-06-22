using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public int i;

    public GameObject willBeClosedObj;
     public void Interact()
     {
        InteractableObj1(); 
        InteractableObj2(); 
      
     }

   

    public void InteractableObj1()
    {
        if (i == 1)
        {
            Debug.Log("1111111");
            willBeClosedObj.SetActive(false);
        }
    }

    public void InteractableObj2()
    {
        if (i == 2)
        {
            Debug.Log("2222222");
            willBeClosedObj.SetActive(false);
        }
    }

}
