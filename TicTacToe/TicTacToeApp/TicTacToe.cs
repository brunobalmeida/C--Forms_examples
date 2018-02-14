/* TicTacToe
 * 
 * Programmer: Bruno Penna Barbosa de Almeida 
 * ID# 7772825
 * Revision History
 *      Bruno P B Almeida, 2017.10.05: Created 
 *      Bruno P B Almeida, 2017.10.05: Comments inserted 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    /// <summary>
    /// Tic Tac Toe main class
    /// </summary>
    public partial class TicTacToe : Form
    {
        //Global variables declaration
        public const int PICBOX_ROW = 3;
        public const int PICBOX_COL = 3;
        public bool clickFlag = true;
        public int[,] winArray = new int[PICBOX_ROW,PICBOX_COL];
        public PictureBox[] picBoxArray = new PictureBox[PICBOX_COL * PICBOX_ROW];
        public int rowIndex = 0;
        public int colIndex = 0;
        public int count = 0;
        
        /// <summary>
        /// Initializes the component 
        /// </summary>
        public TicTacToe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the picture box array
        /// </summary>
        private void initPicArray()
        {
            picBoxArray[0] = pctBox1;
            picBoxArray[1] = pctBox2;
            picBoxArray[2] = pctBox3;
            picBoxArray[3] = pctBox4;
            picBoxArray[4] = pctBox5;
            picBoxArray[5] = pctBox6;
            picBoxArray[6] = pctBox7;
            picBoxArray[7] = pctBox8;
            picBoxArray[8] = pctBox9;
        }

        /// <summary>
        /// Initializes the winning array
        /// </summary>
        private void initWinArray()
        {
            for (int i = 0; i < PICBOX_ROW; i++)
            {
                for (int j = 0; j < PICBOX_COL; j++)
                {
                    winArray[i, j] = -5;
                }
            }
        }

        /// <summary>
        /// Handle the click event for the picture boxes
        /// </summary>
        /// <param name="pctBox">a PictureBox variable to be handled</param>
        /// <param name="i">a int value to be used as the array row index</param>
        /// <param name="j">a int value to be used as the array col index</param>
        private void onClick(PictureBox pctBox, int i, int j)
        {
            
            count++;
            if (clickFlag)
            {
                pctBox.Image = TicTacToeApp.Properties.Resources.x;
                winArray[i,j] = 1;
            }
            else
            {
                pctBox.Image = TicTacToeApp.Properties.Resources.o;
                winArray[i,j] = 2;
            }
            clickFlag = !clickFlag;

            if (count>4)
            {
                checkWinner();
            }
            
        }

        /// <summary>
        /// Checks for winning or tying conditions 
        /// </summary>
        private void checkWinner()
        {
            int winSumFlag = 0;

            //Checking the horizontal possibilities to win 
            for (int i = 0; i < PICBOX_ROW; i++)
            {
                for (int j = 0; j < PICBOX_COL; j++)
                {
                    winSumFlag += winArray[i, j];
                }
                if (winSumFlag == 3)
                {
                    MessageBox.Show("X wins horizontal!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restartGame();
                }
                else if (winSumFlag == 6)
                {
                    MessageBox.Show("O wins horizontal!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restartGame();
                }
                winSumFlag = 0;
            }

            //Checking the vertical possibilities to win 
            for (int i = 0; i < PICBOX_ROW; i++)
            {
                for (int j = 0; j < PICBOX_COL; j++)
                {
                    winSumFlag += winArray[j, i];
                }
                if (winSumFlag == 3)
                {
                    MessageBox.Show("X wins vertical!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restartGame();
                }
                else if (winSumFlag == 6)
                {
                    MessageBox.Show("O wins vertical!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    restartGame();
                }
                winSumFlag = 0;
            }

            //Code for diagonals 
            for (int i = 0; i < PICBOX_ROW; i++)
            {
                int j = i;
                winSumFlag += winArray[i, j];
            }
            if (winSumFlag == 3)
            {
                MessageBox.Show("X wins diagonal!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restartGame();
            }
            else if (winSumFlag == 6)
            {
                MessageBox.Show("O wins diagonal!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restartGame();
            }

            winSumFlag = 0;

            for (int i = 0; i < PICBOX_COL; i++)
            {
                int j = 2 - i;
                winSumFlag += winArray[i, j];
            }
            if (winSumFlag == 3)
            {
                MessageBox.Show("X wins diagonal!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restartGame();
            }
            else if (winSumFlag == 6)
            {
                MessageBox.Show("O wins diagonal!", "Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restartGame();
            }
            winSumFlag = 0;

            //Code for a Tie
            if (count==9)
            {
                MessageBox.Show("It's a Tie, nobody won! \nTry again!", "Tie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restartGame();
            }

        }

        /// <summary>
        /// Restarts the game cleaning the screen and reseting the variables
        /// </summary>
        private void restartGame()
        {
            for (int i = 0; i < picBoxArray.Length; i++)
            {
                picBoxArray[i].Image = null;
            }
            count = 0;
            clickFlag = true;
            initWinArray();
        }

        /// <summary>
        /// Starts the click event for the picture boxes
        /// </summary>
        /// <param name="sender">The PictureBox that is originating the event</param>
        /// <param name="e"></param>
        private void pctBox_Click(object sender, EventArgs e)
        {
            PictureBox picBox;
            picBox = (PictureBox)sender;

            int tag = int.Parse(picBox.Tag.ToString());
            rowIndex = (tag -1)/PICBOX_ROW;
            colIndex = (tag - 1) % PICBOX_COL;
            onClick(picBox, rowIndex, colIndex);
        }

        /// <summary>
        /// Handle the events on form load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TicTacToe_Load(object sender, EventArgs e)
        {
            initWinArray();
            initPicArray();
        }
    }
}
