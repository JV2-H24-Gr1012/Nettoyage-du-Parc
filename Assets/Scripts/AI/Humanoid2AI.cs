using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Humanoid2AI : MonoBehaviour
{
    [SerializeField] private AIManager _aiManager;
    [SerializeField] private float _dogOdds;
    public GameObject currentCheckpoint;
    [SerializeField] private AudioSource _walkSFX;

    private bool _isWalking;
    [SerializeField] private GameObject _questIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateCheckpoint();
        _isWalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCheckpointReached()
    {
        if(Random.Range(0f, 1f) <= _dogOdds)
        {
            _aiManager.ReleaseDog();
            ToggleWalk();
        }
        UpdateCheckpoint();
        
    }

    private void UpdateCheckpoint()
    {
        
        GameObject newCheckpoint = null;
        while(newCheckpoint == null)
        {
            newCheckpoint = _aiManager.GetNewCheckpoint(false);
        }
        if(currentCheckpoint != null)
        {
            _aiManager.SwitchCheckpoint(currentCheckpoint, false);
        }
        currentCheckpoint = newCheckpoint;
        _aiManager.SwitchCheckpoint(currentCheckpoint, true);
        gameObject.GetComponent<NavMeshAgent>().SetDestination(currentCheckpoint.transform.position);
        
    }

    public void ToggleWalk()
    {
        _isWalking = !_isWalking;
        GetComponent<NavMeshAgent>().speed = _isWalking ? 1.5f : 0f;
        gameObject.GetComponent<Animator>().SetTrigger("trigger");
        _questIcon.GetComponent<Animator>().SetTrigger("trigger");
        if(_isWalking)
        {
            _walkSFX.Play();
        }
        else
        {
            _walkSFX.Stop();
        }
    }
}
