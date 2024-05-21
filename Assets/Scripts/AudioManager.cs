using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private TMP_Text _musicValueText;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private TMP_Text _sfxValueText;
    [SerializeField] private AudioMixer _mixer;
    // Start is called before the first frame update
    void Start()
    {
        _musicSlider.value = _settings.musicVolume;
        _musicValueText.text = _settings.musicVolume.ToString();
        _mixer.SetFloat("MusicVolume", CalcValue(_settings.musicVolume));
        ChangeMusic();

        _sfxSlider.value = _settings.sfxVolume;
        _sfxValueText.text = _settings.sfxVolume.ToString();
        _mixer.SetFloat("SFXVolume", CalcValue(_settings.musicVolume));
        ChangeSFX();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float CalcValue(float input)
    {
        float output = Mathf.Lerp(-80, 0, input/100);
        return output;
    }

    public void ChangeMusic()
    {
        _settings.musicVolume = Mathf.RoundToInt(_musicSlider.value);
        _musicValueText.text = _settings.musicVolume.ToString();
        _mixer.SetFloat("MusicVolume", CalcValue(_settings.musicVolume));
    }

    public void ChangeSFX()
    {
        _settings.sfxVolume = (int)_sfxSlider.value;
        _sfxValueText.text = _settings.sfxVolume.ToString();
        _mixer.SetFloat("SFXVolume", CalcValue(_settings.sfxVolume));
    }


}
