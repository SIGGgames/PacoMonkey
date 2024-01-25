using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {
    // This class contains utility methods for the game.
    // IMPORTANT: All methods need to be static.


    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    /**
     * GetJumpInput(): Returns a boolean value indicating whether the player has pressed any jump keys
     */
    public static bool GetJumpInput() {
        return Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    }

    public static bool IsNull(object obj) {
        bool isNull = obj == null;
        if (isNull) {
            Debug.Log("The object " + obj + " is null");
        }
        return isNull;
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public static bool IsNotNull(object obj) {
        return !IsNull(obj);
    }
}