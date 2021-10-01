using System.Runtime.CompilerServices;

namespace Kernel
{
    public static class IO
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern void Write(ushort port, byte value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern byte Read(ushort port);
    }
}