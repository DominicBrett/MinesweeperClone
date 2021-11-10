using System;
using System.CodeDom;
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

        private int secondsCounter = 0;
        private int clicksCounter = 0;
        private int winsCounter = 0;
        private int lossesCounter = 0;

        private int TIMER_INTERVAL = 1000;
        private int COUNTER_INCREASE = 1;
        private int COUNTER_BASE = 0;

        private bool isUserFlaggingCell = false;
        public Form1()
        {
            InitializeComponent();
            PopulateGrid();
            GenerateTimer();
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
                    RenderTheSurroundingBombCount(r, c);
                    CheckIfBombHasBeenClearedAndDisable(r,c);
                }
            }

        }

        public void CheckIfBombHasBeenClearedAndDisable(int row, int column)
        {
            if (grid.GridCellButtons[row, column].HasBeenCleared)
            {
                grid.GridCellButtons[row, column].Enabled = false;
            }
        }

        public void RenderTheSurroundingBombCount(int row, int column)
        {
            if (grid.GridCellButtons[row, column].IsSurroundingBombsCountVisible)
            {
                Color txtColor = Color.White;
                switch (grid.GridCellButtons[row, column].SurroundingBombsCount)
                {
                    case 1:
                        txtColor = Color.Blue;
                        break;
                    case 2:
                        txtColor = Color.Green;
                        break;
                    case 3:
                        txtColor = Color.Red;
                        break;
                    case 4:
                        txtColor = Color.Purple;
                        break;
                    case 5:
                        txtColor = Color.White;
                        break;
                    case 6:
                        txtColor = Color.Pink;
                        break;
                    case 7:
                        txtColor = Color.Maroon;
                        break;
                    case 8:
                        txtColor = Color.Turquoise;
                        break;
                    default:
                        break;
                }

                grid.GridCellButtons[row, column].Text = grid.GridCellButtons[row, column].SurroundingBombsCount.ToString();
                grid.GridCellButtons[row, column].ForeColor = Color.White;
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

            CellButton clickedCellButton = (CellButton)sender;

            if (isUserFlaggingCell)
            {
                FlagCell(clickedCellButton);
            }
            else
            {
                UpdateClicksCounter(clicksCounter + COUNTER_INCREASE);
                SelectCell(clickedCellButton);
            }
            
        }

        private void FlagCell(CellButton clickCellButton)
        {
            clickCellButton.IsFlagged = !clickCellButton.IsFlagged;
            UpdateCellsVisuallyBasedOnFlaggedStatus();

        }

        private void UpdateCellsVisuallyBasedOnFlaggedStatus()
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
                    UpdateCellVisuallyBasedOnFlaggedStatus(grid.GridCellButtons[r,c]);
                }
            }
        }

        private void UpdateCellVisuallyBasedOnFlaggedStatus(CellButton cellButton)
        {
            if (cellButton.IsFlagged && !cellButton.HasBeenCleared)
            {
                cellButton.ForeColor = Color.Red;
                cellButton.Text = "?";
                PlaySound(@"c:\Windows\Media\Windows Pop-up Blocked.wav");
            }
            else
            {
                cellButton.ForeColor = Color.Black;
                if (cellButton.IsSurroundingBombsCountVisible)
                {
                    cellButton.Text = cellButton.SurroundingBombsCount.ToString();
                }
                else
                {
                    cellButton.Text = "";
                }
            }
        }

        private void SelectCell(CellButton clickedCellButton)
        {
            int clickedCellRow = clickedCellButton.Row;
            int clickedCellColumn = clickedCellButton.Column;

            if (grid.GridCellButtons[clickedCellRow, clickedCellColumn].IsThereABomb)
            {
                ResetGameLoss();
                PlaySound(@"c:\Windows\Media\Windows Critical Stop.wav");
            }
            else
            {
                grid.FloodBoard(clickedCellRow, clickedCellColumn);
                grid.cnt = 0;
                RenderGridButtonUpdates();
                if (grid.CheckWin())
                {
                    ResetGameWin();
                    PlaySound(@"c:\Windows\Media\Ring08.wav");
                }
                else
                {
                    UpdateCellsVisuallyBasedOnFlaggedStatus();
                    PlaySound(@"c:\Windows\Media\Windows Default.wav");
                }
            }
        }

        public void ResetGameLoss()
        {
            pnl_playArea.Controls.Clear();
            UpdateClicksCounter(COUNTER_BASE);
            UpdateLossesCounter(lossesCounter + COUNTER_INCREASE);
            PopulateGrid();
            secondsCounter = COUNTER_BASE;
        }
        public void ResetGameWin()
        {
            UpdateClicksCounter(COUNTER_BASE);
            UpdateWinsCounter(winsCounter + COUNTER_INCREASE);
            pnl_playArea.Controls.Clear();
            PopulateGrid();
            secondsCounter = COUNTER_BASE;
        }
        public void GenerateTimer()
        {
            Timer timer = new Timer();
            timer.Interval = (TIMER_INTERVAL);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            secondsCounter += COUNTER_INCREASE;
            lbl_timerDisplay.Text = secondsCounter.ToString() +" Seconds";
        }

    
        private void UpdateClicksCounter(int newValue)
        {
            clicksCounter = newValue;
            lbl_Clicks.Text = clicksCounter.ToString();
        }
        private void UpdateWinsCounter(int newValue)
        {
            winsCounter = newValue;
            lbl_winsCounter.Text = winsCounter.ToString();
        }
        private void UpdateLossesCounter(int newValue)
        {
            lossesCounter = newValue;
            lbl_lossesCounter.Text = lossesCounter.ToString();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ResetGameLoss();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isUserFlaggingCell = !isUserFlaggingCell;
        }

        private void PlaySound(string filePath)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(filePath);
            player.Play();
        }
    }
}
