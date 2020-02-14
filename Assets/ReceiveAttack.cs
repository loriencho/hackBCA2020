using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject endCard;
    public ParticleSystem explosion;

    void Start()
    {
        explosion.Stop();
        endCard.SetActive(false);
        StartCoroutine("WaitForCollision");
    }

    IEnumerator WaitForCollision(){
        LayerMask layerMask = LayerMask.GetMask("Projectiles");

        while ( !(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1.4f, layerMask, 10f, 10f))) {
            yield return null;

        }
        
        explosion.transform.position = transform.position;
        explosion.Play();

        yield return new WaitForSeconds(1f);
        explosion.Stop();

        endCard.SetActive(true);
        StartCoroutine("SlideIntoPlace");

    }

    IEnumerator SlideIntoPlace() {
        float timeSinceStarted = 0f;

        while (endCard.transform.position != Vector3.zero) {
                
            timeSinceStarted += Time.deltaTime;
            endCard.transform.position = Vector3.Lerp(endCard.transform.position, Vector3.zero, timeSinceStarted);
            yield return null;
        }
    }
}