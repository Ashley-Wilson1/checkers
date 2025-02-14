using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace checkers_v2//error making double takes and getting king peice error moving into the bottom right square.
{
    
    public partial class Form1 : Form
    {
        public PictureBox[,] board = new PictureBox[8, 8];//display board not the game theory board.
        Board board2 = new Board();//game theory board
        Point[] possibleMoves;
        Point current;
        AI ai;
        TreeNode start;
        TreeNode currentBoard;
        bool againstplayer =true;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void startGame()
        {
            btnSave.Visible = true;
            btnLoad.Visible = true;
            btn_prevMove.Visible = true;
            btn_mainMenu.Visible = true;
            btn_2players.Visible = false;
            btn_easy.Visible = false;
            btn_medium.Visible = false;
            btn_hard.Visible = false;
            label_start.Visible = false;
            label_comp.Visible = false;
            playerText.Visible = true;
            setBoard();
            
            updateBoard();
            changeLabel();
            playerText.ForeColor = Color.Black;
            start = new TreeNode(board2.getGrid(), 0, "red");
            ai = new AI(start);
        }

        public void setBoard()//Initializes the board of picture boxes.
        {
            int size = 75;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    board[x, y] = new PictureBox();
                    board[x, y].Location = new Point(75 + x * size, 100 + y * size);
                    board[x, y].Size = new Size(size, size);
                    board[x, y].BorderStyle = BorderStyle.FixedSingle;
                    board[x, y].Cursor = Cursors.Hand;
                    board[x, y].Visible = true;
                    board[x, y].MouseClick += mouseClick;
                    
                    this.Controls.Add(board[x, y]);
                }
            }
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (board[x, y] == sender)
                        {
                            Point p = new Point(x, y);

                            if (board2.clickable(x, y))
                            {
                                isgamewon();
                                updateBoard();
                                current = new Point(x, y);
                                board[x, y].BackColor = Color.Green;
                                possibleMoves = board2.CalculatePossibleMoves(x, y).getAllItems();

                                if (possibleMoves != null)
                                {
                                    foreach (Point move in possibleMoves)
                                    {
                                        board[move.X, move.Y].BackColor = Color.DarkOrange;
                                    }
                                }
                                
                                
                            }
                            else if (board2.isMoving())
                            {
                                if (board2.CalculatePossibleMoves(current.X, current.Y).getAllItems() != null && board2.CalculatePossibleMoves(current.X, current.Y).getAllItems().Contains(p)) 
                                {
                                    writePrevBoard();
                                    playermove(p);

                                    changeLabel();
                                    updateBoard();
                                    
                                    
                                }
                            }
                            
                        }
                    }
                }
            }
            
        }

       
        public void playerNoMoves()
        {
            bool blackNoMoves = true;

            for(int x =0;x<8;x++)
            {
                for(int y = 0; y < 8; y++)
                {
                    if(board2.getVal(x,y)==1|| board2.getVal(x, y) == 3)
                    {
                        if (board2.CalculatePossibleMoves(x, y) != null)
                        {
                            blackNoMoves = false;
                        }
                    }
                }
            }

            if (blackNoMoves)
            {
                gameWon();
            }
            
        }

        public bool rednomoves()
        {
            bool noMoves = true;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (board2.getVal(x, y) == 1 || board2.getVal(x, y) == 3)
                    {
                        if (!board2.CalculatePossibleMoves(x, y).isEmpty())
                        {
                            noMoves = false;
                        }
                    }
                }
            }
            return noMoves;
        }

        public bool blacknomoves()
        {
            bool noMoves = true;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (board2.getVal(x, y) == 2 || board2.getVal(x, y) == 4)
                    {
                        if (board2.CalculatePossibleMoves(x, y)!=null)
                        {
                            noMoves = false;
                        }
                    }
                }
            }
            return noMoves;
        }

        public void playermove(Point p)
        {
            
            board2.makeMove(current, p);

            if (board2.checkMultimove(p.X, p.Y) && board2.getMadeTake())//checks if he can move again.
            {
                btn_skip.Visible = true;
               
            }
            else
            {
                
                board2.changePlayer();
                btn_skip.Visible = false;
                updateBoard();
                if (!againstplayer)
                {
                    aimove();
                }
            }
            updateBoard();
            isgamewon();
        }

        public void changeLabel()
        {
            if (board2.getPlayer() == "black")//assigns the label to the correct player
            {
                playerText.Text = "PLAYER BLACK";
                playerText.ForeColor = Color.Black;
            }
            else
            {
                playerText.Text = "PLAYER RED";
                playerText.ForeColor = Color.Red;
            }
        }

        public void isgamewon()
        {
            if (board2.isGameOver())//checks if the player has won.
            {
                gameWon();
            }
            if (rednomoves())
            {
                board2.setPlayer("black");
                gameWon();
            }
            if (blacknomoves())
            {
                board2.setPlayer("red");
                gameWon();
            }
        }

        public void gameWon()
        {
            if (board2.getPlayer() == "red")
            {
                playerText.Text = "PLAYER BLACK WINS!";
                playerText.ForeColor = Color.Gold;
            }
            else
            {
                playerText.Text = "PLAYER RED WINS!";
                playerText.ForeColor = Color.Gold;
            }
        }

        public void aimove()
        {
            isgamewon();
            currentBoard = new TreeNode(board2.getGrid(), 0, "red"); 
            ai.makeTree(currentBoard, 0);

            if (ai.min(currentBoard).Item2 == null)
            {
                gameWon();
            }
            else
            {
                board2.setGrid(ai.min(currentBoard).Item2.data.getGrid());         
                ai.minval = 10000;
                ai.maxval = -10000;
                ai.boardWithHighestVal = null;
                ai.boardWithLowestVal = null;
                board2.changePlayer();
            }

            if (ai.noMoves)
            {
                gameWon();
            }
            playerNoMoves();
            isgamewon();
        }

        public void updateBoard()//this assigns the pictures corrisponding to the int value.
        {
            isgamewon();
            int blackCount = 0;
            int redCount = 0;
            int[,] grid = board2.getGrid();

            for (int y = 0; y < 8; y++)
            {
                for (int x= 0; x < 8; x++)
                {
                    if (grid[x,y] == 1)
                    {
                        
                        board[x, y].Image = Image.FromFile("black.png");
                        blackCount++;
                    }
                    else if (grid[x, y] == 2)
                    {
                        
                        board[x, y].Image = Image.FromFile("red.png");
                        redCount++;
                    }
                    else if (grid[x, y] == 3)
                    {

                        board[x, y].Image = Image.FromFile("blackKing.png");
                        blackCount++;
                    }
                    else if (grid[x, y] == 4)
                    {

                        board[x, y].Image = Image.FromFile("redKing.png");
                        redCount++;
                    }
                    else
                    {
                        board[x, y].Image = null;
                    }
                    if ((x + y) % 2 == 0)
                    {
                        board[x, y].BackColor = Color.BurlyWood;
                    }
                    else
                    {
                        board[x, y].BackColor = Color.BlanchedAlmond;
                    }
                }
            }
            if (blackCount == 0|| redCount==0)
            {
                gameWon();
            }
        }

        private void btn_skip_Click(object sender, EventArgs e)//this btn appears if the player can multimove allows them to skip the move.
        {
            board2.changePlayer();
            btn_skip.Visible = false;
            
            board2.midMove = false;
            changeLabel();
            updateBoard();
            if (!againstplayer)
            {
                aimove();
                updateBoard();
            }
        }

        private void btn_2players_Click(object sender, EventArgs e)
        {
            againstplayer = true;
            startGame();
            board2.playingAgainst = "player";

        }

      

        private void btnSave_Click(object sender, EventArgs e)
        {
            board2.writeBoardToFile();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            board2.setBoardFromFile();
            changeLabel();
            updateBoard();
        }

        private void btn_easy_Click(object sender, EventArgs e)
        {
            againstplayer = false;
            startGame();
            ai.depth = 1;
            board2.playingAgainst = "easy";
        }

        private void btn_medium_Click(object sender, EventArgs e)
        {
            againstplayer = false;
            startGame();
            ai.depth = 2;
            board2.playingAgainst = "med";

        }

        private void btn_hard_Click(object sender, EventArgs e)
        {
            againstplayer = false;
            startGame();
            ai.depth = 1;
            board2.playingAgainst = "hard";

        }

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnLoad.Visible = false;
            btn_mainMenu.Visible = false;
            btn_2players.Visible = true;
            btn_easy.Visible = true;
            btn_medium.Visible = true;
            btn_hard.Visible = true;
            label_start.Visible = true;
            label_comp.Visible = true;
            playerText.Visible = false;
            btn_prevMove.Visible = false;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    board[x, y].Visible = false;
                }
            }
            board2.setBoard();
            board2.setPlayer("black");
        }

        public void setPrevBoard()
        {
            StreamReader reader= new StreamReader("prevMove.txt");
           
            string line = reader.ReadLine();
            board2.setPlayer(line);
            line = reader.ReadLine();
            int y = 0;
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    int val = line[i] - 48; //48 for ascii offset6
                    board2.setVal(i, y,val);
                }
                line = reader.ReadLine();
                y++;
            }
            reader.Close();
            updateBoard();
        }

        public void writePrevBoard()
        {

            StreamWriter sw= new StreamWriter("prevMove.txt");
            
            sw.WriteLine(board2.getPlayer());
            string line = "";
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    line += board2.getVal(y, x);
                }
                sw.WriteLine(line);
                line = "";

            }
            sw.Close();
        }

        private void btn_prevMove_Click(object sender, EventArgs e)
        {
            board2.changePlayer();
            changeLabel();
            setPrevBoard();
        }
    }



    public class Board
    {

        string player = "black";
        int[,] grid = new int[8,8]; // the board that all the game theory will be carried out.
        LinkedList<Point> possibleMoves = new LinkedList<Point>();
        public bool midMove = false;
        public bool madeTake;

        public int redcount = 0;
        public int blackcount = 0;
        public int redKings = 0;
        public int blackKings = 0;
        public int numOfBKings=0;
        public int numOfRKings = 0;
        public string playingAgainst; 
        public Board()
        {
            setBoard();

        }

        public void setBoard()//first state of the game board
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    //1=black 3=black king 2=red 4=red king 0=empty
                    if ((x +y) % 2 == 0 && y<3)
                    {
                        grid[x, y] = 1;
                    }
                    else if ((x+y)%2==0 && y > 4)
                    {
                        grid[x, y] = 2;
                    }
                    else
                    {
                        grid[x, y] = 0;
                    }
                }
            }
            //****messing with initial board
            //grid[3,5] = 0;
           // grid[4, 4] = 2;


            //*
        }

        public void setBoardFromFile()
        {
            StreamReader reader;
            switch (playingAgainst)
            {
                case "player":
                    reader = new StreamReader("2player.txt");
                    break;

                case "easy":
                    reader = new StreamReader("easy.txt");
                    break;
                case "med":
                    reader = new StreamReader("med.txt");
                    break;
                case "hard":
                    reader = new StreamReader("hard.txt");
                    break;
                default:
                    reader = new StreamReader("2player.txt");
                    break;

            }
            string line = reader.ReadLine();
            player = line;
            line = reader.ReadLine();
            int y = 0;
            while (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    int val = line[i]-48; //48 for ascii offset6
                    grid[i, y] = val;
                }
                line = reader.ReadLine();
                y++;
            }
            reader.Close();
            
        }
        public void writeBoardToFile()
        {

            StreamWriter sw;
            switch (playingAgainst)
            {
                case "player":
                    sw = new StreamWriter("2player.txt");
                    break;

                case "easy":
                    sw = new StreamWriter("easy.txt");
                    break;
                case "med":
                    sw = new StreamWriter("med.txt");
                    break;
                case "hard":
                    sw = new StreamWriter("hard.txt");
                    break;
                default:
                    sw = new StreamWriter("2player.txt");
                    break;

            }
            sw.WriteLine(player);
            string line = "";
            for (int x = 0; x < 8; x++)
            {
                for (int y= 0; y< 8;y++)
                {
                    line += grid[y, x];
                }
                sw.WriteLine(line);
                line = "";
             
            }
            sw.Close();
        }


        public bool clickable(int x, int y)//checks if the piece is one of theirs.
        {
            if ((grid[x, y] == 1 || grid[x, y] == 3) && player == "black")
            {
                midMove = true;
                return true;
            }
            else if ((grid[x,y] == 2 || grid[x, y] == 4) && player == "red")

            {
                midMove = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public LinkedList<Point> CalculatePossibleMoves(int x, int y)//gets a list of all the possible moves the player can make.
        {
            possibleMoves.destroyList();
            if(player== "black")
            {
                if (x < 7 && y < 7 && grid[x + 1, y + 1] == 0)
                {
                    possibleMoves.addItem(new Point(x + 1, y + 1));
                }
                if (x > 0 && y < 7 && grid[x - 1, y + 1] == 0 )
                {
                    possibleMoves.addItem(new Point(x-1, y+1));
                }
                if (x > 1 && y < 6 && (grid[x - 1, y + 1] == 2 || grid[x - 1, y + 1] == 4) && grid[x - 2, y + 2] == 0) 
                {
                    possibleMoves.addItem(new Point(x - 2, y + 2));
                }
                if (x < 6 && y < 6 && (grid[x + 1, y + 1] == 2 || grid[x + 1, y + 1] == 4) && grid[x + 2, y + 2] == 0)
                {
                    possibleMoves.addItem(new Point(x + 2, y + 2));
                }
                if (grid[x, y] == 3)
                {
                    if (x < 7 && y > 0 && grid[x + 1, y - 1] == 0)
                    {
                        possibleMoves.addItem(new Point(x + 1, y - 1));
                    }
                    if (x > 0 && y > 0 && grid[x - 1, y - 1] == 0)
                    {
                        possibleMoves.addItem(new Point(x - 1, y - 1));
                    }
                    if (x > 1 && y > 1 && (grid[x - 1, y - 1] == 2 || grid[x - 1, y - 1] == 4) && grid[x - 2, y - 2] == 0)
                    {
                        possibleMoves.addItem(new Point(x - 2, y - 2));
                    }
                    if (x < 6 && y > 1 && (grid[x + 1, y - 1] == 2 || grid[x + 1, y - 1] == 4) && grid[x + 2, y - 2] == 0)
                    {
                        possibleMoves.addItem(new Point(x + 2, y - 2));
                    }
                }
            }
            else if (player == "red")
            {
                if (x < 7 && y > 0 && grid[x + 1, y - 1] == 0)
                {
                    possibleMoves.addItem(new Point(x + 1, y - 1));
                }
                if (x > 0 && y > 0 && grid[x - 1, y - 1] == 0)
                {
                    possibleMoves.addItem(new Point(x - 1, y - 1));
                }
                if (x > 1 && y >1 && (grid[x - 1, y - 1] == 1 || grid[x - 1, y - 1] == 3) && grid[x - 2, y - 2] == 0)
                {
                    possibleMoves.addItem(new Point(x - 2, y - 2));
                }
                if (x < 6 && y >1 && (grid[x + 1, y - 1] == 1 || grid[x + 1, y - 1] == 3) && grid[x + 2, y - 2] == 0)
                {
                    possibleMoves.addItem(new Point(x + 2, y - 2));
                }
                if(grid[x, y] == 4)
                {
                    if (x < 7 && y < 7 && grid[x + 1, y + 1] == 0)
                    {
                        possibleMoves.addItem(new Point(x + 1, y + 1));
                    }
                    if (x > 0 && y < 7 && grid[x - 1, y + 1] == 0)
                    {
                        possibleMoves.addItem(new Point(x - 1, y + 1));
                    }
                    if (x > 1 && y < 6 && (grid[x - 1, y + 1] == 1 || grid[x - 1, y + 1] == 3) && grid[x - 2, y + 2] == 0)
                    {
                        possibleMoves.addItem(new Point(x - 2, y + 2));
                    }
                    if (x < 6 && y < 6 && (grid[x + 1, y + 1] == 1 || grid[x + 1, y + 1] == 3) && grid[x + 2, y + 2] == 0)
                    {
                        possibleMoves.addItem(new Point(x + 2, y + 2));
                    }
                }
            }

            return possibleMoves;
        }

        public bool checkMultimove(int x, int y)//checks all the possibilities of him being able to make a move.
        {
            bool result = false;
            if (player == "black")
            {
                if (x > 1 && y < 6 && (grid[x - 1, y + 1] == 2 || grid[x - 1, y + 1] == 4) && grid[x - 2, y + 2] == 0)
                {
                    result = true;
                }
                if (x < 6 && y < 6 && (grid[x + 1, y + 1] == 2 || grid[x + 1, y + 1] == 4) && grid[x + 2, y + 2] == 0)
                {
                    result = true;
                }
                if (grid[x, y] == 3)
                {
                    if (x > 1 && y > 1 && (grid[x - 1, y - 1] == 2 || grid[x - 1, y - 1] == 4) && grid[x - 2, y - 2] == 0)
                    {
                        result = true;
                    }
                    if (x < 6 && y > 1 && (grid[x + 1, y - 1] == 2 || grid[x + 1, y - 1] == 4) && grid[x + 2, y - 2] == 0)
                    {
                        result = true;
                    }
                }
            }
            else if (player == "red")
            {
                if (x > 1 && y > 1 && (grid[x - 1, y - 1] == 1 || grid[x - 1, y - 1] == 3) && grid[x - 2, y - 2] == 0)
                {
                    result = true;
                }
                if (x < 6 && y > 1 && (grid[x + 1, y - 1] == 1 || grid[x + 1, y - 1] == 1) && grid[x + 2, y - 2] == 0)
                {
                    result = true;
                }
                if (grid[x, y] == 4)
                {
                    if (x > 1 && y < 6 && (grid[x - 1, y + 1] == 1 || grid[x - 1, y + 1] == 3) && grid[x - 2, y + 2] == 0)
                    {
                        result = true;
                    }
                    if (x < 6 && y < 6 && (grid[x + 1, y + 1] == 1 || grid[x + 1, y + 1] == 3) && grid[x + 2, y + 2] == 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public void makeMove(Point current,Point moved)// this updates the grid with the move made.
        {
            madeTake=false;
            try
            {
                if (player == "black")
                {
                    if (grid[current.X, current.Y] == 3)
                    {
                        if (current.X - moved.X == 2)
                        {
                            grid[current.X - 1, current.Y - 1] = 0;

                            madeTake = true;
                        }
                        else if (current.X - moved.X == -2)
                        {
                            grid[current.X + 1, current.Y - 1] = 0;

                            madeTake = true;
                        }
                    }
                    else
                    {
                        if (current.X - moved.X == 2)
                        {
                            grid[current.X - 1, current.Y + 1] = 0;

                            madeTake = true;
                        }
                        else if (current.X - moved.X == -2)
                        {
                            grid[current.X + 1, current.Y + 1] = 0;

                            madeTake = true;
                        }
                    }

                    if (moved.Y == 7 && grid[current.X, current.Y] != 3)
                    {
                        grid[moved.X, moved.Y] = 3;
                        numOfBKings++;
                    }
                    else
                    {
                        grid[moved.X, moved.Y] = grid[current.X, current.Y];
                    }
                    grid[current.X, current.Y] = 0;
                    midMove = false;

                }
                else if (player == "red")
                {
                    if (grid[current.X, current.Y] == 4)
                    {
                        if (current.X - moved.X == 2)
                        {
                            grid[current.X - 1, current.Y + 1] = 0;

                            madeTake = true;

                        }
                        else if (current.X - moved.X == -2)
                        {
                            grid[current.X + 1, current.Y + 1] = 0;

                            madeTake = true;

                        }
                    }
                    else
                    {

                        if (current.X - moved.X == 2)
                        {
                            grid[current.X - 1, current.Y - 1] = 0;

                            madeTake = true;

                        }
                        else if (current.X - moved.X == -2)
                        {
                            grid[current.X + 1, current.Y - 1] = 0;

                            madeTake = true;

                        }
                    }
                    if (moved.Y == 0 && grid[current.X, current.Y] != 4)
                    {
                        grid[moved.X, moved.Y] = 4;
                        numOfRKings++;
                    }
                    else
                    {
                        grid[moved.X, moved.Y] = grid[current.X, current.Y];
                    }
                    grid[current.X, current.Y] = 0;
                    midMove = false;

                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine(current.X);
                Console.WriteLine(current.Y);
            }
        }

        public void setPlayer(string play)
        {
            player = play;
        }

        public bool getMadeTake()//checks if the player has made a take
        {
            return madeTake;
        }

        public void changePlayer()
        {
            if(player == "black")
            {
                player = "red";
            }
            else
            {
                player = "black";
            }
        }

        public void setGrid(int[,] set)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    grid[x, y] = set[x, y];
                }
            }
        }

        public bool isGameOver()
        {
            int redcount = 0;
            int blackcount = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++) 
                {

                    if (grid[x,y] == 1|| grid[x, y] == 3)
                    {
                        blackcount++;
                    }
                    if (grid[x, y] == 2|| grid[x, y] == 4)
                    {
                        redcount++;
                    }
                }
            }
            if (redcount == 0)
            {
                return true;
            }
            else if(blackcount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[,] getGrid()
        {
            return grid;
        }

        public int getVal(int x, int y)
        {
            return grid[x,y];
        }

        public void setVal(int x, int y,int val)
        {
            grid[x, y] = val;
        }

        public bool isMoving()//checks if he is clicked on one of his pieces so mid move.
        {
            return midMove;
        }

        public string getPlayer()
        {
            return player;
        }
        public void calulatePlayers()
        {
            redcount = 0;
            blackcount = 0;
            redKings = 0;
            blackKings = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {

                    if (grid[x, y] == 1 || grid[x, y] == 3)
                    {
                        blackcount++;
                    }
                    if (grid[x, y] == 2 || grid[x, y] == 4)
                    {
                        redcount++;
                    }
                    if (grid[x, y] == 3)
                    {
                        blackKings++;
                    }
                    if (grid[x, y] == 4)
                    {
                        redKings++;
                    }
                }
            }
        }
    }



    public class AI
    {
        TreeNode root;
        int[,] grid;
        Random rand = new Random();
        Board tempBoard = new Board();
        public TreeNode boardWithHighestVal=null;
        public TreeNode boardWithLowestVal=null;
        public int maxval=-10000;
        public int minval=10000;
        Tuple<int, TreeNode> variable;
        public bool noMoves = false;
        public int depth = 0;

        public AI(TreeNode root)
        {
            this.root = root;

        }
      
        public int calculateVal(TreeNode Board)
        {
            int utility = 0;
            int redcount = 0;
            int blackcount = 0;
            int redKings = 0;
            int blackKings = 0;

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++) 
                {
                    
                    if (Board.data.getVal(x,y) == 1 || Board.data.getVal(x, y) == 3)
                    {
                        blackcount++;
                    }
                    if (Board.data.getVal(x, y) == 2|| Board.data.getVal(x, y) == 4)
                    {
                        redcount++;
                    }
                    if(Board.data.getVal(x, y) == 3)
                    {
                        blackKings++;
                    }
                    if(Board.data.getVal(x, y) == 4)
                    {
                        redKings++;
                    }
                }
            }

            //if (Board.currentPlayer == "red")
           // {
                utility = (redcount - blackcount) * 4 + (redKings - blackKings) * 6;
            // }
            //if (Board.currentPlayer == "black")
            //{
            //    utility = (blackcount - redcount) * 4 + rand.Next(1, 4) + (blackKings - redKings) * 6;
            //}
           
            if(Board.currentPlayer == "red" && blackcount==0)
            {
                utility = 10000;
            }
            if (Board.currentPlayer == "black" && redcount==0)
            {
                utility = 10000;
            }
            return utility;
        }
            
        public Tuple<int,TreeNode> max(TreeNode board)
        {
            if (board.depth==depth)
            {
                int utl = calculateVal(board);
                board.val = utl;
                variable = Tuple.Create<int, TreeNode>(utl, null);

                return Tuple.Create<int, TreeNode>(utl, null);
            }

            foreach(TreeNode child in board.children)
            {

                Print(child);
                variable = min(child);

                if (child.val >= maxval)
                {
                    board.val = child.val;
                    boardWithHighestVal = child;
                    maxval = variable.Item1;
                }
                
            }

            if (board.depth == 0)
            {
                maxval = -1000;

                foreach (TreeNode child in board.children)
                {
                    if (child.val >= minval)
                    { 
                        boardWithHighestVal = child;
                        maxval = variable.Item1;
                    }
                }
            }

            return Tuple.Create<int,TreeNode>(maxval, boardWithHighestVal);
        }

        public Tuple<int, TreeNode> min(TreeNode board)
        {
            if (board.depth ==depth) 
            {
                int utl = calculateVal(board);
                board.val = utl;
                variable = Tuple.Create<int, TreeNode>(utl, null);

                return Tuple.Create<int, TreeNode>(utl, null);
            }

            foreach (TreeNode child in board.children)
            {
                variable =max(child);

                if (child.val <= minval)
                {
                    board.val = child.val;
                    boardWithLowestVal = child;
                    minval = variable.Item1;
                }
            }

            if (board.depth == 0)
            {
                minval = 1000;
                
                foreach (TreeNode child in board.children)
                {
                    child.data.calulatePlayers();
                    if (child.val <= minval)
                    {
                        boardWithLowestVal = child;
                        minval = variable.Item1;
                    }
                    if(child.data.blackcount == 0)
                    {
                        boardWithLowestVal = child;
                        minval = variable.Item1;
                        break;
                    }
                }

            }
            

            if (boardWithLowestVal==null||(boardWithLowestVal.data.getGrid()==board.data.getGrid()))
            {
                noMoves = true;
            }

            return Tuple.Create<int, TreeNode>(minval, boardWithLowestVal);
        }

        public void Print(TreeNode c)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(c.data.getVal(x, y));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void makeTree(TreeNode root, int depth)
        {
            populateChildren(root);
            depth++;
            Console.WriteLine(depth);

            if (depth <4)
            {
                foreach (TreeNode child in root.children)
                {
                    Console.WriteLine("Next root:");
                    makeTree(child, depth);
                }
            }
        }

        public void populateChildren(TreeNode parent)
        {
            grid = parent.data.getGrid();
            tempBoard = parent.data;
            tempBoard.changePlayer();
            TreeNode tempChild;
            int[,] newGrid = grid.Clone() as int[,];

            if (parent.depth < 4)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        tempBoard.setGrid(newGrid);
                        tempBoard.setPlayer(parent.currentPlayer);

                        if (parent.currentPlayer == "red")
                        {
                            if (grid[x, y] == 2 || grid[x, y] == 4)
                            {
                                if (tempBoard.CalculatePossibleMoves(x, y).getAllItems() != null)
                                {
                                    foreach (Point move in tempBoard.CalculatePossibleMoves(x, y).getAllItems())
                                    {
                                        tempBoard.setGrid(newGrid);
                                        tempBoard.makeMove(new Point(x, y), move);
                                        tempChild = new TreeNode(tempBoard.getGrid(), parent.depth+1, "black");
                                        parent.children.Add(tempChild);
                                    }
                                }
                            }
                        }
                        else if (parent.currentPlayer == "black")
                        {
                            if (grid[x, y] == 1 || grid[x, y] == 3)
                            {
                                if (tempBoard.CalculatePossibleMoves(x, y).getAllItems() != null)
                                {
                                    foreach (Point move in tempBoard.CalculatePossibleMoves(x, y).getAllItems())
                                    {
                                        tempBoard.setGrid(newGrid);
                                        tempBoard.makeMove(new Point(x, y), move);
                                        tempChild = new TreeNode(tempBoard.getGrid(), parent.depth+1, "red");
                                        parent.children.Add(tempChild);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (TreeNode child in parent.children)
            {
                Print(child);
            }
            
        }

    }



    public class TreeNode
    {
        public Board data = new Board();
        public int depth;
        public List<TreeNode> children = new List<TreeNode>();
        public string currentPlayer;
        public int val;

        public TreeNode(int[,] val,int depth, string currentPlayer)
        {
            this.data.setGrid(val);
            this.depth = depth;
            this.currentPlayer = currentPlayer; 
        }
  
    }



    public class LinkedList<T>
    {
        public Node<T> start;
        public int size;
        public Node<T> current;
        public Node<T> previous;
        
        public LinkedList()
        {
            start = null;
            current = null;
            size = 0;
        }

        public void destroyList()
        {
            start = null;
            current = null;
            size = 0;
        }

        public void addItem(T item)
        {
            if (isEmpty())
            {
                start = new Node<T>(item);
                size++;
            }
            else
            {
                current = start;

                while (current.getNext() != null)
                {
                     current = current.getNext();
                }

                current.setNext(new Node<T>(item));
                size++;
            }
        }

        public T[] getAllItems()//turns an array of all the items in the list.
        {
            T[] arrOfItems = new T[size];
            int count = 0;

            if (isEmpty())
            {
                return null;
            }
            else
            {
                current = start;

                while (current != null)
                {
                    arrOfItems[count] = current.getData();
                    current = current.getNext();
                    count++;
                }

                return arrOfItems;
            }
        }

        public bool isEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }



    public class Node<T>
    {
        T data;
        Node<T> next;

        public Node(T val)
        {
            data = val;
            next = null;
        }

        public void setNext(Node<T> nextNode)
        {
            next = nextNode;
        }

        public void setData(T val)
        {
            data = val;
        }

        public Node<T> getNext()
        {
            return next;
        }

        public T getData()
        {
            return data;
        }

    }
}
