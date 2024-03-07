using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FielderController : MonoBehaviour
{
    public SphereCollider sphereCollider;
    private Rigidbody _rb;
    public float FielderSpeed = 1f;
    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag== "Ball")
        {
            _rb.position = Vector3.MoveTowards(transform.position,other.transform.position,FielderSpeed * Time.deltaTime);
        }
    }
}
