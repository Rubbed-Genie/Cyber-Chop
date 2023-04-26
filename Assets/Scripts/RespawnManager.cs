using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> items;
    public float respawnTime = 10f;

    private float timer = 0f;

    private void Update()
    {
        foreach (GameObject enemy in enemies)
        {
            if (!enemy.activeInHierarchy)
            {
                timer += Time.deltaTime;
                if (timer >= respawnTime)
                {
                    enemy.SetActive(true);
                    timer = 0f;
                }
            }
        }

        foreach (GameObject item in items)
        {
            if (!item.activeInHierarchy)
            {
                timer += Time.deltaTime;
                if (timer >= respawnTime)
                {
                    item.SetActive(true);
                    timer = 0f;
                }
            }
        }
    }
}
