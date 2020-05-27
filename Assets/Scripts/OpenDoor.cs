using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Transform origPos;
    public Transform targetPos;
    public float speed;
    public GameObject button;
    private ButtonScript bs;
    private float waitTime;

    private void Start()
    {
        bs = button.GetComponent<ButtonScript>();

        if (SceneManager.GetActiveScene().name.Contains("6"))
        {
            waitTime = 10f;

        }
        else
        {
            waitTime = 5;
        }
    }

    void Update()
    {
        if (bs.buttonActive) {
            StartCoroutine(MovePauseAndReturn());
            bs.buttonActive = false;
        }
    }

    IEnumerator MovePauseAndReturn()
    {
        yield return MoveTo(targetPos);
        yield return new WaitForSeconds(waitTime);
        yield return MoveTo(origPos);
    }

    IEnumerator MoveTo(Transform destination)
    {
        while (transform.position != destination.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
