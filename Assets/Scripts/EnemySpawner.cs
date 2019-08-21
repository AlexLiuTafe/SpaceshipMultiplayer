using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefabs;

    [SerializeField]
    private float _spawnInterval = 1f;

    [SerializeField]
    private float _enemySpeed = 1f;

    [Header("Variables")]
    private int _randomEnemy;
    public Transform enemyClone; //Stire them in hierarchy

    private void Awake()
    {
        //Getting all the prefabs in that folder
        _enemyPrefabs = Resources.LoadAll<GameObject>("Prefabs/Enemy");
    }
    public override void OnStartServer()
    {
        

        InvokeRepeating("SpawnEnemy", this._spawnInterval, this._spawnInterval);

    }

    void SpawnEnemy()
    {
        _randomEnemy = Random.Range(0,3);
        Vector2 _spawnPosition = new Vector2(Random.Range(-4f, 4f), this.transform.position.y);
        GameObject _enemy = Instantiate(_enemyPrefabs[_randomEnemy], _spawnPosition, Quaternion.identity)as GameObject;
        _enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -this._enemySpeed);
        _enemy.transform.SetParent(enemyClone);
        NetworkServer.Spawn(_enemy);    
        Destroy(_enemy, 10f);
        
    }
}
