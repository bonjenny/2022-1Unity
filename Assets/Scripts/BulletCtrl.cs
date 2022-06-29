using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    Rigidbody rigid;
    private float BulletSpeed = 20.0f;

    void Start()
    {
        // this.rigid = GetComponent<Rigidbody>();
        Destroy(gameObject, 3.0f);
    }

    void Update()
    {
        // if (transform.position.z <= -100) { Destroy(gameObject, 3.0f); }
        // this.rigid.AddForce(transform.forward * BulletSpeed * Time.deltaTime);
        transform.position += transform.forward * BulletSpeed * Time.deltaTime;
    }
}
