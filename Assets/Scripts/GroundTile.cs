using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundTile : MonoBehaviour
{
    GroundSpawn groundSpawner;
    public GameObject RoadCut;
    private bool timer;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawn>();
    }

    private void OnTriggerExit(Collider cola) //cola обьект, который сталкиваетс€
    {
        if (cola.gameObject.tag == "Player" & !timer)
        {           
            timer = true;
            groundSpawner.SpawnTile();
            Destroy(RoadCut, 10); //врем€ до дестро€
        }
    }  
}
