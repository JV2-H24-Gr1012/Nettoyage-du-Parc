using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRescue : MonoBehaviour
{
    [SerializeField] private GameObject _dog;
    [SerializeField] private AIManager _aiManager;

    [SerializeField] private float _leaveDelay;
    private bool _dogHasLeft;
    // Start is called before the first frame update
    void Start()
    {
        _dogHasLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _dog && _dogHasLeft)
        {
            _aiManager.DogRescued();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == _dog)
        {
            Invoke("DogHasLeft", _leaveDelay);
        }
    }

    private void DogHasLeft()
    {
        _dogHasLeft = true;
    }
}
