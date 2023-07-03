using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Etra.StarterAssets.Abilities;

public class CloseButton : MonoBehaviour
{
    [SerializeField] GameObject InfoPanel;
    GameObject cursor;

    ABILITY_CharacterMovement characterMovement;
    ABILITY_CameraMovement cameraMovement;
    ABILITY_Jump jump;

    public Image Image;

    private void Start()
    {
        jump=FindObjectOfType<ABILITY_Jump>();
       characterMovement=FindObjectOfType<ABILITY_CharacterMovement>();
       cameraMovement=FindObjectOfType<ABILITY_CameraMovement>();
       
        SetFalseAbilities();
        
        cursor =FindObjectOfType<Cursorr>().gameObject;
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
        yield return new WaitForSeconds(0.3f);

        Image.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.green;
        Image.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f,2,1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.red;
        Image.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(1f);
        Image.color = Color.red;
        Image.rectTransform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 1f, 2, 1);
        yield return new WaitForSeconds(2f);
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
