using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initalize object of ClassTicTacToe.
        /// </summary>
        ClassTicTacToe Game;
        /// <summary>
        /// Constructor for main window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Game = new ClassTicTacToe();
        }
        /// <summary>
        /// The button that starts the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Game_Button(object sender, RoutedEventArgs e)
        {
            Game.Start_Game_Function();
            Update_Gui();
        }
        /// <summary>
        /// The button that resets the game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Game_Button(object sender, RoutedEventArgs e)
        {
            // game logic for resting game
            Game.Reset_Game_Values();
            Update_Gui();
        }
        /// <summary>
        /// Connected to all the tiles in the tic-tac-toe game and updates the tiles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Game.Update_Array_TicTacToe(Grid.GetRow(button), Grid.GetColumn(button));
            Game.Check_For_Win();
            Game.Check_For_Tie();
            Update_Gui();
        }
        /// <summary>
        /// Function that updates the gui after every button click.
        /// </summary>
        private void Update_Gui()
        {
            int Player1Wins;
            int Player2Wins;
            int PlayerTies;
            byte[,] TicTacToeBoard;
            byte[,] TicTacToeBoardHighlight;
            bool GameActivate;
            int PlayerTurn;
            int PlayerWin;
            string[] Dictionary = { "", "X", "O" };
            string[] DictionaryHighlight = {"White" , "Yellow" };
            string GameStatus;

            Game.Get_Game_Stats(out Player1Wins,out Player2Wins,out PlayerTies, out TicTacToeBoard, out TicTacToeBoardHighlight,out GameActivate,out PlayerTurn,out PlayerWin, out GameStatus);
            Label_Player_1_Wins.Content = "Player 1 Wins: " + Player1Wins;
            Label_Player_2_Wins.Content = "Player 2 Wins: " + Player2Wins;
            Label_Player_Ties.Content = "Ties: " + PlayerTies;
            Label_Game_Status.Content = GameStatus;
            string ButtonName;
            Button Button;
            BrushConverter BrushConverter = new BrushConverter();
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    ButtonName = "Button_" + i.ToString() + j.ToString();
                    Button = (Button)FindName(ButtonName);
                    Button.Content = Dictionary[TicTacToeBoard[i, j]];
                    Button.Background = (Brush)BrushConverter.ConvertFromString(DictionaryHighlight[TicTacToeBoardHighlight[i, j]]);
                }
            }
        }
    }
}