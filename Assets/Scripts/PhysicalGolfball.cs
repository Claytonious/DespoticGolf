using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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
        StartCoroutine(GetTexture());
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

    private IEnumerator GetTexture()
    {
        using (var request =
            UnityWebRequestTexture.GetTexture("https://www.gravatar.com/avatar/" + Guid.NewGuid().ToString("N") +
                                              "?d=robohash"))
        {
            yield return request.Send();
            if (!request.isNetworkError && !request.isHttpError)
            {
                GetComponent<Renderer>().material.mainTexture =
                    ((DownloadHandlerTexture) request.downloadHandler).texture;
            }
        }
    }
}
