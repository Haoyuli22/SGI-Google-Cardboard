using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HumanControl : MonoBehaviour
{
    private GameObject hit_object;

    public Image pointer;
    public Camera main_camera;

    public float rorate_speed = 20f;
    
    public GameObject[] positions;
    public GameObject[] positions_effect;
    public int current_position = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlCamera();
        hit_object = hit_object = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().ObjectGazed;

        if (hit_object != null && hit_object.tag == "PosiEfect")
        {
            pointer.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Joystick1Button3)) {
                if (current_position == 0) {
                    transform.position = positions[1].transform.position;
                    //transform.position = new Vector3(0,0,0);
                    positions_effect[0].SetActive(true);
                    positions_effect[1].SetActive(false);

                    current_position = 1;
                }
                else if (current_position == 1) {
                    transform.position = positions[0].transform.position;
                    positions_effect[1].SetActive(true);
                    positions_effect[0].SetActive(false);

                    current_position = 0;
                }
            }
        }
        else {
            pointer.gameObject.SetActive(false);
        }

        


    }

    void ControlCamera(){
        Vector3 v3 = new Vector3(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0f);
        main_camera.transform.Rotate(v3 * rorate_speed * Time.deltaTime);
    }


}
