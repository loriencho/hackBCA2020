using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private int health;
    public ParticleSystem collectable;

    void Start()
    {
        collectable.Stop();
        health = 50;
        StartCoroutine("ReceiveCollision");
    }

    IEnumerator ReceiveCollision(){
        LayerMask layerMask = LayerMask.GetMask("PlayerProjectiles");
        while (health > 0) {
            while ( !(Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 1.4f, layerMask, 10f, 10f))) {
            yield return null;

        }
            health -= 1;
        }

        collectable.Play();

        float timeSinceStarted = 0f;

        while (transform.localScale != Vector3.zero) {
            timeSinceStarted += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, timeSinceStarted);
            yield return null;

        }

        gameObject.SetActive(false);



    }

}
