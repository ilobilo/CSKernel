global _ZN6kernel6Kernel2IOM_0_4outb_Rv_P2th
global _ZN6kernel6Kernel2IOM_0_4outw_Rv_P2tt
global _ZN6kernel6Kernel2IOM_0_4outl_Rv_P2tj
global _ZN6kernel6Kernel2IOM_0_3inb_Rh_P1t
global _ZN6kernel6Kernel2IOM_0_3inw_Rt_P1t
global _ZN6kernel6Kernel2IOM_0_3inl_Rj_P1t

_ZN6kernel6Kernel2IOM_0_4outb_Rv_P2th:
    push rbp
    mov rbp, rsp

    mov rdx, [rbp+16]
    out dx, al

    pop rbp
    ret

_ZN6kernel6Kernel2IOM_0_4outw_Rv_P2tt:
    push rbp
    mov rbp, rsp

    mov rdx, [rbp+16]
    out dx, ax

    pop rbp
    ret

_ZN6kernel6Kernel2IOM_0_4outl_Rv_P2tj:
    push rbp
    mov rbp, rsp

    mov rdx, [rbp+16]
    out dx, eax

    pop rbp
    ret

_ZN6kernel6Kernel2IOM_0_3inb_Rh_P1t:
    push rbp
    mov rbp, rsp

    mov rdx, [rbp+16]
    in al, dx

    pop rbp
    ret

_ZN6kernel6Kernel2IOM_0_3inw_Rt_P1t:
    push rbp
    mov rbp, rsp

    mov rdx, [rbp+16]
    in ax, dx

    pop rbp
    ret

_ZN6kernel6Kernel2IOM_0_3inl_Rj_P1t:
    push rbp
    mov rbp, rsp

    mov rdx, [rbp+16]
    in eax, dx

    pop rbp
    ret