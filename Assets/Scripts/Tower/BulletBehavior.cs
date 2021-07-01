using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 5;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float _distance;
    private float _startTime;

    private GameManagerBehavior gameManager;

    private void Start()
    {
        _startTime = Time.time;
        _distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }

    private void Update()
    {
        float timeInterval = Time.time - _startTime;
        gameObject.transform.position = Vector3.Lerp(
            startPosition,
            targetPosition,
            timeInterval * speed / _distance
        );

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);

                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);

                    gameManager.Gold += 50;
                }
            }
            Destroy(gameObject);
        }
    }
}
