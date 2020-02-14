using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private ProjectilePools projectilePools;
        

    void Start()
    {
        projectilePools = ProjectilePools.Instance;

        InvokeRepeating("SpawnProjectile", 1.0f, 1.0f);

        StartCoroutine("Waiter");
        


    }

    IEnumerator Waiter() {

        yield return new WaitForSeconds(3f);
        
        StartCoroutine("Move");



    }

    IEnumerator Move() {
        StartCoroutine("Rotate");
        while (gameObject.activeSelf)  {
            transform.position = new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(.05f);

        }
    }

    IEnumerator Rotate() {

        while(gameObject.activeSelf) {

            transform.Rotate(0, 0, 1);
            yield return null;
        }
    }

    void SpawnProjectile() {
    
        GameObject projectile;
        

        transform.position = new Vector3 (transform.position.x, transform.position.y, 10f);
        
        projectile = projectilePools.SpawnFromPool("EnemyProjectile", transform.position, Quaternion.identity);

    }

    void OnBecameInvisible()
    {
        enabled = false;
        gameObject.SetActive(false);
    }
}
