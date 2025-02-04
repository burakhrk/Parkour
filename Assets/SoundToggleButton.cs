 using UnityEngine;
using UnityEngine.UI;
public class SoundToggleButton : MonoBehaviour
{
    [SerializeField] Image butonImage;
    [SerializeField] Sprite soundOnImage,SoundOffImage;

    private void Start()
    {

        if( SoundManager.Instance.isMuted)
        {
            CloseSoundButtonImage();
        }
        else
        {
            ActivateSoundButtonImage();
        }
    } 
    public void SoundToggleClicked()
    {
        SoundManager.Instance.ToggleMute();
        if (SoundManager.Instance.isMuted)
        {
            CloseSoundButtonImage();
        }
        else
        {
            ActivateSoundButtonImage();
        }
    }
     void ActivateSoundButtonImage()
    {
        butonImage.sprite=soundOnImage;
    }
     void CloseSoundButtonImage()
    {
        butonImage.sprite = SoundOffImage;

    }
    public void VisibleButton()
    {
        butonImage.transform.parent.gameObject.SetActive(true);
    }
    public void DisappearButton()
    {
        butonImage.transform.parent.gameObject.SetActive(false);

    }
}
