using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperClone
{
    public partial class Form1 : Form
    {
        private Grid grid;
        private GameManager gameManager;

        public Form1()
        {
            InitializeComponent();
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            grid = new Grid(CalculateAmountOfRowsInGrid(), CalculateAmountColumnsInGrid());
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    RenderCellButton(r, c);
                }

            }
        }

        public void RenderCellButton(int row, int column)
        {
            //Add event handler for click
            grid.GridCellButtons[row, column].Click += gridCellButton_Click;

            //Add button to panel
            pnl_playArea.Controls.Add(grid.GridCellButtons[row, column]);
            grid.GridCellButtons[row, column].Location =
                new Point(row * CellButton.ButtonSize, column * CellButton.ButtonSize);

            //if (grid.GridCellButtons[row, column].IsThereABomb == true)
            //{
            // grid.GridCellButtons[row, column].Text = "B";
            //}
        }

        public void RenderGridButtonUpdates()
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    RenderClearedCell(r,c);
                    RenderBombDistance(r,c);
                }

            }

        }

        public void RenderClearedCell(int row, int column)
        {
            if (grid.GridCellButtons[row, column].HasBeenCleared)
            {
                grid.GridCellButtons[row, column].Text = "~";
            }
        }

        public void RenderBombDistance(int row, int column)
        {
            if (grid.GridCellButtons[row, column].IsSurroundingBombsCountVisible)
            {
                grid.GridCellButtons[row, column].Text = grid.GridCellButtons[row, column].SurroundingBombsCount.ToString();
            }
        }

        public int CalculateAmountOfRowsInGrid()
        {
            return pnl_playArea.Height / CellButton.ButtonSize;
        }

        public int CalculateAmountColumnsInGrid()
        {
            return pnl_playArea.Width / CellButton.ButtonSize;
        }

        public void gridCellButton_Click(object? sender, EventArgs e)
        {
            CellButton clickedCellButton = (CellButton) sender;

            int clickedCellRow = clickedCellButton.Row;
            int clickedCellColumn = clickedCellButton.Column;

            if (grid.GridCellButtons[clickedCellRow, clickedCellColumn].IsThereABomb)
            {
                MessageBox.Show("You have lost");
            }
            else
            {
                grid.FloodBoard(clickedCellRow,clickedCellColumn);
                grid.cnt = 0;
                RenderGridButtonUpdates();
                if (grid.CheckWin())
                {
                    MessageBox.Show("You Won! Congrats!");
                }
            }
        }
       
    }
}
