using UnityEngine.UI;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] Button soundToggleButton;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSoundIcon();
    }

    void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }

    void UpdateSoundIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            soundToggleButton.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            AudioListener.volume = 0;
            soundToggleButton.GetComponent<Image>().sprite = soundOff;
        }
    }

    public void PauseMusic()
    {
        ToggleSound();
        UpdateSoundIcon();
    }
}
