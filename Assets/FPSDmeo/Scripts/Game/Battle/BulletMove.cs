using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    [SerializeField] float bulletSpeed;

    private void Start()
    {
        Destroy(gameObject,5);
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.forward*bulletSpeed*Time.deltaTime,Space.Self);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
