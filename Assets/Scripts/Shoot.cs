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
            this.CmdShoot();
        }
    }
    [Command]
    void CmdShoot()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, this.transform.position, Quaternion.identity);
        _bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * _bulletSpeed;
        NetworkServer.Spawn(_bullet);
        Destroy(_bullet, 1f);

    }

}
