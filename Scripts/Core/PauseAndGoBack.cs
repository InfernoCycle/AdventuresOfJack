using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif
using UnityEngine.SceneManagement;

public class PauseAndGoBack : MonoBehaviour
{
    private GameObject canvas;
    private GameObject deathScreen;
    private GameObject settingsScreen;
    private GameObject FinishedGame;
    private GameObject level;
    private string[] components = {"SettingsMenu", "Canvas", "Level", "DeathScreen", "SettingsMenu2", "FinishedGame"};

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    /*List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
            
        }

        return objectsInScene;
    }*/

    /*private void Awake()
    {
        //canvas = null;
        //level = GameObject.Find("Level");
    }*/
    // Start is called before the first frame update
    private void Awake()
    {
        for(int i = 0; i < components.Length; i++)
        {
            GameObject obj = FindInActiveObjectByName(components[i]);

            if (obj.name.Equals("Canvas"))
            {
                canvas = obj;
            }
            if (obj.name.Equals("Level"))
            {
                level = obj;
            }
            if (obj.name.Equals("DeathScreen"))
            {
                deathScreen = obj;
            }
            if (obj.name.Equals("SettingsMenu2"))
            {
                settingsScreen = obj;
            }
            if (obj.name.Equals("FinishedGame"))
            {
                FinishedGame = obj;
            }
        }
        /*print(FindInActiveObjectByName("SettingsMenu"));
        foreach (GameObject obj in GetAllObjectsOnlyInScene())
        {
            if (obj.name.Equals("Canvas"))
            {
                canvas = obj;
            }
            if (obj.name.Equals("Level"))
            {
                level = obj;
            }
            if (obj.name.Equals("DeathScreen"))
            {
                deathScreen = obj;
                print(deathScreen.name);
            }
            if (obj.name.Equals("SettingsMenu2"))
            {
                settingsScreen = obj;
                print(settingsScreen.name);
            }
            if (obj.name.Equals("FinishedGame"))
            {
                FinishedGame = obj;
                print(FinishedGame.name);
            }
        }*/
    }

    public void JustForcePause()
    {
        level.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void showFinished()
    {
        FinishedGame.SetActive(true);
    }

    public void showDeathScreen()
    {
        deathScreen.SetActive(true);
        //level.SetActive(false);
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            level.SetActive(false);
            canvas.SetActive(true);
            settingsScreen.SetActive(true);
        }
    }
}