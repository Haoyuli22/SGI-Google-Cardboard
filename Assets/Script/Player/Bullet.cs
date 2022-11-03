using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject destiny;
    public float projectileSpeed = 3.0f;
    void Start()
    {
        destiny = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().getGazed();
    }

    // Update is called once per frame
    void Update()
    {
        if (destiny == null)
        {
            Debug.Log("Ji");
        }
        else {
            try
            {
                var step = projectileSpeed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, destiny.transform.position, step);
            }
            catch (MissingReferenceException E)
            {
                //Do nothing
            }
        }
    }
}
