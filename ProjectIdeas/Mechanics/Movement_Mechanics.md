### MOVEMENT:
#### Move right
Can direct the player to 'right' direction with one little press, with a longer press the player moves towards 'right'
direction with a 'walking' velocity.

#### Move left
Can direct the player to 'left' direction with one little press, with a longer press the player moves towards 'left'
direction with a 'walking' velocity.

#### Crouch
Player must maintain the button pressed to remain crouched; when crouching, the player's hit-box and the velocity
reduces to half.

#### Up
When pressing the button, the player looks-up (camera shows top of the screen that was hidden before that) and if the
player is on 'hold', ends up climbing the surface.

#### Run
Player must maintain the button pressed to keep running and choose a direction to move ('move_right' or 'move_left'); 
when running, the player's velocity doubles.
- **YoungVersion (YV):** YV velocity gives the sensation of speed.
- **GrownVersion (GV):** velocity is 2/5 slower than the YV.

#### Jump
The height of the jump depends on the intensity/time of the button press; the longer the pressing, the higher the jump.
- **YV:** YV jumping gives the sensation of lightness.
- **GV:** maximum height is 2/5 lower than the YV.

#### Double jump (YoungVersion)
Can redo 'jump' with the same intensity as the previous, but can't repeat until next rest (when touching the ground with
feet or 'hold').

#### Hold (PassiveMechanic)
PASSIVE-MECHANIC: When facing a 'holding tile', the player automatically grabs the surface; when holding, the previous
jump resets.
