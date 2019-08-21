using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;
public class Shoot : NetworkBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    [Range(0, 20)]
    private float _bulletSpeed;

    
    
    private void Update()
    {
        if (this.isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            
            this.CmdShoot(transform.position);
        }
    }

    //Bullet should have a local player Authority
    // Commands - Only run on Server
    //Rpc (Remote Procedure Call) - Runs on Client but called from Server

    [ClientRpc]
    void RpcClientShot(Vector3 position)
    {
        
        GameObject bullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.up * _bulletSpeed;
        Destroy(bullet, 1f);
    }

    [Command]
    void CmdShoot(Vector3 posiiton)
    {
        //Tell client to spawn a bullet
        RpcClientShot(posiiton);

    }

}
