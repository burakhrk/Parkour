using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForInteratableObj : MonoBehaviour
{

    private Camera cam;

    [SerializeField]private LayerMask layer;

    public GameObject parent;

    void Start()
    {
        cam=Camera.main;
    }

    
    void Update()
    {

            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit,6, layer))
                {
                   hit.collider.GetComponent<Interactable>().Interact();
                  
                }
                   
 
            }

    }
}
