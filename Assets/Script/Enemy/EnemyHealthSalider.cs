using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthSalider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider healthbar;

    public float maxHealth;
    private float currentHealth;
    void Start()
    {
        healthbar.maxValue = maxHealth;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
