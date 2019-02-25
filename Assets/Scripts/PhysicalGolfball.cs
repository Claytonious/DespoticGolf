using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicalGolfball : MonoBehaviour
{
    [SerializeField]
    private AudioSource _impactSound;

    [SerializeField] 
    private float _controlForce = 10f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision c)
    {
        _impactSound.Play();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.forward * _controlForce);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.back * _controlForce);            
        }

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left * _controlForce);            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right * _controlForce);                        
        }
    }
}
