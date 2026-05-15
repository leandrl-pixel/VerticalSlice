# GDIM33 Vertical Slice
## Milestone 1 Devlog
1. one visual script graph that I used to control the players movement state was through a state machine. The graph has 3 different states that are idle, move, and airbone( jump). The transitions between these states are all based on the players movment inputs and if the player is on the ground. For example when the player presses a movement key the input value changes and the state transistions back to idle. The graph uses if statemes to see if the absolute value of movment based on the input of the player to determine when to switch states. Each state triggers a visual change by changing the players color when they are entering a state, which helps to check if the state machine is functioning right during gameplay, there is also debug logs in place to ensure as well that everything is working as intended. 
2. Updated my break down by adding the player state machine that is responsible for tracking the players state that includes the idle, move, and airborne state. While the movement itself is handled by my C# script the state machine checks to see the input of the player and grounds stat to see if which state the player should be in. 
3. the state machine is connect to my palyers movmeent system script due to how it reacts to the same inputs for moving. When the inpit changes from zero to no longer zero the state machine goes from idle to move. Not only that but each state changes the player apperance in color by changing the colors sprite of the player. This gives visible feedback to the state machine so it works and this demonstrates how it works with out systems in the game like inputs being handle and the movements. Other things I also updated where implementing a camera system, updated tilemaps for traps, animation, adjusted movement description, in another slide I added a further breakdown of my state machine for player. 
4. [Link to breakdown](https://docs.google.com/presentation/d/1RuzYXJ6dxNTkSLQ3StovZiLTZW3L8R6wfxqp0pSv3B8/edit?usp=sharing)
## Milestone 2 Devlog
### Before Coding: complicating feature summary and the task breakdown 
#### Complicated Gameplay Feature 
1. The complicating gameplay feature for my platformer is a star powerup that grants the player one extra jump. This temporary ability allows the player to reach higher platforms that are normally impossible to clear with the normal jump alone. The powerups turns a standard platforming section into a small puzzle because the player must first collect the star and then use the extra jump wisely to continue.
##### Big Step 1: Create the star Powerup pickup 
1. Create a star GameObject with a SpriteRenderer and CircleCollider2D. If you dont have one use a placeholder circle sprite 
2. Set the CircleCollider2D to Is Trigger.
3. Add a Script Machine and create a Visual Scripting graph.
4. Detect when the player enters the trigger.
5. Check if the colliding object has the Player tag.
6. Test by printing a Debug.Log when the player touches the star.
##### Step 2 
1.Add a public Boolean variable hasExtraJump to PlayerMovementV1.cs.
2. In the Visual Scripting graph  get the player's PlayerMovementV1 component.
3. Set hasExtraJump to true.
4. Disable the star game object so it disappears.
5. Test by confirming the variable changes in the Inspector.
##### Step 3 
1. Update the jump logic to check for hasExtraJump while airborne.
2. Allow one additional jump if the variable is true.
3.Set hasExtraJump back to false after the extra jump is used.
4.Build a platforming section that requires the extra jump.
5. Test by collecting the star gameobject and reaching the higher platform.
### Visual scripting  graph: moon poweerup
1. One of the main Visual Scripting graphs in my game controls a star power that grants the player a temporary extra jump. The power up object uses a trigger collider and a Script Machine. When the player enters the trigger the graph checks whether the object has the Player tag using a Compare Tag node. If the condition is true then the graph gets the player's PlayerMovementV1 component and sets the hasExtraJump Boolean variable to true. This variable is defined in my C# movement script and allows the player to perform one extra jump while airborne. After activating the powerup the start object disables itself so it disappears from the level. This graph bridges Visual Scripting with code because the graph directly uses a public variable in my C# script and influences it
2. <img width="1918" height="957" alt="Screenshot 2026-05-15 154919" src="https://github.com/user-attachments/assets/b4de1b2e-53b3-4e03-b23d-770f32584541" />
3. Another visual scripting is my state graph I used it to controls the players idle, move, and airborne states. The state graph reads the public variables of moveinput and siGrounded from my PlayerMovementV1 script to see when the transistion between states. Earlier i did this but the states changes based on the color both visually and animation wise, back when i did not have animations I used colors to signify the different states if they were working properly. This provides visual feedback meaning that the state machine si working 
### Unity system Graded 
1. The unity system that I would like to be graded on is the animator system. Its shown when the player dies and loses all there health, the death animation happens and they remain in the dead state for a short amount of time and then it goes back to normal (idle) after the player respawns in their current checkpoint. 
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
