# Five In a Row

## User Documentation
- Five In a Row is also called [Gomoku](https://en.wikipedia.org/wiki/Gomoku)
- This is the freestyle version - winning line can be longer than 5
- Player has blue crosses, Bot has red circles
- To make a move, click on an empty cell
- After game over, you can click "RESET" for new game and now will start the party that didn't start last time

## Developer Big Picture Documentation
This project uses the MVC Architecture and Events
- *GameForm.cs* is the View, it is a WinForms Form. Other classes except *Program.cs* don't know that this class exists.
- *Game.cs* is the Controller and contains the game logic.
- *Board.cs* is the Model, it has no references to other classes
- *Bot.cs* is also Model and contains the simple Minimax AI of the enemy, it's just a static function class and only knows about *Board* class
- *Program.cs* - only for startup, here we connect events and listeners.

## Events
*Board* raises event *Changed* and *Game* raises event *GameOver*, both are processed only by *GameForm*. The subscriptions are given in Program.cs so that other classes don't need a reference to *GameForm*.

## Class Diagram
![Class Diagram](ClassDiagram1.png)

## How the Bot works
It is Minimax algorithm using [alpha-beta pruning](https://en.wikipedia.org/wiki/Alpha%E2%80%93beta_pruning).
### Evaluation function
It can evaluate a state of the board to be 
- *Good* - Bot must win
- *Bad* - Bot must lose
- *Neutral* - no one can win in the next move

Board's evaluation is based on each cell's evaluation. If every cell is evaluated Neutral, whole board is evaluated Neutral.
If one cell is evaluated differently, board gets its evaluation and the function immediately returns it.

Cell's evaluation is based on the lines it is contained in. (line = sequence of cells of the same non empty type)
All factors are:
- Length of the line
- Whether the line has zero, one or two open ends
- Whether the line is made of Os or Xs
- Who plays next


