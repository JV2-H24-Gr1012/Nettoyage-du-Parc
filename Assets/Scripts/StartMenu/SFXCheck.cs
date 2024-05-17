using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCheck : MonoBehaviour
{
    [SerializeField] private AudioSource _sfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnMouseUp is called when the user has released the mouse button.
    /// </summary>
    private void OnMouseUp()
    {
        Debug.Log("Drag ended!");
        _sfx.Play();
    }
}
