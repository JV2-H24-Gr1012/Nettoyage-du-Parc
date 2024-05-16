using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassiveDogAI : MonoBehaviour
{
    [SerializeField] private AIManager _aiManager;
    public GameObject currentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(currentCheckpoint.transform.position);
    }
    public void OnCheckpointReached()
    {
        UpdateCheckpoint();
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
}
