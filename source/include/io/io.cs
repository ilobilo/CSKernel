using System.Runtime.CompilerServices;

namespace Kernel
{
    public static class IO
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern void outb(ushort port, byte value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern void outw(ushort port, ushort value);
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern void outl(ushort port, uint value);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern byte inb(ushort port);
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern ushort inw(ushort port);
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static unsafe extern uint inl(ushort port);
    }
}