using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment4
{
    /// <summary>
    /// The class that contains all the logic for the tic-tac-toe game
    /// </summary>
    public class ClassTicTacToe
    {
        /// <summary>
        /// Keeps track of player 1 wins.
        /// </summary>
        private int IntPlayer1Wins = 0;

        /// <summary>
        /// Keeps track of player 2 wins.
        /// </summary>
        private int IntPlayer2Wins = 0;

        /// <summary>
        /// Keeps track of player ties.
        /// </summary>
        private int IntPlayerTies = 0;

        /// <summary>
        /// Keeps track of number of squares that are filled with X's or O's.
        /// </summary>
        private int IntSquaresFilled = 0;

        /// <summary>
        /// <para>The array that will contain the tic-tac-toe board.</para>
        /// <para>0 means no value.</para>
        /// <para>1 means there is a X.</para>
        /// <para>2 means that there is a O.</para>
        /// </summary>
        private byte[,] ArrayTicTacToeBoard;

        /// <summary>
        /// <para>Keeps track of which squares need to be highlighted.</para>
        /// <para>0 means normal.</para>
        /// <para>1 means highlight.</para>
        /// </summary>
        private byte[,] ArrayTicTacToeBoardHighlight;

        /// <summary>
        /// Boolean for keeping track if the game is active.
        /// </summary>
        private bool BooleanGameActive = false;

        /// <summary>
        /// Constant for maximum number of rows.
        /// </summary>
        private const int Max_Rows_Const = 3;

        /// <summary>
        /// Constant for maximum number of columns.
        /// </summary>
        private const int Max_Columns_Const = 3;

        /// <summary>
        /// String that keeps track of the game status.
        /// </summary>
        private string StringGameStatus = "Game has not started yet";

        /// <summary>
        /// Enum for represnting the values of the array in tic-tac-toe board.
        /// </summary>
        private enum StateEnum
        {
            Nothing=0,
            X=1,
            O=2,
        }
        /// <summary>
        /// <para>Enum that keeps track of player turn.</para>
        /// <para>Nobody's turn is 0.</para>
        /// <para>X turn is 1.</para>
        /// <para>O turn is 2</para>
        /// </summary>
        StateEnum EnumPlayerTurn = StateEnum.Nothing;
        /// <summary>
        /// <para>Enum that keeps track of who won.</para>
        /// <para>Nobody winning is 0.</para>
        /// <para>X winning is 1.</para>
        /// <para>O winning is 2</para>
        /// </summary>
        StateEnum EnumPlayerWin = StateEnum.Nothing;
        /// <summary>
        /// Constructor for ClassTicTacToe, sets ArrayTicTacToeBoard values to 0.
        /// </summary>
        public ClassTicTacToe()
        {
            ArrayTicTacToeBoard = new byte[3, 3];
            ArrayTicTacToeBoardHighlight = new byte[3, 3];
            for (byte i = 0; i < Max_Rows_Const; i++)
            {
                for (byte j = 0; j < Max_Columns_Const; j++)
                {
                    ArrayTicTacToeBoard[i, j] = 0;
                    ArrayTicTacToeBoardHighlight[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// Resets all the values of the game.
        /// </summary>
        public void Reset_Game_Values()
        {
            StringGameStatus = "Game has not started yet";
            IntPlayer1Wins = 0;
            IntPlayer2Wins = 0;
            IntPlayerTies = 0;
            IntSquaresFilled = 0;
            for (byte i = 0; i < Max_Rows_Const; i++)
            {
                for (byte j = 0; j < Max_Columns_Const; j++)
                {
                    ArrayTicTacToeBoard[i, j] = 0;
                    ArrayTicTacToeBoardHighlight[i,j] = 0;
                }
            }
            BooleanGameActive = false;
            EnumPlayerTurn = StateEnum.Nothing;
            EnumPlayerWin = StateEnum.Nothing;
        }
        /// <summary>
        /// Sets the starting values of the game.
        /// </summary>
        public void Start_Game_Function()
        {
            StringGameStatus = "Game has started\nPlayer 1 turn";
            BooleanGameActive = true;
            EnumPlayerTurn = StateEnum.X;
            EnumPlayerWin = StateEnum.Nothing;
            IntSquaresFilled = 0;
            for (byte i = 0; i < Max_Rows_Const; i++)
            {
                for (byte j = 0; j < Max_Columns_Const; j++)
                {
                    ArrayTicTacToeBoard[i, j] = 0;
                    ArrayTicTacToeBoardHighlight[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// Updates the array values.
        /// </summary>
        /// <param name="row_int"></param>
        /// <param name="column_int"></param>
        public void Update_Array_TicTacToe(int row_int, int column_int)
        {
            // Check if game started
            if (BooleanGameActive == true)
            {
                if (ArrayTicTacToeBoard[row_int,column_int] == (byte)StateEnum.Nothing)
                {
                    ArrayTicTacToeBoard[row_int, column_int] = (byte)EnumPlayerTurn;
                    IntSquaresFilled++;
                    if (EnumPlayerTurn == StateEnum.X)
                    {
                        StringGameStatus = "Player 2 turn";
                        EnumPlayerTurn = StateEnum.O;
                    }
                    else if (EnumPlayerTurn == StateEnum.O)
                    {
                        StringGameStatus = "Player 1 turn";
                        EnumPlayerTurn = StateEnum.X;
                    }
                }
            }
        }
        /// <summary>
        /// Checks ArrayTicTacToeBoard for wins horizontally.
        /// </summary>
        private void Check_Horizontal()
        {
            if (ArrayTicTacToeBoard[0,0] == (byte)StateEnum.X && 
                ArrayTicTacToeBoard[0,1] == (byte)StateEnum.X && 
                ArrayTicTacToeBoard[0,2] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[0, 0] = 1;
                ArrayTicTacToeBoardHighlight[0, 1] = 1;
                ArrayTicTacToeBoardHighlight[0, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 0] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[0, 1] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[0, 2] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[0, 0] = 1;
                ArrayTicTacToeBoardHighlight[0, 1] = 1;
                ArrayTicTacToeBoardHighlight[0, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[1, 0] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[1, 2] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[1, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[1, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[1, 0] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[1, 2] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[1, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[1, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[2, 0] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[2, 1] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[2, 2] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[2, 0] = 1;
                ArrayTicTacToeBoardHighlight[2, 1] = 1;
                ArrayTicTacToeBoardHighlight[2, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[2, 0] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[2, 1] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[2, 2] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[2, 0] = 1;
                ArrayTicTacToeBoardHighlight[2, 1] = 1;
                ArrayTicTacToeBoardHighlight[2, 2] = 1;
                return;
            }
        }
        /// <summary>
        /// Checks ArrayTicTacToeBoard for wins vertically.
        /// </summary>
        private void Check_Vertical()
        {
            if (ArrayTicTacToeBoard[0, 0] == (byte)StateEnum.X &&
                ArrayTicTacToeBoard[1, 0] == (byte)StateEnum.X &&
                ArrayTicTacToeBoard[2, 0] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[0, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 0] = 1;
                ArrayTicTacToeBoardHighlight[2, 0] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 0] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[1, 0] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[2, 0] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[0, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 0] = 1;
                ArrayTicTacToeBoardHighlight[2, 0] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 1] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[2, 1] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[0, 1] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[2, 1] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 1] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[2, 1] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[0, 1] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[2, 1] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 2] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[1, 2] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[2, 2] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[0, 2] = 1;
                ArrayTicTacToeBoardHighlight[1, 2] = 1;
                ArrayTicTacToeBoardHighlight[2, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 2] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[1, 2] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[2, 2] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[0, 2] = 1;
                ArrayTicTacToeBoardHighlight[1, 2] = 1;
                ArrayTicTacToeBoardHighlight[2, 2] = 1;
                return;
            }
        }
        /// <summary>
        /// Checks ArrayTicTacToeBoard for wind diagonally.
        /// </summary>
        private void Check_Diagonal()
        {
            if (ArrayTicTacToeBoard[0,0] == (byte)StateEnum.X &&
                ArrayTicTacToeBoard[1,1] == (byte)StateEnum.X &&
                ArrayTicTacToeBoard[2,2] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer1Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[0, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[2, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[0, 0] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.O &&
                     ArrayTicTacToeBoard[2, 2] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[0, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[2, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[2, 0] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.X &&
                     ArrayTicTacToeBoard[0, 2] == (byte)StateEnum.X)
            {
                StringGameStatus = "X has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.X;
                ArrayTicTacToeBoardHighlight[2, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[0, 2] = 1;
                return;
            }
            else if (ArrayTicTacToeBoard[2, 0] == (byte)StateEnum.O &&
                    ArrayTicTacToeBoard[1, 1] == (byte)StateEnum.O &&
                    ArrayTicTacToeBoard[0, 2] == (byte)StateEnum.O)
            {
                StringGameStatus = "O has won!";
                BooleanGameActive = false;
                IntPlayer2Wins++;
                EnumPlayerWin = StateEnum.O;
                ArrayTicTacToeBoardHighlight[2, 0] = 1;
                ArrayTicTacToeBoardHighlight[1, 1] = 1;
                ArrayTicTacToeBoardHighlight[0, 2] = 1;
                return;
            }
        }
        /// <summary>
        /// Checks for wins with sub functions for checking different sections.
        /// </summary>
        public void Check_For_Win()
        {
            if (BooleanGameActive)
            {
                Check_Vertical();
            }
            if (BooleanGameActive)
            {
                Check_Horizontal();
            }
            if (BooleanGameActive)
            {
                Check_Diagonal();
            }
        }
        /// <summary>
        /// Checks for a tie.
        /// </summary>
        public void Check_For_Tie()
        {
            if (IntSquaresFilled >= 9 && EnumPlayerWin == StateEnum.Nothing)
            {
                StringGameStatus = "The players tied!";
                BooleanGameActive = false;
                IntPlayerTies++;
                EnumPlayerWin = StateEnum.Nothing;
            }
        }
        /// <summary>
        /// <para>Gets the game status so that the gui can update it.</para>
        /// <para>All parameters are pass by reference.</para>
        /// </summary>
        /// <param name="Player1Wins"></param>
        /// <param name="Player2Wins"></param>
        /// <param name="PlayerTies"></param>
        /// <param name="TicTacToeBoard"></param>
        /// <param name="GameActive"></param>
        /// <param name="PlayerTurn"></param>
        /// <param name="PlayerWin"></param>
        /// <param name="GameStatus"></param>
        public void Get_Game_Stats(out int Player1Wins, out int Player2Wins, out int PlayerTies, out byte[,] TicTacToeBoard,out byte[,]TicTacToeBoardHighlight, out bool GameActive, out int PlayerTurn, out int PlayerWin, out string GameStatus)
        {
            Player1Wins = IntPlayer1Wins;
            Player2Wins = IntPlayer2Wins;
            PlayerTies = IntPlayerTies;
            TicTacToeBoard = ArrayTicTacToeBoard;
            TicTacToeBoardHighlight = ArrayTicTacToeBoardHighlight;
            GameActive = BooleanGameActive;
            PlayerTurn = (int)EnumPlayerTurn;
            PlayerWin = (int)EnumPlayerWin;
            GameStatus = StringGameStatus;
        }
    }
}
