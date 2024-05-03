using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private AdvancedSett _settings;
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_Text _timeText;
    // Start is called before the first frame update
    void Start()
    {
        _timeSlider.value = _settings.startTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTime()
    {
        _settings.startTimeInSeconds = (int)_timeSlider.value;
        _settings.startTimeMinutes = 0;
        
        for(_settings.startTimeSeconds = _settings.startTimeInSeconds; _settings.startTimeSeconds >= 60; _settings.startTimeSeconds -= 60)
        {
            _settings.startTimeMinutes++;
        }
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        _timeText.text = _settings.startTimeSeconds < 10 ? _settings.startTimeMinutes.ToString() + ":0" + _settings.startTimeSeconds.ToString() : _settings.startTimeMinutes.ToString() + ":" + _settings.startTimeSeconds.ToString();
    }
}
