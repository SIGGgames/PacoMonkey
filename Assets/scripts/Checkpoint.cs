using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private GameMaster _gm;
    
    // Start is called before the first frame update
    void Start() {
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _gm.lastCheckPointPosition = transform.position;
        }
    }
    // Update is called once per frame
    void Update() {
    }
}