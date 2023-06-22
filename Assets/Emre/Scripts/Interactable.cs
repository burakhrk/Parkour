using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public int i;

    public GameObject platform;
    
    PlatformMover platformMover;

    private void Start()
    {
        platformMover = FindObjectOfType<PlatformMover>();
    }


    public void Interact()
     {
        InteractableObj1();
        
     }

   

    public void InteractableObj1()
    {
       if(i == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90,-90,0));
            platformMover.PlatformMove();
            i=2;
        }
       
    }

   
    

    


}
