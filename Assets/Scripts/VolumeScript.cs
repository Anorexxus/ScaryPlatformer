using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public Scrollbar volumeScrollbar;  // Drag Scrollbar here in Inspector
    public AudioSource audioPlayer;    // Drag AudioSource here

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeScrollbar.value = savedVolume;  // Use value, NOT size
        audioPlayer.volume = savedVolume;

        volumeScrollbar.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        audioPlayer.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}
