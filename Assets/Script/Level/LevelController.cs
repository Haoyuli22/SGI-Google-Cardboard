using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawners;
    
    public int level = 1;
    public int enemyToNextLevel = 0;
    public int enemyDefeated = 0;

    public float CristalMaxHP = 200;
    private float CristalCurrentHP ;

    public Text text;
    //public bool superated = false;

    void Start()
    {
        CristalCurrentHP = CristalMaxHP;
        enemyToNextLevel = 20 * spawners.Length;
        foreach (GameObject sp in spawners) {
            sp.GetComponent<EnemySpawner>().ResetSpawner(20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string text_to_show = "LEVEL " + level + 
                               "\n MOSNTERS | " + enemyDefeated + "/" + enemyToNextLevel + 
                               "\n CRISTAL'S LIFE | " + Mathf.Ceil(CristalCurrentHP) + "/" + Mathf.Ceil(CristalMaxHP);

        text.text = text_to_show;
        if (enemyToNextLevel == 0) {
            level++;
            int monster_to_defeat = 20 + (level - 1) * 5;
            foreach (GameObject sp in spawners)
            {          
                sp.GetComponent<EnemySpawner>().ResetSpawner(monster_to_defeat);
            }
            enemyToNextLevel = monster_to_defeat * spawners.Length;
        }
    }

    public void CristalTakeDamage(int damage) {
        CristalCurrentHP -= damage;
    }
}