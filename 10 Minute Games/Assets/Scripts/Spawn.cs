using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float difficulty = 40f;
    float spawn;

    void Start()
    {
        
    }

    void Update()
    {
        spawn += difficulty * Time.deltaTime;
        difficulty += 4f * Time.deltaTime;
        while (spawn > 0)
        {
            spawn -= 1; 
            Vector3 pos = transform.position + new Vector3(Random.value * 40 - 20f, 0, Random.value * 40 - 20f);
            Quaternion rot = Quaternion.Euler(0, Random.value * 360f, Random.value * 30f);
            Vector3 scale = new Vector3(Random.value + 0.1f, 10f, Random.value + 0.1f);
            GameObject obstacle = Instantiate(spawnPrefab, pos, rot);
            obstacle.transform.localScale = scale;

        }
    }
}
