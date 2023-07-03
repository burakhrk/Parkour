using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Etra.StarterAssets.Input;

public class Platform : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = FindObjectOfType<StarterAssetsInputs>().gameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
       
            player.transform.parent = transform;
        
    }

    private void OnTriggerExit(Collider other)
    {
            player.transform.parent = null;

    }


}
