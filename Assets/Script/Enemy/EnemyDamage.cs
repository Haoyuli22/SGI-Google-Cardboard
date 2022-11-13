using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyHealthSalider health;
    public float maxHP;
    private float currentHP;

    private BoxCollider colider;
    private Animator animator;
    private Enemy enemy;
    void Start()
    {
        health = gameObject.GetComponent<EnemyHealthSalider>();
        health.Initiate(maxHP);

        currentHP = maxHP;

        animator = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponent<Enemy>();

    }
    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0) {
            enemy.die = true;
            Destroy(this);
        }
    }

    public void Hit(float hit) {
        currentHP -= hit;
        health.UpdateHealth(currentHP);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            Hit(1);
        }

        if (other.tag == "PunchBullet")
        {
            Hit(4);
            enemy.AttackedByForce();
        }

        if (other.tag == "IceBullet")
        {
            Hit(1);
            enemy.AttackedByIce();
        }
    }
}
