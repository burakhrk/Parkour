using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSteel : MonoBehaviour
{

    private void Start()
    {
        MoveRight();
    }


    public void MoveRight()
    {

        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(-100, 90, 0), 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            ResetRotation();
        });

    }

    public void ResetRotation()
    {
        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(-230, 90, 0), 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            ResetRotation2();
        });

    }

    public void ResetRotation2()
    {
        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(-360, 90, 0), 2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveRight();
        });

    }
}
