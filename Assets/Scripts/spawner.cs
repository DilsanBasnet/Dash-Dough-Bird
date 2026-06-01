using UnityEngine;

public class spawner : MonoBehaviour
{
 public GameObject prefab;
 public float spawnrate = 2f;
 public float minHeight = -1f;
 public float maxHeight = 1f;

private float currentSpawnRate;

    private void OnEnable(){
       currentSpawnRate = spawnrate;
       StartSpawning();
    }
    private void OnDisable()
    {
        StopSpawning();
    }
    private  void StartSpawning()
    {
        InvokeRepeating(nameof(Spawn), currentSpawnRate, currentSpawnRate);
     }
     public void UpdateSpawnRate()
    {
        StopSpawning();
        currentSpawnRate = spawnrate * (5f / Pipes.speed);
        StartSpawning();
    }
    private void StopSpawning()
    {
       CancelInvoke(nameof(Spawn));
    }
   
    
 

    private void Spawn(){
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position = transform.position + (Vector3.up * Random.Range(minHeight, maxHeight));
    }
}
