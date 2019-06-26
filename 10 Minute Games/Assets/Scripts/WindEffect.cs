using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class WindEffect : MonoBehaviour
{
    public ParticleSystem particles;
    public Rigidbody playerRigidbody;

    void Start()
    {
        GetComponent<ParticleSystem>();    
    }

    void Update()
    {
        //particles.main.startSpeedMultiplier = playerRigidbody.velocity.y;
       particles.startSpeed = Mathf.Abs(playerRigidbody.velocity.y);
    }
}
