using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _checkpoints;
    [SerializeField] private GameObject[] _carCheckpointsClock;
    [SerializeField] private GameObject[] _carCheckpointsCounterClock;
    [SerializeField] private GameObject[] _dogCheckpoints;
    [SerializeField] private GameObject[] _itemDrops;
    [SerializeField] private Vector3 _itemDropRange;
    [SerializeField] private GameObject _dog;
    [SerializeField] private GameObject _dogRescue;
    [SerializeField] private TimeManager _timer;
    [SerializeField] private GameObject _police;
    [SerializeField] private AudioSource _dogReleaseSFX;
    [SerializeField] private AudioSource _dogRescueSFX;
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
        _dog.GetComponent<DogBehavior>().ToggleBehavior();
        _dogRescue.SetActive(true);
        _dogReleaseSFX.Play();
    }

    public void DogRescued()
    {
        _dog.GetComponent<DogBehavior>().ToggleBehavior();
        _police.GetComponent<Humanoid2AI>().ToggleWalk();
        _timer.AddTime(30f);
        _dogRescue.SetActive(false);
        _dogRescueSFX.Play();
    }

    public GameObject GetNextCarCheckpoint(bool clockwise, GameObject currentCheckpoint)
    {
        if(clockwise)
        {
            if(currentCheckpoint == _carCheckpointsClock[_carCheckpointsClock.Length - 1] || currentCheckpoint == null)
            {
                return _carCheckpointsClock[0];
            }

            for(int i = 0; i < _carCheckpointsClock.Length; i++)
            {
                if(currentCheckpoint == _carCheckpointsClock[i])
                {
                    return _carCheckpointsClock[i + 1];
                }
            }
            return _carCheckpointsClock[0];
        }
        else
        {
            if(currentCheckpoint == _carCheckpointsCounterClock[_carCheckpointsCounterClock.Length - 1] || currentCheckpoint == null)
            {
                return _carCheckpointsCounterClock[0];
            }

            for(int i = 0; i < _carCheckpointsCounterClock.Length; i++)
            {
                if(currentCheckpoint == _carCheckpointsCounterClock[i])
                {
                    return _carCheckpointsCounterClock[i + 1];
                }
                
            }
            return _carCheckpointsCounterClock[0];
        }
    }
}
