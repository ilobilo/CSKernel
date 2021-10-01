namespace Kernel
{
    public enum ConsoleColour
    {
        Black,
        Blue,
        Green,
        Cyan,
        Red,
        Purple,
        Brown,
        Grey,
        DarkGrey,
        LightBlue,
        LightGreen,
        LightCyan,
        LightRed,
        LightPurple,
        Yellow,
        White,
    };
    public unsafe static class Console
    {
        public static ushort* vga = (ushort*)0xB8000;
        public static int x = 0, y = 0, lastx = 0;
        public static ConsoleColour ForegroundColour = ConsoleColour.White;
        public static ConsoleColour BackgroundColour = ConsoleColour.Black;

        public static void Clear(byte colour = 0)
        {
            for (int yy = 0; yy < 25; yy++)
            {
                for (int xx = 0; xx < 80; xx++)
                {
                    vga[y * 80 + x] = (ushort)(colour << 8 | ' ');
                }
            }
            x = 0;
            y = 0;
        }

        public static void Write(string s, ConsoleColour bgcolour, ConsoleColour fgcolour)
        {
            foreach(char c in s)
            {
                PutChar(c, bgcolour, fgcolour);
            }
        }

        public static void WriteLine(string s, ConsoleColour bgcolour, ConsoleColour fgcolour)
        {
            foreach(char c in s)
            {
                PutChar(c, bgcolour, fgcolour);
            }
            PutChar('\n', bgcolour, fgcolour);
        }

        public static void Write(string s)
        {
            foreach(char c in s)
            {
                PutChar(c, BackgroundColour, ForegroundColour);
            }
        }

        public static void WriteLine(string s)
        {
            foreach(char c in s)
            {
                PutChar(c, BackgroundColour, ForegroundColour);
            }
            PutChar('\n', BackgroundColour, ForegroundColour);
        }

        static void PutChar(char c, ConsoleColour bgcolour, ConsoleColour fgcolour)
        {
            switch (c)
            {
                case '\n':
                    lastx = x;
                    x = 0;
                    y++;
                    break;
                case '\b':
                    if (x > 0)
                    {
                        x--;
                        vga[y * 80 + x] = (ushort)(((byte)bgcolour << 12) | ((byte)fgcolour << 8) | ' ');
                    }
                    else
                    {
                        x = lastx;
                        y--;
                    }
                    break;
                case '\r':
                    x = 0;
                    break;
                default:
                    vga[y * 80 + x] = (ushort)(((byte)bgcolour << 12) | ((byte)fgcolour << 8) | c);
                    if (x < 80) x++;
                    else
                    {
                        lastx = x;
                        x = 0;
                        y++;
                    }
                    break;
            }
        }
    }
}
