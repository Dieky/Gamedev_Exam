using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;

    public float killReward = 25f;

    AudioSource deathSound;

    // private Transform target;
    // private int wavepointIndex = 0;

    void Start()
    {
        speed = startSpeed;
        deathSound = GetComponent<AudioSource>();
        // target = Waypoints.points[0];
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        deathSound.Play();
        PlayerStats.Money += killReward;
        Destroy(gameObject, 0.3f); // delay to play sound effect
    }

    // void Update()
    // {
    //     Vector3 dir = target.position - transform.position;
    //     transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    //     if (Vector3.Distance(transform.position, target.position) <= 0.2f)
    //     {
    //         GetNextWaypoint();
    //     }
    // }

    // void GetNextWaypoint()
    // {
    //     if (wavepointIndex >= Waypoints.points.Length - 1)
    //     {
    //         EndPath();
    //         return;
    //     }
    //     wavepointIndex++;
    //     target = Waypoints.points[wavepointIndex];
    // }

    // void EndPath()
    // {
    //     PlayerStats.hitpoints--;
    //     Destroy(gameObject);
    // }
}
