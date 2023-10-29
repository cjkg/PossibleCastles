using Mindmagma.Curses;

namespace PossibleCastles.UI.CursesUI;

public class CursesRenderer
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
    public void RenderInit()
    { 
        _screen = NCurses.InitScreen(); 
      
        if(NCurses.HasColors())
        {
            NCurses.StartColor();
            InitColors();
        }
        
        NCurses.NoDelay(_screen, true);
        NCurses.SetCursor(0);
        NCurses.NoEcho();
    }

    public void CleanUp()
    {
        NCurses.EndWin();
    }

    private void InitColors()
    {
        for (short i = 1; i < 8; i++)
            NCurses.InitPair(i, ColorTable[i], CursesColor.BLACK);
    }
    
    private static void AddStr(int y, int x, string str)
    {
        if (x >= 0 && x < NCurses.Columns && y >= 0 && y < NCurses.Lines)
            NCurses.MoveAddString(y, x, str);
    }
}