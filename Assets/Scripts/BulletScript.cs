using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    EnemyScript enemyScript;
    [SerializeField] int damage;

    private void OnEnable()
    {
        Invoke("hideBullet", 3.0f);
    }

    void hideBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyScript = other.gameObject.GetComponent<EnemyScript>();
            enemyScript.takeDamage(damage);
            gameObject.SetActive(false);
        }
    }

}
