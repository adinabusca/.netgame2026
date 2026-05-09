# AI Usage Disclosure

This project was developed with limited AI tools usage mainly for debugging and code suggestions in accordance with the assignment rules.

## Tools Used
-**ChatGPT (GPT-5.3-mini,free version)**
  used for:
   - debugging assistance 
   - suggestions for code improvements
   
-**Google Gemini (Gemini for Students, free version)**
  used for:
   - clarification for some of the code provided in the labs
   - additional suggestions for code logic
   - rubber-ducking 

## How AI Was Used

AI tools were used as learning and support assistants, not as primary code generators.

### 1.Understanding and Learning
 - Helped in learning how delta time affects movements and updates as well as the physics regarding the jumps of the playable character
 - Clarified collision detection logic (AABB overlap)

### 2.Code Suggestions and Debugging
 - Helped identify and fix issues in update flow and input handling

### 3. AI-Assisted Implementations
The following parts of the projects were created with the assistance of AI and then reviewed and understood by me:
  - **Models\AnimatedGameObjects.cs** file : the UpdateAnimation(double deltaTime, double speed = 100) function
  - **Models\SpriteSheet.cs** file: the GetFrame(int f, int r) function
  - **GameLogic.cs** file: the Collides(Rectangle<int> a, Rectangle<int> b) function

I understood how these work before integrating them into my project so that I can modify them if need be.

## Authorship Statement
The overall project structure and most gameplay logic was written by me using the lab materials and the project structure provided during the live implementation sessions during the labs.


