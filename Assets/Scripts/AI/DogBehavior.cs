using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    [SerializeField] private AIManager _aiManager;
    public GameObject currentCheckpoint;

    [SerializeField] private GameObject _player;

    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private AudioSource _hurtSFX;
    private bool _isAngry;
    // Start is called before the first frame update
    void Start()
    {
        _isAngry = false;
        UpdateCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAngry)
        {
            BadBoyRoutine();
        }
        else
        {
            GoodBoyRoutine();
        }
    }

    public void ToggleBehavior()
    {
        _isAngry = !_isAngry;
    }

    private void GoodBoyRoutine()
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(currentCheckpoint.transform.position);
    }

    private void BadBoyRoutine()
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(_player.transform.position);
    }

    public void OnCheckpointReached()
    {
        if(!_isAngry)
        {
            UpdateCheckpoint();
        }
        
    }

    private void UpdateCheckpoint()
    {
        GameObject newCheckpoint = null;
        while(newCheckpoint == null)
        {
            newCheckpoint = _aiManager.GetNewCheckpoint(true);
        }
        if(currentCheckpoint != null)
        {
            _aiManager.SwitchCheckpoint(currentCheckpoint, false);
        }
        currentCheckpoint = newCheckpoint;
        _aiManager.SwitchCheckpoint(currentCheckpoint, true);
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject == _player && _isAngry)
        {
            _timeManager.ReduceTime(5f);
            _hurtSFX.Play();
        }
    }

    public void Death()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Animator>().enabled = false;
        Destroy(gameObject.GetComponent<NavMeshAgent>());
        Destroy(this);
    }
}
