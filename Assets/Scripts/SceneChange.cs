using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private MouseLockBugFix _mouseLocker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        if(_mouseLocker != null)
        {
            _mouseLocker.CursorBeforeSceneChange();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void FirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneByID(int id)
    {
        SceneManager.LoadScene(id);
    }
}
