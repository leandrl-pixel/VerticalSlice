# GDIM33 Vertical Slice
## Milestone 1 Devlog
1. one visual script graph that I used to control the players movement state was through a state machine. The graph has 3 different states that are idle, move, and airbone( jump). The transitions between these states are all based on the players movment inputs and if the player is on the ground. For example when the player presses a movement key the input value changes and the state transistions back to idle. The graph uses if statemes to see if the absolute value of movment based on the input of the player to determine when to switch states. Each state triggers a visual change by changing the players color when they are entering a state, which helps to check if the state machine is functioning right during gameplay, there is also debug logs in place to ensure as well that everything is working as intended. 
2. Updated my break down by adding the player state machine that is responsible for tracking the players state that includes the idle, move, and airborne state. While the movement itself is handled by my C# script the state machine checks to see the input of the player and grounds stat to see if which state the player should be in. 
3. the state machine is connect to my palyers movmeent system script due to how it reacts to the same inputs for moving. When the inpit changes from zero to no longer zero the state machine goes from idle to move. Not only that but each state changes the player apperance in color by changing the colors sprite of the player. This gives visible feedback to the state machine so it works and this demonstrates how it works with out systems in the game like inputs being handle and the movements. 
## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
