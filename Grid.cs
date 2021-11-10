using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace MinesweeperClone
{
    class Grid
    {
        public CellButton[,] GridCellButtons { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int cnt = 0;
        public Grid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            GridCellButtons = new CellButton[rows, columns];
            PopulateGridCellButton();
            //FindEachCellsClosestBomb();
            FindEachCellsSurroundingBombCount();
        }
        // Recursive function to clear the board when the user selects a cell without a bomb
        public void FloodBoard(int row, int column)
        {
            if (!IsValid(row, column)) return;
            if (!GridCellButtons[row, column].IsThereABomb && !GridCellButtons[row, column].HasBeenCleared)
            {
                //If this is the first time entering the recursive function and the user clicked a cell with bombs surrounding it
                if (GridCellButtons[row, column].SurroundingBombsCount > 0 && cnt == 0)
                {
                    GridCellButtons[row, column].IsSurroundingBombsCountVisible = true;
                    GridCellButtons[row, column].HasBeenCleared = true;
                    return;
                }
                cnt++;
                Debug.WriteLine(cnt);
                if (GridCellButtons[row, column].SurroundingBombsCount > 0 && cnt > 0)
                {
                    //stopping point
                    GridCellButtons[row, column].IsSurroundingBombsCountVisible = true;
                    GridCellButtons[row, column].HasBeenCleared = true;
                }
                else
                {
                    //Bomb has been cleared at this point
                    GridCellButtons[row, column].HasBeenCleared = true;
                    //Move Up
                    FloodBoard(row - 1, column);
                    //Move Down
                    FloodBoard(row + 1, column);
                    //Move Left
                    FloodBoard(row, column - 1);
                    //Move Right
                    FloodBoard(row, column + 1);
                }
            }

            if (GridCellButtons[row, column].IsThereABomb)
            {
                //Throw the user off a bit
                if (GridCellButtons[row, column].SurroundingBombsCount == 0)
                {
                    GridCellButtons[row, column].HasBeenCleared = false;
                }
                GridCellButtons[row, column].IsSurroundingBombsCountVisible = true;
            }
        }

        public void FindEachCellsClosestBomb()
        {

            for (int currentCellRow = 0; currentCellRow < Rows; currentCellRow++)
            {
                for (int currentCellColumn = 0; currentCellColumn < Columns; currentCellColumn++)
                {
                    GridCellButtons[currentCellRow,currentCellColumn].NearestBombDistance = FindNearestBomb(currentCellRow, currentCellColumn);
                }
            }
        }

        public void FindEachCellsSurroundingBombCount()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                   FindCellsSurroundingBombCount(r,c);
                }
            }
        }

        public void FindCellsSurroundingBombCount(int row, int column)
        {
            // Check Up
            int adjacentBombCount = 0;
            if (IsValid(row - 1, column))
            {
                if (GridCellButtons[row - 1, column].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Check Down
            if (IsValid(row + 1, column))
            {
                if (GridCellButtons[row + 1, column].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Check left
            if (IsValid(row, column - 1))
            {
                if (GridCellButtons[row, column - 1].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Check right
            if (IsValid(row, column + 1))
            {
                if (GridCellButtons[row, column + 1].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Top left
            if (IsValid(row - 1, column - 1))
            {
                if (GridCellButtons[row - 1, column - 1].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Top right
            if (IsValid(row - 1, column + 1))
            {
                if (GridCellButtons[row - 1, column + 1].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Bottom Left
            if (IsValid(row + 1, column - 1))
            {
                if (GridCellButtons[row + 1, column - 1].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }
            //Bottom Right
            if (IsValid(row + 1, column + 1))
            {
                if (GridCellButtons[row + 1, column + 1].IsThereABomb)
                {
                    adjacentBombCount += 1;
                }
            }

            GridCellButtons[row, column].SurroundingBombsCount = adjacentBombCount;
        }

        public int FindNearestBomb(int currentCellRow, int currentCellColumn)
        {
            if (GridCellButtons[currentCellRow, currentCellColumn].IsThereABomb)
            {
                return 0;
            }

            int shortestPath = Int32.MaxValue;
            for (int bombCellRow = 0; bombCellRow < Rows; bombCellRow++)
            {
                for (int bombCellColumn = 0; bombCellColumn < Columns; bombCellColumn++)
                {
                    if (GridCellButtons[bombCellRow, bombCellColumn].IsThereABomb)
                    {
                        int path = FindShortestPathBetweenPoints(bombCellRow, bombCellColumn, currentCellRow,
                            currentCellColumn);
                        if (path < shortestPath)
                        {
                            shortestPath = path;
                        }
                    }
                }
            }

            return shortestPath;
        }

        public int FindShortestPathBetweenPoints(int startingPointRow, int startingPointColumn, int destinationPointRow, int destinationPointColumn)
        {
            int distanceRow = Math.Abs(startingPointRow - destinationPointRow);
            int distanceColumn = Math.Abs(startingPointColumn - destinationPointColumn);

            return distanceRow + distanceColumn;
        }

        private bool IsValid(int row, int column)
        {
            if (row < Rows
                && row >= 0
                && column < Columns
                && column >= 0)
            {
                return true;
            }

            return false;
        }

        private void PopulateGridCellButton()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    //Create Button
                    GridCellButtons[r, c] = new CellButton();
                    GridCellButtons[r, c].Row = r;
                    GridCellButtons[r, c].Column = c;
                }

            }
        }

        // If there is no unrevealed safe squares left the user has won and true is returned
        public bool CheckWin()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (!GridCellButtons[r, c].HasBeenCleared && !GridCellButtons[r, c].IsThereABomb)
                    {
                        return false;
                    }
                }

            }

            return true;
        }
    }
}
