using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public Transform spawnPoint;
    public List<Transform> turnPoints;
    public bool canSpawn;
    public float enemySpeed = 2f;

    private float _timeRemaining;
    private GameManager _gm;
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _timeRemaining = 1f;
    }

    void Update()
    {
        if (_gm.CAN_SPAWN_ENEMIES)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }

            if (IsCountdownOver())
            {
                InstantiateAnEnemy(turnPoints, spawnPoint.position);
                _timeRemaining = _gm.SPAWN_DELAY;
            }
        }
    }

    private void InstantiateAnEnemy(List<Transform> paths, Vector3 spawnPoint)
    {
        GameObject enemy = Resources.Load<GameObject>("Enemies/BasicEnemy");
        enemy.GetComponent<PathMovement>().paths = paths;
        enemy.GetComponent<PathMovement>().moveSpeed = enemySpeed;
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }

    private bool IsCountdownOver()
    {
        return _timeRemaining <= 0;
    }
}
