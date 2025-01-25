References:

Used for level design:
Pixel Frog. (n.d.). Pixel Adventure 1. Unity Asset Store. 
link: https://assetstore.unity.com/packages/2d/characters/pixel-adventure-1-155360

Used for Audio references:
Unity Technologies. (2024). Free Dungeon Music Pack [Audio music pack]. 
Unity Asset Store. https://assetstore.unity.com/packages/audio/music/free-dungeon-music-pack-301447

Used for Main character:
Ng, K. (n.d.). Knight sprite sheet (free). Unity Asset Store.
Retrieved from https://assetstore.unity.com/packages/2d/characters/knight-sprite-sheet-free-93897

Used UI elements:
MiMU Studio. (n.d.). 2D Casual UI HD. Unity Asset Store. Retrieved December 5, 2024, 
from https://assetstore.unity.com/packages/2d/gui/icons/2d-casual-ui-hd-82080



Research materials:

While most of the references are taken from the lecture notes and recordings. Some external resources and research materials are listed below:

Video tutorial:
Pandemonium. (n.d.). Unity 2D Platformer for Complete Beginners [YouTube playlist]. YouTube. Retrieved December 9, 2024, 
from https://www.youtube.com/playlist?list=PLgOEwFbvGm5o8hayFB6skAfa8Z-mw4dPV

Code documentation:
Unity Technologies. (n.d.). Unity scripting API. Unity. Retrieved December 9, 2024, 
from https://docs.unity3d.com/ScriptReference/index.html

Project overview:

The title of the game is Knight dungeon. The game transitions from main menu scene to level one from which after reaching
end of level one goes to level 2 scene. A knight is used as a main character. This project is focused on understanding the 
functionalities of game development and meeting game design requirements.

GamePlay mechanics, problems and bugs:

Controls:
>Pressing the spacebar allows player to jump, player has the ability to doublejump by pressing the space bar twice
>Animations are used for describing the state of the player.
>Arrow keys and 'A','D' keys control linear movemnt.
>'F' key is used to play attack animation

Mechanics:
>A health bar indicates player's health which decreases when colliding with obstacles, projectiles and enemies.
>when player health reaches 0 or when a cross button is pressed the Game over panel is shown and player movement is restricted.
>Checkpoints are used in such a way that when hit by laser beam player respawns at last checkpoint.
>Laser beams are used using coroutines and raycast.
>A bronze medal indicates a jump boost power up when acquired gives player ability to jump more based on multiplier and duration.
>Main UI panel shows necessary information like a timer and a hearth bar.
>A gold medal indicates a speed boost 
>Colliding with the heart object increases player's health.

Problems and bugs faced and solutions:
>When implementing camera movement the there was jitterness in the gameplay.
    ->Used LateUpdate so that camera moves at a later time than the player which didnt solve the issue
    ->Realised the smooth speed was set to 0 which caused the jitterness so set it to 1 
>Player unexpectedly fillping and dropping likely due to using Vector3 which was not the only cause
    ->Freezing the z axis rotaion did not help so just increased the gravity scale of the player and increased jumpforce to compensate with gravity
>Player not touching the spikes
    ->The player does not visually collide with the spike obstacles, By setting the isTrigger off in the compositie collider the problem can be fixed
      but creates another problem like not depleting health of the player as the collider trigger is off.
>The final timer kept increasing which should show the time of death of the player.
    -> It was caused due to not setting condition on when to run the timer and final time. By using a boolean variable isGameOver and playeing the timer
       text when !isGameOver so it shows the timer when game is not over and in the method GameOver() setting the final timer as timer so it stores the last value of the timer
>This is not a problem but implemented the respawn functionality to trigger when colliding with the laser and game over when player takesenough damage

Bugs that exist:
>The player cannot attack the enemy.
    -> when implementing any 2 advanced features adding enemies showed a lot of errors so switched to executing a power up system and switching level
        but kept the enemy functionality that only patrols a certain distance and attacks the player.
> Once the gameover button is pressed it shows the restart button to restart the scene and after the scene restarts the game over button is no longer functionl.


Instructions:
>Press F to attack
>Press space bar to jump.
>Press space bar twice for double jump.
>Use left and right arrow or 'A','D' kers for movement.





