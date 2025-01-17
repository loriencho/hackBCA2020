﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePools : MonoBehaviour
{

    [System.Serializable]

    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ProjectilePools Instance;

    void Awake() {
        Instance = this;
    }

    
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary; 


    void Start()
    {
        
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

         foreach (Pool pool in pools)
        {
            Queue<GameObject> projectilePool = new Queue<GameObject>();

            for (int i= 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                projectilePool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, projectilePool);

        }    
    }


    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
        }


}
