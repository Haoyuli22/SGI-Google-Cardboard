using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSalider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthbar;


    void Start()
    {
    }

    public void Initiate(float maxHP) {
        healthbar.maxValue = maxHP;
        healthbar.value = maxHP;
    }

    public void UpdateHealth(float currentHP) {
        healthbar.value = currentHP;
    }
    // Update is called once per frame
    void Update()
    {
        healthbar.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


}
