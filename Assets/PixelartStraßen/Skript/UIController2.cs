using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    public void ToggleMusic()
    {
        AudioManager2.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager2.Instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager2.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager2.Instance.SFXVolume(_sfxSlider.value);
    }
}
