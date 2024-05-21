using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _nameText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = _playerInfo.score.ToString();
        _nameText.text = _playerInfo.score > 0 ? "Bravo " + _playerInfo.playerName + "!" : "Meilleure chance la prochaine fois...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
