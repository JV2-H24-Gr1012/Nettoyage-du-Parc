using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private PlayerInfo _player;
    [SerializeField] private TMP_Text _scoretext;
    // Start is called before the first frame update
    void Start()
    {
        _player.score = 0;
        _player.holdingItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        _player.score += amount;
        UpdateText();
    }
    public void SubstractScore(int amount)
    {
        _player.score -= amount;
        UpdateText();
    }

    public void BadEndScore()
    {

    }

    private void UpdateText()
    {
        _scoretext.text = "Score: " + _player.score.ToString();
    }
}
