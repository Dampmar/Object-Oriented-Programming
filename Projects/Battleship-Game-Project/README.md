# Homework 3, Object Oriented Programming - Upgraded Battleship Game
This is a Battleship Game (Minimized Version) developed in C# as the first homework for Object Oriented Programming 

By: Daniel Marin 
## Table of Contents 

•⁠  ⁠[Introduction](#introduction)

•⁠  ⁠[Gameplay](#gameplay)

•⁠  ⁠[Installation](#installation)

•⁠  ⁠[Usage](#usage)

•⁠  ⁠[Code Structure](#code-structure)

•⁠  ⁠[Acknowledgments](#acknowledgments)


## Introduction
Battleship is classic board game in which each player takes turns guessing coordinates with the purpose of trying to sink the ships of the other. For this homework we where supposed to improve the developed code from Homework 1. Giving it more functionality and components, *extending it*. 

## Gameplay
- This game consists of a 9x9 grid (can be modified for less or more sizes).
- The user takes turns guessing the coordinates of where the ships are. 
- The game ends when all of the ships are sank. 

## Installation
To play this game various things must be done beforehand:
1. *Clone the Repository*:
    git clone https://github.com/Dampmar/Homework3_OOP.git 

2. *Navigate the Project Directory*:
    cd BattleshipGame

3. *Open the Project in your preferred C# IDE*

4. *Build the Project*

## Usage
1. *Run the Application* in your C# IDE.
2. Follow the prompts in the console to enter the coordinates where you want to place a bullet.
3. Continue attacking until all ships are sank or you choose to close the application.

### How to Play
- The coordinates must be written as: A1 or B3 (Letters represent colums and numbers represent rows) followed by an enter.
- Coordinates in the posted version range from A - I (columns) and 0 - 8 (rows). Changes to these values can be implemented in the code, but refrain from using more than 10 values.

## Code Structure
- *BattleshipGame Abstract Class*: Contains the game logic and the rules for validating inputs and taking turns. The abstract method of this class is the **void Play()**.
- *PlayerVsPlayer : BattleshipGame Class*: **overrides** the *Play()* method with the sequence in which the game is played when "PvP" is selected (**Two Player Mode**).
- *PlayerVsComp : BattleshipGame Class*: **overrides** the *Play()* method with the sequence in which the game is played when "PvC" is selected (**One Player Mode**).
- *Abstract Class Ship*: contains the main properties of the ship abstractions, has abstract method **IEnumerable<(int row, int col)> GetCoordinates()** since defines the following classes.
- *Ship1D : Ship Class*: contains the logic for creating and getting the coordinates of a one dimensional ship. A single vertical or horizontal line. 
- *Ship2D : Ship Class*: contains the logic for creating and getting the coordinates of a ship with an unfamiliar shape. Shapes can be defined in one of the properties of the *ShipHandler* class.
- *ShipHandler Class*: contains the logic for the creation and the coordination between the list of ships and the grid. Is in charge of basically initializing all the instances of ships and handling them. 
- *Grid Class*: is the class where the actual game takes place, is in charge of just modifying itself based on the inputs of other classes. Get's inputs from the user and the ship handler class. 
- *Notes*: The code is based on a matrix with the following interpretations; 0 = empty space, 1 = ship part, 2 = bullet hit and 3 = bullet miss.

## Acknowledgments 
- This game is based on the classic board game Battleships and on a full implementation done in Python for this game, used this implementation as a reference https://www.youtube.com/watch?v=MgJBgnsDcF0&t=867s.
- Still requieres a valid acknowledgment.
