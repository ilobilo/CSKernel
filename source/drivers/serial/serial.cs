namespace Kernel
{
    public static class Serial
    {
        static int is_transmit_empty()
        {
            return IO.inb(0x3F8 + 5) & 0x20;
        }

        static void PutChar(char c)
        {
            while (is_transmit_empty() == 0);
            IO.outb(0x3F8, (byte)c);
        }

        public static void Print(string str)
        {
            foreach (char c in str)
            {
                PutChar(c);
            }
        }

        public static void Info(string str)
        {
            Print("[\u001b[33mINFO\u001b[0m] ");
            Print(str);
            Print("\n");
        }

        public static void Error(string str)
        {
            Print("[\u001b[31mERROR\u001b[0m] ");
            Print(str);
            Print("\n");
        }

        public static void Init()
        {
            IO.outb(0x3F8 + 1, 0x00);
            IO.outb(0x3F8 + 3, 0x80);
            IO.outb(0x3F8 + 0, 0x03);
            IO.outb(0x3F8 + 1, 0x00);
            IO.outb(0x3F8 + 3, 0x03);
            IO.outb(0x3F8 + 2, 0xC7);
            IO.outb(0x3F8 + 4, 0x0B);

            Print("\u001b[H\u001b[0m\u001b[2J");
        }
    }
}