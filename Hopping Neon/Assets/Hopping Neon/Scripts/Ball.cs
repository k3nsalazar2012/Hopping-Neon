using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    #region Varaibles
    public float bounciness = 3f;

    new Rigidbody rigidbody;
    #endregion

    #region Main Methods
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision col)
    {
        rigidbody.velocity = Vector2.up * bounciness;
    }
    #endregion
}
