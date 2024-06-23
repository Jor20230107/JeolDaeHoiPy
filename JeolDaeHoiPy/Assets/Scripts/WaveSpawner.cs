using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRate = 1f;
    public float bulletSpeed = 5f;
    public int waveCount = 5;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnWavePattern();
            timer = 0f;
        }
    }

    void SpawnWavePattern()
    {
        float offset = 1.5f;

        for (int i = 0; i < waveCount; i++)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x + (i * offset), transform.position.y);
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.down * bulletSpeed;
        }
    }
}
