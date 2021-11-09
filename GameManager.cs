using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperClone
{
    class GameManager
    {
        public bool HasLost { get; set; }

        public GameManager()
        {
            HasLost = false;
        }
    }
}
