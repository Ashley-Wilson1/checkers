# checkers


A simple yet effective implementation of Checkers in C#. This game supports both two-player mode and single-player mode against an AI opponent that uses the Minimax algorithm. The game also features move history tracking using a stack, allowing players to undo moves, as well as file-based save/load functionality.

## Features

- **Two-player mode**: Play against another person.
- **Single-player mode**: Play against an AI opponent that makes decisions using the Minimax algorithm.
- **Undo functionality**: A stack is used to keep track of previous game states, allowing players to revert moves.
- **Save and load game**: The game state can be written to and read from a file, enabling players to resume matches later.
- **Basic GUI made using winforms**: The game runs in a winforms window.

## How It Works

### Move Undo (Stack-Based Approach)
The game maintains a stack of previous board states. When a move is made, the current board is pushed onto the stack. If a player decides to undo a move, the last saved state is popped from the stack and restored.

### AI Opponent (Minimax Algorithm)
The AI opponent uses the Minimax algorithm to evaluate possible moves and select the best one. It considers multiple turns ahead and minimizes potential losses while maximizing potential gains.

### Saving and Loading Games
Game states are stored in a file, allowing players to save their progress and load it later. The game reads from and writes to a file in a structured format to ensure game continuity.

## Screenshots

### The main menu 
![image](https://github.com/user-attachments/assets/1b528b3d-caba-4ad2-8d6f-2840f54b0727)
### how the game looks
![image](https://github.com/user-attachments/assets/da6724f0-f8a4-4baa-b0f3-1bbe11e02d80)
### ability to move/take
![image](https://github.com/user-attachments/assets/4b82be75-2753-4823-a4e6-68a174c78772)
### ability to double take pieces
![image](https://github.com/user-attachments/assets/571859c7-bfb2-4c05-9375-bd7d7bd1f8f4)
### you're able to make your piece a king
![image](https://github.com/user-attachments/assets/c30decc9-622c-4f8f-8340-8f829e073fbe)
### king can make moves backwords
![image](https://github.com/user-attachments/assets/d9c164d9-1db6-45e9-b1ac-48a83314b1bf)
### when the games over (you can also draw but this is really hard to replicate in checkers)
![image](https://github.com/user-attachments/assets/438dfc05-9c8c-4aa8-9d4a-93f260016b64)
### when you load a previously saved game
![image](https://github.com/user-attachments/assets/d04a2e46-769f-4729-b4c1-bf72f92d37e9)
