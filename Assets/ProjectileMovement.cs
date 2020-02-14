using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    void Start()
    {

        InvokeRepeating("Move", 0f, .05f);
    }

    void Move() {
        transform.position -= transform.right * Time.deltaTime * 80f;
    }

    void OnBecameInvisible()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

}