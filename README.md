# Tic-Tac-Toe Game
![Screenshot 2024-12-30 151333](https://github.com/user-attachments/assets/ba73025f-1854-4f59-9663-b308f71d5535)
## Description

The Tic-Tac-Toe Game is a Windows Forms or WPF application that allows two players to play a game of Tic-Tac-Toe. The application includes a user-friendly interface for selecting board spaces, tracking game status, and displaying the results. A dedicated class is used to encapsulate the game logic, ensuring separation between the UI and business logic.

This project was created as part of a class assignment to demonstrate object-oriented programming principles, encapsulation of game logic, and user interface development using Windows Forms or WPF.
Features

    Interactive Tic-Tac-Toe Board
        Players click on the board spaces to make their moves.
        Spaces update dynamically to display the player's symbol (X or O).

    Game Status Updates
        Displays whose turn it is during the game.
        Updates with a message indicating the game's result (win or tie) once the game ends.

    Winning Move Highlight
        Highlights the winning move when a player wins the game.

    Score Tracking
        Keeps track of:
            Wins for each player.
            Number of tied games.

    New Game Functionality
        Players can click the “Start Game” button to reset the board and begin a new game.

    Game Logic Encapsulation
        Business logic is implemented in a separate class, which:
            Tracks the state of the game board using an array.
            Determines if a player has won, if the game is a tie, or if the game is still ongoing.

How to Use

    Start a Game:
        Click the “Start Game” button to begin a new game.

    Play the Game:
        Players take turns clicking on the board spaces to make their moves.
        The game status section indicates whose turn it is.

    View Results:
        If a player wins, the winning move is highlighted, and the game status displays the winner.
        If the game ends in a tie, the game status indicates a tie.

    Track Scores:
        The application automatically updates the number of wins for each player and the number of ties.

    Start a New Game:
        Click the “Start Game” button to reset the board and start a new game while retaining the score history.

Requirements

    Environment: Windows Forms or WPF application
    Development Tools: Visual Studio (or equivalent)
    Languages and Frameworks: C# and .NET Framework (or .NET Core/5+ for WPF)

Class Design

    Game Logic Class
        Attributes:
            A property to hold the game board (array).
        Methods:
            CheckWin(): Determines if a player has won.
            CheckTie(): Determines if the game has ended in a tie.
            GetGameStatus(): Returns the current game status (ongoing, win, or tie).

    Main Form
        Handles the UI interaction.
        Passes the game board to the logic class for processing.
        Updates the game status and score tracking based on the logic class's results.

Error Handling

    Ensures players cannot overwrite a space that has already been selected.
    Prevents further moves after a game has concluded until a new game is started.

Common Issues Addressed

    Separation of concerns: All game logic is implemented in a separate class.
    Prevented UI logic from directly handling game rules.
    Properly updated the game status after each move.
    Ensured the winning move is clearly highlighted.
