using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMover : MonoBehaviour
{
    public int PlatformNumber;




    public void PlatformMove1()
    {
        if (PlatformNumber == 1)
        {
            this.transform.DOMoveY(transform.position.y - 5, 2f);
        }
    }
    public void PlatformMove2()
    {
        if (PlatformNumber == 2)
        {
            this.transform.DOMoveY(transform.position.y - 5, 2f);
        }
    }
    public void PlatformMove3()
    {
        if (PlatformNumber == 3)
        {
            this.transform.DOMoveY(transform.position.y-5,2f);
        }
        
    }
}
