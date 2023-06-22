using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMover : MonoBehaviour
{
    

    public void PlatformMove()
    {
        this.transform.DOMoveY(transform.position.y-5,2f);
    }
}
