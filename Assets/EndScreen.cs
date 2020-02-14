using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }

    void endGame() {
        gameObject.SetActive(true);
        StartCoroutine("SlideIntoPlace");
    }

    IEnumerator SlideIntoPlace() {
        float timeSinceStarted = 0f;

        while (gameObject.transform.position != Vector3.zero) {
                
            timeSinceStarted += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, Vector3.zero, timeSinceStarted);
            yield return null;
        }
    }
}
