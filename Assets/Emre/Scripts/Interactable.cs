using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public int i;

    public bool workOnce = false;
    
   [SerializeField] PlatformMover platformMover;
    bool asd = false;
   

    public void Interact()
    { 
        InteractableObj1();
    }

   

    public void InteractableObj1()
    {
        if(workOnce)
        {
            if (asd)
            {
                return;
            }
            if (i == 1)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, -90, 0));
                platformMover.PlatformMove();

                Debug.Log("1");
                asd = true ;
            } 
        }
        else
        {
            if (i == 1)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, -90, 0));
                platformMover.PlatformMove();

                Debug.Log("1");
            }
        } 
    } 
}
