using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate = 1f;
    public float bulletSpeed = 5f;
    public int bulletCount = 8;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCirclePattern();
            timer = 0f;
        }
    }

    void SpawnCirclePattern()
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float bulletDirXPosition = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1f;
            float bulletDirYPosition = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1f;

            Vector2 bulletVector = new Vector2(bulletDirXPosition, bulletDirYPosition);
            Vector2 bulletMoveDirection = (bulletVector - (Vector2)transform.position).normalized * bulletSpeed;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);

            angle += angleStep;
        }
    }
}
