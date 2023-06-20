using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
  
    public GameObject enemy;
    float randx;
    Vector2 WhereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    
     
    // Start is called before the first frame update

    void Start(){
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn){
          nextSpawn = Time.time + spawnRate;
          randx = Random.Range(-10f,10f);
          WhereToSpawn = new Vector2(randx,transform.position.y);
          Instantiate (enemy,WhereToSpawn,Quaternion.identity);
      } 
    }

    
}
