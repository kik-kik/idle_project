using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

    [SerializeField] GameObject prefab;
    GameObject go;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(prefab);
            go.transform.parent = gameObject.transform;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
