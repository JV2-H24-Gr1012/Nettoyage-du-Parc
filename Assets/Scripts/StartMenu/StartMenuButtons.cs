using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _advancedSettings;
    [SerializeField] private PlayerInfo _player;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private TMP_InputField _parkField;
    [SerializeField] private GameObject _sceneManager;
    [SerializeField] private AudioSource _click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdvSettClick()
    {
        _click.Play();
        _advancedSettings.SetActive(!_advancedSettings.activeSelf);
    }

    public void CheckFields()
    {
        _click.Play();
        if(_nameField.text == "" || _parkField.text == "")
        {
            _nameField.placeholder.GetComponent<TMP_Text>().text = "Choisis un nom, stp...";
            _parkField.placeholder.GetComponent<TMP_Text>().text = "Choisis un nom, stp...";
        }
        else
        {
            _player.playerName = _nameField.text;
            _player.parkName = _parkField.text;
            _sceneManager.GetComponent<SceneChange>().NextScene();
        }
    }
}
