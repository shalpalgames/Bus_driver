using UnityEngine;


public class GroundSpawn : MonoBehaviour
{

    public GameObject[] RoadSpawns;
    Vector3 nextSpawnPoint;
    

    void Start()
    {
            SpawnTile();            
            SpawnTile();            
                      
            
    }
   
    public void SpawnTile()
    {       
        int RoadIndex = Random.Range(0, RoadSpawns.Length);
        GameObject temp = Instantiate(RoadSpawns[RoadIndex], nextSpawnPoint, RoadSpawns[RoadIndex].transform.rotation);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;      
    }
}
