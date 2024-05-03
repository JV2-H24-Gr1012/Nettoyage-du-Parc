using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AdvancedSett _settings;
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

        _sfxSlider.value = _settings.sfxVolume;
        _sfxValueText.text = _settings.sfxVolume.ToString();
        _mixer.SetFloat("SFXVolume", CalcValue(_settings.musicVolume));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float CalcValue(float input)
    {
        // input is a percentage, which is why it's divided by 100.
        // if input = 0, output = -80;
        // if input = 100, output = 0;
        // trueOutput is a number in the range from 0 to 10^8;
        // if input = 0, trueOutput = 0;
        // if input = 100, trueOutput = 10^8;
        // output = 10* the log10 of trueOutput, -80 since that's the minimum.
        // Idk if that's accurate, but at this point idc.
        if(input == 0f)
        {
            return -80f;
        }
        float trueOutput = input / 100 * Mathf.Pow(10, 8);
        float output = Mathf.Log10(trueOutput) * 10 - 80;
        return output;
    }

    public void ChangeMusic()
    {
        _settings.musicVolume = (int)_musicSlider.value;
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
