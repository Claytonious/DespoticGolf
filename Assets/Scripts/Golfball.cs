using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golfball : MonoBehaviour
{
    [SerializeField]
    private AudioSource _impactSound;
    
    private Vector3 _velocity;

    private void Update()
    {
        _velocity.y -= 9.8f * Time.deltaTime;
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, _velocity.normalized, out hitInfo, _velocity.magnitude * Time.deltaTime, 1 << 9))
        {
            _impactSound.Play();
            _velocity.y = 4f;
        }
        transform.position += _velocity * Time.deltaTime;
    }
}
