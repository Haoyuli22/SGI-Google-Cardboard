using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject destiny;
    Transform destinyTranform;
    Vector3 destinyPoint;
    public float projectileSpeed = 30.0f;
    void Start()
    {
        destiny = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().getGazed();
        
        if (destiny != null)
        {
            destinyPoint = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().hitpoint;
            Debug.Log(destiny.transform.position);
        }
        else {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destiny == null)
        {
            Debug.Log("Ji");
            Destroy(this.gameObject);
        }
        else {
            try
            {
                var step = projectileSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, destinyPoint, step);
            }
            catch (MissingReferenceException E)
            {
                //Do nothing
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            other.GetComponent<EnemyDamage>().Hit(1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Ji3");
    }
}
