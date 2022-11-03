using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shootPrefabType1 = null;
    public GameObject shootPrefabType2 = null;
    public GameObject shootPrefabType3 = null;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootPrefabType2 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().getGazed();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject projectileGameObject = Instantiate(shootPrefabType1, transform.position, transform.rotation, null);
            projectileGameObject.AddComponent<Bullet>();
            projectileGameObject.gameObject.tag = "PlayerBullet";


        }
    }
}
