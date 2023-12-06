using System.Collections;
using UnityEngine;

public class Utils : MonoBehaviour {
    // This class contains utility methods for the game.
    // IMPORTANT: All methods need to be static.

    /**
     * CheckJumpStatus(): Returns the status of the jump button
     * Return 0: Not jumping
     * Return 1: Pressed Jump
     * Return 2: Pressed Jump Down
    */
    public static int GetJumpStatus() {
        bool jumpKey = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool jumpKeyDown = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) ||
                           Input.GetKeyDown(KeyCode.UpArrow);

        if (jumpKey) {
            return 1;
        }

        if (jumpKeyDown) {
            return 2;
        }

        return 0;
    }
}