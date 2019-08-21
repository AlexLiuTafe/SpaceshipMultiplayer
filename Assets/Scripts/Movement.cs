using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Mirror;
public class Movement : NetworkBehaviour
{
    [SerializeField]
    [Range(0,5)]
    private float _speed;

    private void FixedUpdate()
    {
        if (this.isLocalPlayer)
        {
            float _movement = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(_movement * _speed, 0);
        }
    }
}
