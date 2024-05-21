using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private StarterAssetsInputs _inputs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleMenu()
    {
        _optionsMenu.SetActive(!_optionsMenu.activeSelf);
        _inputs.cursorLocked = !_inputs.cursorLocked;
        _inputs.SetCursorState(_inputs.cursorLocked);
    }
}
