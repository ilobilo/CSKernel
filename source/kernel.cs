namespace Kernel
{
    public unsafe class Program
    {
        public static stivale2.stivale2_struct_tag_framebuffer* frm_tag;
        public static void Main()
        {
            // Required dummy call
            stivale2.stivale2_struct* test = null;
            RealMain(test);
        }

        public static void RealMain(stivale2.stivale2_struct* stiv)
        {
            if (stiv == null) while (true);

            frm_tag = (stivale2.stivale2_struct_tag_framebuffer*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_FRAMEBUFFER_ID);
        }
    }
}
