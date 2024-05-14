using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isTaken;
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
        if(other.gameObject.GetComponent<HumanoidAI>() != null)
        {
            if(other.gameObject.GetComponent<HumanoidAI>().currentCheckpoint == gameObject)
            {
                other.GetComponent<HumanoidAI>().OnCheckpointReached();
            }
        }
        else if(other.gameObject.GetComponent<Humanoid2AI>() != null)
        {
            if(other.gameObject.GetComponent<Humanoid2AI>().currentCheckpoint == gameObject)
            {
                other.GetComponent<Humanoid2AI>().OnCheckpointReached();
            }
        }
        else if(other.gameObject.GetComponent<PassiveDogAI>() != null)
        {
            if(other.gameObject.GetComponent<PassiveDogAI>().currentCheckpoint == gameObject)
            {
                other.GetComponent<PassiveDogAI>().OnCheckpointReached();
            }
        }
    }
}
