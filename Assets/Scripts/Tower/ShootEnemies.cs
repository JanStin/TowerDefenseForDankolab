using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private TowerData _towerData;
    private float _lastShotTime;

    private void Start()
    {
        enemiesInRange = new List<GameObject>();
        _lastShotTime = Time.time;
        _towerData = gameObject.GetComponentInChildren<TowerData>();
    }

    private void Update()
    {
        GameObject target = null;

        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }

        if (target != null)
        {
            if (Time.time - _lastShotTime > _towerData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                _lastShotTime = Time.time;
            }

            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
                new Vector3(0, 0, 1));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collision.gameObject);
            EnemyDestructionDelegate del =
                collision.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collision.gameObject);
            EnemyDestructionDelegate del =
                collision.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    private void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    private void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = _towerData.CurrentLevel.bullet;

        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        //GameObject newBullet = Instantiate(bulletPrefab);
        //newBullet.transform.position = startPosition;
        //BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        //bulletComp.target = target.gameObject;
        //bulletComp.startPosition = startPosition;
        //bulletComp.targetPosition = targetPosition;
    }
}
