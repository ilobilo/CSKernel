using System.Runtime.CompilerServices;

namespace Kernel
{
    public static class GDT
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern void GDT_init();
    }
}