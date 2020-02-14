using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    ProjectilePools projectilePools;

    void Start()
    {

        projectilePools = ProjectilePools.Instance;
        
        GameObject projectile;

        transform.position = new Vector3 (transform.position.x, transform.position.y, 10f);
        
        projectile = projectilePools.SpawnFromPool("EnemyProjectile", transform.position, Quaternion.identity);

    }


    


}
