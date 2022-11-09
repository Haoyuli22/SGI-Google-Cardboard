using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 hit_point;
    private GameObject hit_object;
    public GameObject[] magic_pizza;
    public GameObject[] shootPrefabs;

    public int current_select = 0;


    public float attack_periot = 1.5f;
    private float attackCounter = 0;


    void Start()
    {
        attackCounter = attack_periot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0) {
            if (current_select > 0)
            {
                current_select--;
            }
            else {
                current_select = magic_pizza.Length - 1;
            }
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            if (current_select < magic_pizza.Length - 1)
            {
                current_select++;
            }
            else
            {
                current_select = 0;
            }
        }

        for(int i = 0; i < magic_pizza.Length; i++)
        {
            //magic_pizza[i].transform.position = magic_pizza[current_select].transform.position;
            if (i == current_select)
            {
                magic_pizza[current_select].SetActive(true);
                shootPrefabs[current_select].SetActive(true);
            }
            else {
                magic_pizza[i].SetActive(false);
                shootPrefabs[i].SetActive(false);
            }
        }
        hit_object = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().ObjectGazed;
        hit_point = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().hitpoint;

        //Magic aura controller
        if (hit_object = null)
        {
            magic_pizza[current_select].SetActive(false);
        }
        else {
            magic_pizza[current_select].SetActive(true);
            magic_pizza[current_select].transform.position = new Vector3(hit_point.x, magic_pizza[current_select].transform.position.y, hit_point.z);
        }
        attackCounter += Time.deltaTime;
        //shootPrefabType2 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().getGazed();
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCounter >= attack_periot)
        {
            GameObject projectileGameObject = Instantiate(shootPrefabs[current_select],
                                        new Vector3(magic_pizza[current_select].transform.position.x, 
                                                    magic_pizza[current_select].transform.position.y,
                                                    magic_pizza[current_select].transform.position.z)
                                        , magic_pizza[current_select].transform.rotation, null);
            
            projectileGameObject.gameObject.tag = "PlayerBullet";
            //projectileGameObject.AddComponent<Bullet>();
            Destroy(projectileGameObject, 2);

            attackCounter = 0;
        }
    }
}
