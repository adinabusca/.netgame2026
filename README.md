# Hunting the Wren - 2D Game Implementation

A 2D game project developed in **C#** using the **Silk.NET** library. The game features a player-controlled fox attempting to catch an automated bird NPC.

### Core Mechanics:
*   **The Hunt:** The player (Fox) must time jumps and movement to collide with the NPC (Bird).
*   **Game Over State:** Reaching the bird triggers a collision event that stops the game logic and logs the victory to the console.

## Technical Features

### 1. Game Architecture
*   **Object-Oriented Hierarchy:** Uses a robust inheritance structure:
    `GameObject` → `RenderableGameObject` → `AnimatedGameObject` → `PlayerObject/BirdObject`.
*   **Game Loop:** Implements a classic `Process Input` -> `Update Logic` -> `Render Frame` cycle.
*   **Thread-Safety:** Uses `Interlocked.Increment` for generating unique IDs for every game entity.

### 2. Graphics & Animation
*   **Hardware Acceleration:** Utilizes SDL2's `RenderCopy` for GPU-side drawing.
*   **Sprite Sheet Slicing:** A custom `SpriteSheet` class handles UV mapping/coordinate math to extract frames from a grid texture.
*   **State-Based Animation:** Dynamically switches textures and frame counts when the player changes state (e.g., from Idle to Walk).

##  Controls
*   **A / D**: Move Left / Right
*   **Space**: Jump (Press twice for Double Jump)
*   **Close Window**: Exit Game

