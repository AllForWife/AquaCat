using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.anyKeyDown)
        {
            //SceneManager.LoadScene(1);
        }
        
    }
}
