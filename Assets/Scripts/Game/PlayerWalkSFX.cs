using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _sfx;
    [SerializeField] private float _speedMultiplier;
    public bool walking;
    public bool grounded;
    public bool jumping;
    public bool landing;
    private float _timeBetweenSteps;
    private float _timeSinceLastStep;
    // Start is called before the first frame update
    void Start()
    {
        walking = false;
        grounded = true;
        jumping = false;
        landing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(walking && grounded)
        {
            _timeSinceLastStep += Time.deltaTime;
            if(_timeSinceLastStep >= _timeBetweenSteps)
            {
                _timeSinceLastStep -= _timeBetweenSteps;
                PlayStep();
            }
        }
        if(jumping)
        {
            jumping = false;
            PlayStep();
        }
        if(landing)
        {
            landing = false;
            PlayStep();
        }
        
    }

    public void ChangeTimeBetweenSteps(float steps)
    {
        if(steps == 0)
        {
            walking = false;
        }
        else
        {
            walking = true;
            _timeBetweenSteps = 1 / (steps * _speedMultiplier);
        }
        
    }

    public void PlayStep()
    {
        _sfx.PlayOneShot(_sfx.clip);
    }
}
