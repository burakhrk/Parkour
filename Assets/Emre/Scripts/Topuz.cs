using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topuz : MonoBehaviour
{

    private void Start()
    {
        MoveRight();
    }


    public void MoveRight()
    {

        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(0, 0, 50), 1.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            ResetRotation();
        });

    }

    public void ResetRotation()
    {
        this.gameObject.transform.DORotateQuaternion(Quaternion.Euler(0, 0, -50), 1.2f).SetEase(Ease.Linear).OnComplete(() =>
        {
            MoveRight();
        });

    }

}
