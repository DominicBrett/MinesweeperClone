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
    
        public static int ButtonSize = 40;

        public int NearestBombDistance { get; set; }

        public int SurroundingBombsCount { get; set; }

        public bool IsSurroundingBombsCountVisible { get; set; }

        private static Random random = new Random();
        public CellButton()
        {
            // I think this goes against clean coding standards but will use this time
            Width = Height = ButtonSize;

            int randomNumber = random.Next(1, 8);
            if (randomNumber == 2)
            {
                IsThereABomb = true;
            }

            IsSurroundingBombsCountVisible = false;
        }


        
    }
}
