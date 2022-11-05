using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private AudioSource attack_sound;


    public float moveSpeed = 5;
    public Transform followTarget = null;

    public int attack = 5;
    public float attackPeriot = 2;
    private float attackCounter = 5;

    private bool moving = true;
    private bool attacking = false;
    public bool die = false;
    public bool died = false;



    void Start()
    {
        attackCounter = attackPeriot;
        anim = gameObject.GetComponent<Animator>();
        attack_sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (died) {
            Destroy(this.gameObject, 1);
        }
        else { 
            if (die) {
            
                anim.Play("Die");
                GameObject.FindGameObjectWithTag("Level").GetComponent<LevelController>().enemyDefeated++;
            
                died = true;
            }
            else
            {
                if (moving)
                {
                    anim.Play("Run");
                    MoveEnemy();
                }
                else if (attacking)
                {
                    if (attackCounter >= attackPeriot)
                    {
                        attackCounter = 0;
                        GameObject.FindGameObjectWithTag("Level").GetComponent<LevelController>().CristalTakeDamage(attack);
                        anim.Play("Attack");
                        attack_sound.Play();

                    }
                    else {
                        attackCounter += Time.deltaTime;
                    }
                    
                }
            }
        }

    }

    private void MoveEnemy()
    {
        // Determine correct movement
        Vector3 movement = GetFollowMovement();

        // Determine correct rotation
        //Quaternion rotationToTarget = GetFollowRotation();
        transform.LookAt(followTarget);
        // Move and rotate the enemy
        transform.position = transform.position + movement;
        //transform.rotation = rotationToTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cristal") {
            moving = false;
            attacking = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cristal")
        {
            moving = true;
            attacking = false;
        }
    }

    private Vector3 GetFollowMovement()
    {
        Vector3 moveDirection = (followTarget.position - transform.position).normalized;
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        return movement;
    }

    private Quaternion GetFollowRotation()
    {
        float angle = Vector3.SignedAngle(Vector3.down, (followTarget.position - transform.position).normalized, Vector3.forward);
        Quaternion rotationToTarget = Quaternion.Euler(0, 0, angle);
        return rotationToTarget;
    }
}
