using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MinesweeperClone
{
    public static class ApplicationVariables
    {
        //Timer Variables
        private static readonly int TIMER_INTERVAL = 1000;
        private static readonly int COUNTER_INCREASE = 1;
        private static readonly int COUNTER_BASE = 0;

        //Color Variables
        private static readonly Color FLAGGED_TEXT_COLOR = Color.Red;
        private static readonly Color DEFAULT_TEXT_COLOR = Color.Black;

        //Audio File Variables
        private static readonly string SELECT_SOUND_FILE = @"c:\Windows\Media\Windows Pop-up Blocked.wav";
        private static readonly string FLAGGED_SOUND_FILE = @"c:\Windows\Media\Windows Default.wav";
        private static readonly string WIN_SOUND_FILE = @"c:\Windows\Media\Ring08.wav";
        private static readonly string LOSS_SOUND_FILE = @"c:\Windows\Media\Windows Critical Stop.wav";

        //Button Variables
        private static readonly int BUTTON_SIZE = 50;
        private static readonly int MAX_RANDOM_NUMBER_FOR_DIFFICULTY = 8; //The highest the easier the game

        // Timer Variable Getters
        public static int GetTimerInterval()
        {
            return TIMER_INTERVAL;
        }
        public static int GetCounterIncrease()
        {
            return COUNTER_INCREASE;
        }
        public static int GetCounterBase()
        {
            return COUNTER_BASE;
        }

        //Color Variable Getter
        public static Color GetFlaggedTextColor()
        {
            return FLAGGED_TEXT_COLOR;
        }
        public static Color GetDefaultTextColor()
        {
            return DEFAULT_TEXT_COLOR;
        }

        //Audio File Variable Getters
        public static string GetSelectSoundFile()
        {
            return SELECT_SOUND_FILE;
        } 
        public static string GetFlaggedSoundFile()
        {
            return FLAGGED_SOUND_FILE;
        }
        public static string GetWinSoundFile()
        {
            return WIN_SOUND_FILE;
        }

        public static string GetLossSoundFile()
        {
            return LOSS_SOUND_FILE;
        }
        //Button Variables Getters
        public static int GetButtonSize()
        {
            return BUTTON_SIZE;
        }
        public static int GetMaxRandomNumberForButtonDifficulty()
        {
            return MAX_RANDOM_NUMBER_FOR_DIFFICULTY;
        }

    }
}
