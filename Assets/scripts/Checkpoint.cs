using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private GameMaster gm;
    
    // Start is called before the first frame update
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            gm.lastCheckPointPosition = transform.position;
        }
    }
    // Update is called once per frame
    void Update() {
    }
}