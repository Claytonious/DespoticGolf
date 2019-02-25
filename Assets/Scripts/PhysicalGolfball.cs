using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalGolfball : MonoBehaviour
{
    [SerializeField]
    private AudioSource _impactSound;
    
    private void OnCollisionEnter(Collision c)
    {
        _impactSound.Play();
    }
}
