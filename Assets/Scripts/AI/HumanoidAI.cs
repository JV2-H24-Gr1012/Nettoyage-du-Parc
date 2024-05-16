using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanoidAI : MonoBehaviour
{
    [SerializeField] private AIManager _aiManager;
    [SerializeField] private float _dropOdds;
    public GameObject currentCheckpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateCheckpoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCheckpointReached()
    {
        if(Random.Range(0f, 1f) <= _dropOdds)
        {
            _aiManager.DropItem(gameObject);
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
}
