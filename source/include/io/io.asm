global _ZN6kernel6Kernel2IOM_0_5Write_Rv_P2th
_ZN6kernel6Kernel2IOM_0_5Write_Rv_P2th:
    push rbp
    mov rbp, rsp

    mov dx, [rbp + 8]
    mov al, [rbp + 12]

    out dx, al

    mov rsp, rbp
    pop rbp
    retq

global _ZN6kernel6Kernel2IOM_0_4Read_Rh_P1t
_ZN6kernel6Kernel2IOM_0_4Read_Rh_P1t:
    push rbp
    mov rbp, rsp

    mov dx, [rbp + 8]

    in al, dx

    mov rsp, rbp
    pop rbp
    retq