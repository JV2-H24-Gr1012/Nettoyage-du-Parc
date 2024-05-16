using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private AdvancedSett _settings;
    [SerializeField] private SceneChange _sceneManager;
    [SerializeField] private TMP_Text _timeText;
    // Start is called before the first frame update
    void Start()
    {
        _playerInfo.timer = _settings.startTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        _playerInfo.timer -= Time.deltaTime;
        if(_playerInfo.timer <= 0)
        {
            _sceneManager.LoadSceneByID(2);
        }
        TimeDisplay();
    }

    private void TimeDisplay()
    {
        int minutes = (int)Mathf.Floor(_playerInfo.timer / 60f);
        int seconds = (int)(_playerInfo.timer - minutes * 60);
        _timeText.text = seconds < 10 ? minutes.ToString() + ":0" + seconds.ToString() : minutes.ToString() + ":" + seconds.ToString();
    }

    public void ReduceTime(float timeInSeconds)
    {
        _playerInfo.timer -= timeInSeconds;
    }

    public void AddTime(float timeInSeconds)
    {
        _playerInfo.timer += timeInSeconds;
    }
}
