using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace MinesweeperClone
{
    class CellButton : Button
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public bool IsThereABomb { get; set; }

        public bool HasBeenCleared { get; set; }
    
        public static int ButtonSize = 50;

        public int NearestBombDistance { get; set; }

        public int SurroundingBombsCount { get; set; }

        public bool IsSurroundingBombsCountVisible { get; set; }

        public bool IsFlagged { get; set; }

        private static readonly int MAX_RANDOM_NUMBER = 8;

        private static Random random = new Random();

        public CellButton()
        {
            // I think this goes against clean coding standards but will use this time
            Width = Height = ButtonSize;

            int randomNumber = random.Next(1, MAX_RANDOM_NUMBER);
            if (randomNumber == 2)
            {
                IsThereABomb = true;
            }

            IsSurroundingBombsCountVisible = false;
        }


        
    }
}
