using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public GameObject Enemy;
    public float numEnemies = 30f;

    private GameObject[] _spawns;
    private List<GameObject> _enemies = new List<GameObject>();

	// Use this for initialization
	void Start () {
        _spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for (int i = 0;i < numEnemies; i++) {
            GameObject spwn = _spawns[Random.Range(0, _spawns.Length-1)];
            GameObject en = Instantiate(Enemy, spwn.transform.position, Quaternion.identity) as GameObject;
            _enemies.Add(en);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    for(int i = 0; i < numEnemies; i++) {
            if(_enemies[i].gameObject.activeInHierarchy == false) {
                GameObject spwn = _spawns[Random.Range(0, _spawns.Length - 1)];
                _enemies[i].transform.position = spwn.transform.position;
                _enemies[i].SetActive(true);
            }
        }
	}
}
