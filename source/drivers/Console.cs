namespace Kernel
{
    public unsafe static class Console
    {
        public static ushort* vga = (ushort*)0xB8000;
        public static int x = 0, y = 0;

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
        
        public static void Write(string s)
        {
            foreach(char c in s)
            {
                PutChar(c);
            }
        }

        static void PutChar(char c, byte colour = 0x0F)
        {
            vga[y * 80 + x] = (ushort)(colour << 8 | c);
            if (x < 80) x++;
            else
            {
                x = 0;
                y++;
            }
        }
    }
}