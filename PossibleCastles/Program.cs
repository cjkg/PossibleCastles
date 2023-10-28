using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using PossibleCastles.UI;
using Mindmagma.Curses;

namespace PossibleCastles
{
    class Program
    {
        private static IntPtr _screen;

        private static readonly short[] ColorTable =
        {
            CursesColor.RED,
            CursesColor.BLUE,
            CursesColor.GREEN,
            CursesColor.CYAN,
            CursesColor.RED,
            CursesColor.MAGENTA,
            CursesColor.YELLOW,
            CursesColor.WHITE
        };
        
        static void Main(string[] args)
        {
            _screen = NCurses.InitScreen();

            UI.CursesUI.CursesRenderer renderer;
            
            bool exit = false;
            bool update = true;
            const int mapWidth = 80; // TODO: delete
            const int mapHeight = 50; // TODO: delete
            int floor = 1; // TODO: delete
            
            if(NCurses.HasColors())
            {
                NCurses.StartColor();
                for (short i = 1; i < 8; i++)
                    NCurses.InitPair(i, ColorTable[i], CursesColor.BLACK);
            }

            NCurses.NoDelay(_screen, true);
            NCurses.SetCursor(0);
            NCurses.NoEcho();
            
            while (!exit)
            {
                NCurses.MoveAddString(3, 3,"Click a button or press any key to exit.");

                switch (NCurses.GetChar())
                {
                    case -1:
                        // no input
                        break;
                    default:
                        exit = true;
                        break;
                }
                
                /*if (update)
                {
                    NCurses.Move(NCurses.Lines - 1, NCurses.Columns - 1);
                    NCurses.Refresh();
                    update = false;
                }*/
                
            }

            NCurses.EndWin();
        }
        private static void AddStr(int y, int x, string str)
        {
            if (x >= 0 && x < NCurses.Columns && y >= 0 && y < NCurses.Lines)
                NCurses.MoveAddString(y, x, str);
        }
    }
}