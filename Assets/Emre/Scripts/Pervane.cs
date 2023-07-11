using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pervane : MonoBehaviour
{
    



    private void Start()
    {
        MoveRight();
    }


    public void MoveRight()
    {
    
            this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(0,100,0),2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                ResetRotation();
            });
        
    }

    public void ResetRotation()
    {
        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(0, 230, 0), 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            ResetRotation2();
        });

    }

    public void ResetRotation2()
    {
        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(0, 360, 0), 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveRight();
        });

    }

}
