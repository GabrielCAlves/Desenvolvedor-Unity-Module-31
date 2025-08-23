using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 2f;

    public float speed = 50f;

    public int damageAmount = 1;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Com o rigidbody:
        //var enemy = collision.transform.GetComponent<EnemyBase>();

        //if (enemy != null)
        //{
        //    enemy.Damage(damageAmount);
        //    Destroy(gameObject);
        //}

        var damageable = collision.transform.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
