using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositTriggers : MonoBehaviour
{
    [SerializeField] private ItemType _containerType;
    [SerializeField] private PlayerInfo _player;
    [SerializeField] private ScoreManager _scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && _player.holdingItem == true)
        {
            if(other.transform.GetChild(0).GetChild(0).GetComponent<ItemScript>().itemType == _containerType)
            {
                _scoreManager.AddScore(3);
                Debug.Log("Bon objet au bon endroit! +3 Points");
            }
            else
            {
                _scoreManager.SubstractScore(2);
                Debug.Log("Womp womp! -2 Points");
            }
            Destroy(other.transform.GetChild(0).GetChild(0).gameObject);
            
            _player.holdingItem = false;
        }
    }
}
