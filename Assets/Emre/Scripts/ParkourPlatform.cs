using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourPlatform : MonoBehaviour
{

    public float x = 4f;

    public bool LeftRight=true;

    public bool isleft = false;
    public bool isUp= false;

    private void Start()
    {
        if(LeftRight==true)
        {
            if (isleft == true)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
        if(LeftRight == false)
        {
            if (isUp== true) 
            {
                MoveDown();
            }
            else
            {
                MoveUp();
            }
        }

        
        
    }


    public void MoveRight()
    {
        this.gameObject.transform.DOMoveX(4,x).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveLeft();
        });
    }

    public void MoveLeft()
    {
        this.gameObject.transform.DOMoveX(-4, x).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveRight();
        });
    }

    public void MoveUp()
    {
        this.gameObject.transform.DOMoveY(transform.position.y+3, x).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveDown();
        });
    }
    public void MoveDown()
    {
        this.gameObject.transform.DOMoveY(transform.position.y - 3, x).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveUp();
        });
    }
}
