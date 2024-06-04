using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEvent : MonoBehaviour
{
    public void LoadLevel(int index) { 
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Awake()
    {
        
    }
    public void Update()
    {
        
    }
}
