using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEchoEffectScript : MonoBehaviour
{
    //Echo Trail
    public float timeBetweenSpawn;
    public float startTimeBetweenSpawn;

    public GameObject playerEchoGameObject;
    private PlayerMovementScript player;


    private void Start()
    {
        player = GetComponent<PlayerMovementScript>();

    }


    void Update()
    {
        if (player.movementSpeed != 0)
        {
            if (timeBetweenSpawn <= 0)
            {
                GameObject instance = Instantiate(playerEchoGameObject, transform.position, Quaternion.identity);
                Destroy(instance, 0.8f);
                timeBetweenSpawn = startTimeBetweenSpawn;
            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }
        }

        
    }
}
