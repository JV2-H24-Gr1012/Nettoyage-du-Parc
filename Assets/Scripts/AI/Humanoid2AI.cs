using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Humanoid2AI : MonoBehaviour
{
    [SerializeField] private AIManager _aiManager;
    [SerializeField] private float _dogOdds;
    public GameObject currentCheckpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateCheckpoint();
        Debug.Log(currentCheckpoint);
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
        }
        UpdateCheckpoint();
        
    }

    private void UpdateCheckpoint()
    {
        
        GameObject newCheckpoint = null;
        while(newCheckpoint == null)
        {
            _aiManager.GetNewCheckpoint(true);
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
