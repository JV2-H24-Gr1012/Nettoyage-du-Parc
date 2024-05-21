using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartTimeManager : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private TMP_Text _timeText;
    // Start is called before the first frame update
    void Start()
    {
        _timeSlider.value = _settings.startTimeInSeconds;
        UpdateTime();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTime()
    {
        _settings.startTimeInSeconds = Mathf.RoundToInt(_timeSlider.value);
        int minutes = Mathf.FloorToInt(_settings.startTimeInSeconds / 60);
        int seconds = _settings.startTimeInSeconds - minutes * 60;
        _timeText.text = seconds < 10 ? minutes.ToString() + ":0" + seconds.ToString() : minutes.ToString() + ":" + seconds.ToString();
    }
}
