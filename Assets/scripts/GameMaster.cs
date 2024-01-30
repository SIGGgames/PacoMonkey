using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    private static GameMaster _instance;
    public Vector2 lastCheckPointPosition;
    
    
    void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }
}