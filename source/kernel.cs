using System.Runtime.CompilerServices;

namespace Kernel
{
    public unsafe class Program
    {
        public static void Main()
        {
            // Required dummy call
            stivale2.stivale2_struct* test = null;
            RealMain(test);
        }
        public static stivale2.stivale2_struct_tag_framebuffer* frm_tag;
        public static stivale2.stivale2_struct_tag_terminal* term_tag;

        public static void RealMain(stivale2.stivale2_struct* stiv)
        {
            if (stiv == null) while (true);

            frm_tag = (stivale2.stivale2_struct_tag_framebuffer*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_FRAMEBUFFER_ID);
            term_tag = (stivale2.stivale2_struct_tag_terminal*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_TERMINAL_ID);

            Serial.Init();
            Serial.Info("Welcome to CSKernel!\n");
            Serial.Info("Serial COM1 Initialized!");
            GDT.GDT_init();
            Serial.Info("GDT Initialized!");

            while (true);
        }
    }
}
