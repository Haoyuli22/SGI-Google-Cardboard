using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HumanControl : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckButtonName();



    }

    void CheckButtonName() {
        if (Input.mouseScrollDelta.y > 0) {
            text.text = "Scroll UP";
            Debug.Log("Scroll UP");
        }

        if (Input.mouseScrollDelta.y < 0)
        {
            text.text = "Scroll DOWN";
            Debug.Log("Scroll DOWN");
        }
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                text.text = "Key code down: " + kcode;
                Debug.Log("Key code down: " + kcode);
            }
        }
    }

    void React() {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //text.text = "Pressed: B"
            Debug.Log("Pressed: B");
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

    void React2() {
        if (Input.GetKeyDown((KeyCode)313))
        {
            text.text = "Pressed: A";
            
        }
    }
}
