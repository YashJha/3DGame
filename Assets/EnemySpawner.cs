using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {


	[SerializeField]
	GameObject player;
	[SerializeField]
	GameObject SpawnerPoint;
	[SerializeField]
	GameObject enemy;
    [SerializeField]
    GameObject alarmLight;

	public float spawnTime = 5.0f;
	public bool playerHere;
	private Light myLight;

	void start()
	{
		myLight = GetComponent<Light> ();
		myLight.enabled = !myLight.enabled;
	}
    void Update()
    {
		if (playerHere == true)
        {						
            spawnTime -= Time.deltaTime;
            Debug.Log("this works.");

			if (spawnTime > 0f) 
			{
				return;
			} 
			else 
			{
				spawnTime = 5.0f;
				SpawnEnemy ();
			}
        }
		if (playerHere == false)
        {
            
        }
    }
	
	void SpawnEnemy () {
        
        GameObject go = Instantiate(enemy, SpawnerPoint.transform.position, Quaternion.identity) as GameObject;
		go.transform.position = SpawnerPoint.transform.position;
		go.GetComponent<Enemy>().Damage(10, player.transform);
	}
	void OnTriggerStay(Collider other)
	{

		playerHere = true;

	}

	void OnTriggerExit(Collider other)
	{

		playerHere = false;

	}
}
