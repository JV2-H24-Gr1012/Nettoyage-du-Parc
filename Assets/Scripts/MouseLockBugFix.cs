using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class MouseLockBugFix : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _inputScript;
    // Start is called before the first frame update
    void Start()
    {
        _inputScript.SetCursorState(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CursorBeforeSceneChange()
    {
        _inputScript.SetCursorState(false);
    }
}
