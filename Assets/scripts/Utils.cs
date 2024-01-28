using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {
    // This class contains utility methods for the game.
    // IMPORTANT: All methods need to be static.
    
    /**
     * GetJumpInput(): Returns a boolean value indicating whether the player has pressed any jump keys
     */
    public static bool GetJumpInput() {
        return Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    }
}