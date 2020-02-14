using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPools : MonoBehaviour
{

    [System.Serializable]

    public class Enemy {
        public float timeToSpawn;
        public GameObject prefab;
        public int posX;
        public int posY;

        public int endPosX;
        public int endPosY;

    }
    
    public List<Enemy> enemies;
    public List<GameObject> EnemyPool;

    public static Vector3 newPosition;

    void Start()
    {
        foreach(Enemy enemy in enemies) {
            GameObject obj = Instantiate(enemy.prefab);
            obj.transform.position = new Vector3(enemy.posX, enemy.posY, 0);
            obj.SetActive(false); 
            EnemyPool.Add(obj);
        }

        StartCoroutine("SpawnEnemies");
    }




    IEnumerator SpawnEnemies() {

        float timePassed = 0f;
        for (int i=0; i < enemies.Count; i++) {
            Enemy enemy = enemies[i];
            yield return new WaitForSeconds(enemy.timeToSpawn - timePassed);
            GameObject enemyObj = EnemyPool[i];

            enemyObj.transform.position = new Vector3(enemy.posX, enemy.posY, 0);
            Vector3 newPosition = new Vector3(enemy.endPosX, enemy.endPosY, 0);

            enemyObj.SetActive(true);

            ProjectileSpawner projectileSpawner = enemyObj.GetComponent<ProjectileSpawner>();
            projectileSpawner.enabled = false;

            float timeSinceStarted = 0f;

            while (enemyObj.transform.position != newPosition) {
                
                timeSinceStarted += Time.deltaTime;
                enemyObj.transform.position = Vector3.Lerp(enemyObj.transform.position, newPosition, timeSinceStarted);
                yield return null;
            }

            // projectileSpawner.enabled = true;

        }
    }

    // IEnumerator MoveFunction()
    // {
    //     float timeSinceStarted = 0f;
    //     while (gameObject.transform.position != (newPosition))
    //     {
    //         timeSinceStarted += Time.DeltaTime;
    //         obj.transform.position = Vector3.Lerp(obj.transform.position, newPosition, timeSinceStarted);

    //         yield return null;
    //     }

}
