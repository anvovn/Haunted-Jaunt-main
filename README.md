# CS 480 Assignment 2 - Haunted-Jaunt-main

Team Members: An Vo, Gabriel Sotelo-Silva, Nate Wong, Andrew Martin

Andrew Martin Particle Effects: 
I attached a particle effect to the prefab of the player character. I put a sphere collider around 
the ghost and gargoyle prefabs and then wrote a script so that when the play got within the range
of the sphere it will trigger the effect to run.

Gabriel Sotelo-Silva Dot Product:
I used the dot product to calculate whether the ghost's is facing in the direction of the player's direction. The dot product gets normalized and produces an int between -1 and 1 where -1 means the ghost is looking away, 0 means the ghost is perpendicular, and 1 means that the ghost is looking directly at the player. Given that gameplay wise requiring the ghost to face directly in front of the player doesn't make sense, I only require a value greater than 0.95 for the ghost to begin turning towards the player. The second dot product is utilized to know what direction to turn the ghost to face the player where # > 0 means that the player is to the right so perform a clockwise turn and # < 0 means the player is to the left of the ghost so perform a counter-clockwise turn. Each ghost and player is given a variable to check. One thing to note is that because these ghost have a navigation AI script, it has to be enabled and disabled constantly so that the ghost doesn't remain in the same direction when the player is out of their range. This adds a bit of difficulty to the game since the ghost's detection range move along with their model.
