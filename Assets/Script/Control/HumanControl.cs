using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
            Debug.Log("Pressed: B" );
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            Debug.Log("Pressed: D");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            Debug.Log("Pressed: C");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            Debug.Log("Pressed: A");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Log("Pressed: L");
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            Debug.Log("Pressed: ZL");
        }


    }

    void CheckButtonName() {
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                Debug.Log("Key code down: " + kcode);
            }
        }
    }
}
