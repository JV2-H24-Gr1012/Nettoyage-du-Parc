using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _player;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _parkText;
    // Start is called before the first frame update
    void Start()
    {
        _nameText.text = _player.playerName;
        _parkText.text = _player.parkName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
