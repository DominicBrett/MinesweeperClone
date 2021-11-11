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

        //Counter Varibles
        private int secondsCounter = 0;
        private int clicksCounter = 0;
        private int winsCounter = 0;
        private int lossesCounter = 0;

        //Timer Variables
        private readonly int TIMER_INTERVAL = ApplicationVariables.GetTimerInterval();
        private readonly int COUNTER_INCREASE = ApplicationVariables.GetCounterIncrease();
        private readonly int COUNTER_BASE = ApplicationVariables.GetCounterBase();

        //Color Variables
        private readonly Color FLAGGED_TEXT_COLOR = ApplicationVariables.GetFlaggedTextColor();
        private readonly Color DEFAULT_TEXT_COLOR = ApplicationVariables.GetDefaultTextColor();

        //Audio Sound File Variables
        private readonly string SELECT_SOUND_FILE = ApplicationVariables.GetSelectSoundFile();
        private readonly string FLAGGED_SOUND_FILE = ApplicationVariables.GetFlaggedSoundFile();
        private readonly string WIN_SOUND_FILE = ApplicationVariables.GetWinSoundFile();
        private readonly string LOSS_SOUND_FILE= ApplicationVariables.GetLossSoundFile();

        //Button Variables
        private static readonly int BUTTON_SIZE = ApplicationVariables.GetButtonSize();
        private static readonly int MAX_RANDOM_NUMBER_FOR_DIFFICULTY = ApplicationVariables.GetMaxRandomNumberForButtonDifficulty(); //The highest the easier the game

        private bool isUserFlaggingCell = false;
        public Form1()
        {
            InitializeComponent();
            PopulateGrid();
            GenerateTimer();
        }

        public void PopulateGrid()
        {
            grid = new Grid(CalculateAmountOfRowsInGrid(), CalculateAmountColumnsInGrid(), BUTTON_SIZE, MAX_RANDOM_NUMBER_FOR_DIFFICULTY);
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
                new Point(row * BUTTON_SIZE, column * BUTTON_SIZE);
        }

        public void RenderGridButtonUpdates()
        {
            for (int r = 0; r < grid.Rows; r++)
            {
                for (int c = 0; c < grid.Columns; c++)
                {
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

        public int CalculateAmountOfRowsInGrid()
        {
            return pnl_playArea.Height / BUTTON_SIZE;
        }

        public int CalculateAmountColumnsInGrid()
        {
            return pnl_playArea.Width / BUTTON_SIZE;
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
                cellButton.ForeColor = FLAGGED_TEXT_COLOR;
                cellButton.Text = "?";
                PlaySound(FLAGGED_SOUND_FILE);
            }
            else
            {
                cellButton.ForeColor = DEFAULT_TEXT_COLOR;
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
                PlaySound(LOSS_SOUND_FILE);
            }
            else
            {
                grid.FloodBoard(clickedCellRow, clickedCellColumn);
                grid.cnt = 0;
                RenderGridButtonUpdates();
                if (grid.CheckWin())
                {
                    ResetGameWin();
                    PlaySound(WIN_SOUND_FILE);
                }
                else
                {
                    UpdateCellsVisuallyBasedOnFlaggedStatus();
                    PlaySound(SELECT_SOUND_FILE);
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
