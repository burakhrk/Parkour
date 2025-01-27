using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Etra.StarterAssets.Abilities;

public class Squid5 : MonoBehaviour
{
    [SerializeField] GameObject InfoPanel;
    GameObject cursor;

    ABILITY_CharacterMovement characterMovement;
    ABILITY_CameraMovement cameraMovement;
    ABILITY_Jump jump;


    public Image ImageParent;
    public Image Image;

    private void Start()
    {
        jump=FindFirstObjectByType<ABILITY_Jump>();
       characterMovement=FindFirstObjectByType<ABILITY_CharacterMovement>();
       cameraMovement=FindFirstObjectByType<ABILITY_CameraMovement>();
       
        SetFalseAbilities();
        
        cursor =FindFirstObjectByType<Cursorr>().gameObject;
        Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false);
        StartCoroutine(ChangeColor());
    }

    public void ClosePanel()
    {
        InfoPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);
        SetTrueAbilities();
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(1.5f);

        ImageParent.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.green;
        ImageParent.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f,2,1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.red;
        ImageParent.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.green;
        ImageParent.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.red;
        ImageParent.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.green;
        ImageParent.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        ClosePanel();

    }

    void SetTrueAbilities()
    {
        characterMovement.abilityEnabled = true;
        cameraMovement.abilityEnabled = true;
        jump.abilityEnabled = true;
    }
    void SetFalseAbilities()
    {
        characterMovement.abilityEnabled = false;
        cameraMovement.abilityEnabled = false;
        jump.abilityEnabled = false;
    }
}
