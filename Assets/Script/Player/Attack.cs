using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 hit_point;
    private GameObject hit_object;

    public Slider[] magic_charge;
    public Text[] magic_text;
    public GameObject[] magic_pizza;
    public GameObject[] shootPrefabs;

    public int current_select = 0;

    public float attack_periot = 1.5f;
    private float attackCounter = 0;

    private float global_charge_time = 4f;
    private float[] local_charge_time;

    private int max_magic_point = 10;
    private int initial_magic_point = 10;
    private int[] local_magic_point;


    void Start()
    {
        local_charge_time = new float[magic_pizza.Length];
        local_magic_point = new int[magic_pizza.Length];
        for (int i = 0; i < local_charge_time.Length;i++) {
            local_charge_time[i] = 0f;
            local_magic_point[i] = 3;

            magic_charge[i].maxValue = global_charge_time;
            
        }   

        attackCounter = attack_periot;
    }

    // Update is called once per frame
    void Update()
    {
        //Scroll up and down
        ChangeAura();

        for(int i = 0; i < magic_pizza.Length; i++)
        {
            local_charge_time[i] += Time.deltaTime;
            if (local_charge_time[i] >= global_charge_time && local_magic_point[i] != max_magic_point) {
                local_charge_time[i] = 0;
                local_magic_point[i]++;
                
                magic_text[i].text = local_magic_point[i].ToString();
            }
            magic_charge[i].value = local_charge_time[i];

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

    void ChangeAura() {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (current_select > 0)
            {
                current_select--;
            }
            else
            {
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
    }
}
