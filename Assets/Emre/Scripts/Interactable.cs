using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public int i;

    
    
    PlatformMover platformMover;

    private void Start()
    {
        platformMover = FindObjectOfType<PlatformMover>();
    }


    public void Interact()
     {
        InteractableObj1();
        InteractableObj2();
        InteractableObj3();
        
     }

   

    public void InteractableObj1()
    {
       if(i == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90,-90,0));
            platformMover.PlatformMove1();
       
            Debug.Log("bir" +i);
        }
       
    }

    public void InteractableObj2()
    {
      
        if (i == 2)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, -90, 0));
            platformMover.PlatformMove2();
           
            Debug.Log("iki" + i);

        }

    }

    public void InteractableObj3()
    {
       
        if (i == 3)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, -90, 0));
            platformMover.PlatformMove3();
           
            Debug.Log("ьз" + i);

        }

    }




}
