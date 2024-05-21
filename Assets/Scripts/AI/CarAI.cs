using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    [SerializeField] private AIManager _aiManager;
    [SerializeField] private bool isClockwise;
    public GameObject currentCheckpoint;
    [SerializeField] private ScoreManager _score;
    [SerializeField] private SceneChange _sceneManager;
    [SerializeField] private GameObject _player;
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
        UpdateCheckpoint();
    }

    private void UpdateCheckpoint()
    {
        
        GameObject newCheckpoint = _aiManager.GetNextCarCheckpoint(isClockwise, currentCheckpoint);
        if(currentCheckpoint != null)
        {
            _aiManager.SwitchCheckpoint(currentCheckpoint, false);
        }
        currentCheckpoint = newCheckpoint;
        _aiManager.SwitchCheckpoint(currentCheckpoint, true);
        gameObject.GetComponent<NavMeshAgent>().SetDestination(currentCheckpoint.transform.position);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            _score.BadEndScore();
            _player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Invoke("GameOverScene", 3);
            
        }
        else if(other.collider.gameObject.CompareTag("Dog"))
        {
            if(other.collider.gameObject.GetComponent<DogBehavior>() != null)
            {
                GetComponent<AudioSource>().Play();
                other.collider.gameObject.GetComponent<DogBehavior>().Death();
            }
            
        }
    }

    private void GameOverScene()
    {
        _sceneManager.NextScene();
    }
}
