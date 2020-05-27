using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxDissapear : MonoBehaviour
{
    public GameObject button;
    private ButtonScript bs;
    public GameObject cube1;
    public GameObject cube2;
    public float waitTime;

    private void Start()
    {
        bs = button.GetComponent<ButtonScript>();
        if (SceneManager.GetActiveScene().name.Contains("5"))
        {
            waitTime = 5;
        }
        else if (SceneManager.GetActiveScene().name.Contains("6")) {
            waitTime = 4f;

        }
        else
        {
            waitTime = 2;
        }
    }


    void Update()
    {
        if (bs.buttonActive)
        {
            Debug.Log("Button Active 2");
            StartCoroutine(Dissappear());
            bs.buttonActive = false;
        }
        
    }

    IEnumerator Dissappear()
    {
        cube1.gameObject.SetActive(false);
        cube2.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        cube1.gameObject.SetActive(true);
        cube2.gameObject.SetActive(true);

    }
}
