using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject Dead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        Dead.SetActive(false);
        if (SceneManager.GetActiveScene().name.Contains("1")){
            Debug.Log("Level 1 done");
            Debug.Log(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene().name.Contains("2"))
        {
            SceneManager.LoadScene("Level3");
        }
        else if (SceneManager.GetActiveScene().name.Contains("3"))
        {
            SceneManager.LoadScene("Level4");
        }
        if (SceneManager.GetActiveScene().name.Contains("5"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        Dead.SetActive(false);
        SceneManager.LoadScene("MainMenu");

    }
}
