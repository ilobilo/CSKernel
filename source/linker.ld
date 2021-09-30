ENTRY (_start)
 
SECTIONS
{
    . = 0x00100000;

    .stivale2hdr ALIGN(0x1000) :
    {
        KEEP(*(.stivale2hdr))
    }
 
    .text ALIGN(0x1000) :
    {
        *(.text)
    }

    .rodata ALIGN(0x1000) :
    {
        *(.rodata*)
    }
 
    .data ALIGN(0x1000) :
    {
        *(.data)
    }
 
    .bss ALIGN(0x1000) :
    {
        *(COMMON)
        *(.bss)
    }
}
