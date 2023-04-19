using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    protected NavMeshAgent enemyMesh;

    [SerializeField] float speed;
    [SerializeField] float agroRange;
    [SerializeField] float stopDis;
    [SerializeField] float backDis;

    [SerializeField] GameObject deathFX;
    [SerializeField] int health;
    [SerializeField] GameObject waveManager;
    [SerializeField] WaveSpawner waveSpawner;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waveSpawner = GameObject.Find("WaveManager").GetComponent<WaveSpawner>();
        enemyMesh = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {

        if (player != null)
        {
            float disToPlayer = Vector2.Distance(transform.position, player.position);
            if (disToPlayer < agroRange)
            {
                EnemyMove();
            }
            else
            {
                StopMove();
            }
        }
    }

    private void EnemyMove()
    {
        if (Vector2.Distance(transform.position, player.position) > stopDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopDis && Vector2.Distance(transform.position, player.position) > backDis)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < backDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        float RangeToPlayer = Vector2.Distance(transform.position, player.position);
    }

    void StopMove()
    {
        transform.position = this.transform.position;
    }


    void death()
    {
        waveSpawner._enemyCount(1);
        gameObject.SetActive(false);
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            death();
        }
    }
}
