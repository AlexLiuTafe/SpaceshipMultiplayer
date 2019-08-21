using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;

    [SerializeField]
    private float _spawnInterval = 1f;

    [SerializeField]
    private float _enemySpeed = 1f;

    private int randomEnemy;

    public override void OnStartServer()
    {
        
        InvokeRepeating("SpawnEnemy", this._spawnInterval, this._spawnInterval);

    }

    void SpawnEnemy()
    {
        randomEnemy = Random.Range(0,3);
        Vector2 _spawnPosition = new Vector2(Random.Range(-4f, 4f), this.transform.position.y);
        GameObject _enemy = Instantiate(_enemyPrefab[randomEnemy], _spawnPosition, Quaternion.identity)as GameObject;
        _enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -this._enemySpeed);
        NetworkServer.Spawn(_enemy);   
        Destroy(_enemy, 10f);
        
    }
}
