using System.Collections;
using UnityEngine;

public class Utils : MonoBehaviour {
    // This class contains utility methods for the game.
    // IMPORTANT: All methods need to be static.
    
    /**
     * CheckJumpStatus(): Returns the status of the jump button
     * Return 0: Not jumping
     * Return 1: Start jumping
     * Return 2: Continue jumping (double jump)
    */
    public static int GetJumpStatus() {
        bool jumpButtonDown = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) ||
                              Input.GetKeyDown(KeyCode.UpArrow);
        bool jumpButtonHeld = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (jumpButtonDown) {
            return 1;
        }

        if (jumpButtonHeld) {
            return 2;
        }

        return 0;
    }
}