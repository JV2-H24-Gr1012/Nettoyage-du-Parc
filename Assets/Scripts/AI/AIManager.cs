using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _checkpoints;
    [SerializeField] private GameObject[] _dogCheckpoints;
    [SerializeField] private GameObject[] _itemDrops;
    [SerializeField] private Vector3 _itemDropRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetNewCheckpoint(bool isDog)
    {
        if(isDog)
        {
            int randomNumber = GetRandomID(_dogCheckpoints);
            if(_dogCheckpoints[randomNumber].GetComponent<Checkpoint>().isTaken == false) 
            {
                return _dogCheckpoints[randomNumber];
            }
            
        }
        else
        {
            int randomNumber = GetRandomID(_checkpoints);
            if(_checkpoints[randomNumber].GetComponent<Checkpoint>().isTaken == false) 
            {
                return _checkpoints[randomNumber];
            }
            
        }
        return null;
        
        
    }

    public void SwitchCheckpoint(GameObject checkpoint, bool active)
    {
        checkpoint.GetComponent<Checkpoint>().isTaken = active;
    }

    private int GetRandomID(GameObject[] array)
    {
        int output = Random.Range(0, array.Length);
        return output;
    }

    public void DropItem(GameObject ai)
    {
        GameObject i = _itemDrops[GetRandomID(_itemDrops)];
        i.transform.position = new Vector3(
            Random.Range(ai.transform.position.x - _itemDropRange.x / 2, ai.transform.position.x + _itemDropRange.x / 2),
            Random.Range(ai.transform.position.y - _itemDropRange.y / 2, ai.transform.position.y + _itemDropRange.y / 2) + 1,
            Random.Range(ai.transform.position.z - _itemDropRange.z / 2, ai.transform.position.z + _itemDropRange.z / 2)
        );
        Instantiate(i);
    }

    public void ReleaseDog()
    {

    }
}
