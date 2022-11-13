using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawners;
    public GameObject toMenu;
    
    public int level = 1;
    public int enemyToNextLevel = 0;
    public int enemyDefeated = 0;

    public float CristalMaxHP = 200;
    public float CristalCurrentHP = 200 ;

    public Text text;
    //public bool superated = false;

    public bool gameOver = false;

    void Start()
    {
        CristalCurrentHP = CristalMaxHP;
        enemyToNextLevel = 10 * spawners.Length;
        foreach (GameObject sp in spawners) {
            sp.GetComponent<EnemySpawner>().ResetSpawner(10);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (CristalCurrentHP <= 0)
        {
            GameObject.FindGameObjectWithTag("Cristal").SetActive(false);
            text.text = "Game Over";
            toMenu.SetActive(true);

            GameObject.FindGameObjectWithTag("Player").GetComponent<HumanControl>().navigate_mode = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraPointer>().navigate_mode = true;
            //SceneManager.LoadScene("Scene0",10);

        }
        else {
            string text_to_show = "LEVEL " + level +
                       "\n MONSTERS: " + (enemyToNextLevel - enemyDefeated) +
                       "\n CRISTAL'S LIFE: " + Mathf.Ceil(CristalCurrentHP) + "/" + Mathf.Ceil(CristalMaxHP);

            text.text = text_to_show;
            if ((enemyToNextLevel - enemyDefeated) == 0) {
                level++;
                int monster_to_defeat = 20 + (level - 1) * 5;
                foreach (GameObject sp in spawners)
                {          
                    sp.GetComponent<EnemySpawner>().ResetSpawner(monster_to_defeat);
                }
                enemyToNextLevel = monster_to_defeat * spawners.Length;
                enemyDefeated = 0;
                CristalCurrentHP += 100;
                CristalMaxHP += 100;
            }
        }
    }

    public void CristalTakeDamage(int damage) {
        CristalCurrentHP -= damage;
    }
}
