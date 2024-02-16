using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // if enemy dead then do this frfr
    [SerializeField]
    GameObject[] enemies;
    float delay;
    float delayTime = 3f;
    int wave = 1;
    int act = 1;
    // Start is called before the first frame update
    void Start()
    {
        delay = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Basic, minions, basic, 3, minions, basic, 4, boss
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }
        delay = delayTime;
        if (!AreEnemiesAlive())
        {
            switch (act)
            {
                case 1:

                    if (wave == 1 || wave == 3 || wave == 6)
                    {
                        Instantiate(enemies[0]);
                        wave++;
                    }
                    else if (wave == 2 || wave == 5)
                    {
                        Instantiate(enemies[1]);
                        wave++;
                    }
                    else if (wave == 3)
                    {
                        Instantiate(enemies[2]);
                        wave++;
                    }
                    else if (wave == 7)
                    {
                        Instantiate(enemies[3]);
                        wave++;
                    }
                    else if (wave == 8)
                    {
                        Instantiate(enemies[5]);
                        wave++;
                    }
                    else
                    {
                        Debug.Log("No wave found: " + wave);
                        act++;
                        wave = 1;
                    }
                    break;
                default:
                    Debug.Log("No acts found: " + act);
                    break;
            }
        }
    }
    bool AreEnemiesAlive()
    {
        GameObject[] aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in aliveEnemies)
        {
            if (enemy.activeInHierarchy)
            {
                return true;
            }
        }
        return false;
    }
}
