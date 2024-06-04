using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int level;
    // Start is called before the first frame update

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(level);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.SetActive(true);
            ChangeLevel();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
