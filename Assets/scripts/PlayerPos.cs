using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour {
    private GameMaster gm;
    
    // Start is called before the first frame update
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPosition;
    }

    // Update is called once per frame
    void Update() {
    }
    
    public void RespawnAtLastCheckpoint() {
        transform.position = gm.lastCheckPointPosition;
    }
}