global sthrow

extern _ZN6kernel6Kernel7ProgramM_0_8RealMain_Rv_P1PV26stivale2#2Bstivale2_struct

section .data
; Terminal
stivale2_terminal_tag:
    dq 0xa85d499b1823be72
    dq 0
    dq 0
    dq 0

; Symmetric multiprocessing
stivale2_smp_tag:
    dq 0x1ab015085f3273df
    dq stivale2_terminal_tag
    dq 0

; Framebuffer
stivale2_framebuffer_tag:
    dq 0x3ecc1bc43d0f7971
    dq stivale2_smp_tag
    dw 0
    dw 0
    dw 32

; Temporary text mode
stivale2_any_video_tag:
    dq 0xc75c9fa92a44c4db
    dq stivale2_smp_tag
    dq 1

section .bss
align 16
stack_bottom:
resb 8192
stack_top:

section .stivale2hdr
align 4
stivale_hdr:
    dq kmain
    dq stack_top
    dq (1 << 1)
    dq stivale2_framebuffer_tag

section .text
kmain:
    push rdi
    call _ZN6kernel6Kernel7ProgramM_0_8RealMain_Rv_P1PV26stivale2#2Bstivale2_struct

sthrow:
    hlt
    jmp sthrow