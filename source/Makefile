SOURCEDIR := $(shell dirname $(realpath $(firstword $(MAKEFILE_LIST))))

KERNEL := $(SOURCEDIR)/kernel.elf
KERNELEXE := $(KERNEL:.elf=.exe)
KERNELO := $(KERNEL:.elf=.o)
ISO := $(SOURCEDIR)/../image.iso

LIMINE = $(SOURCEDIR)/../limine/limine-install

QEMU = qemu-system-x86_64
QEMUFLAGS = -M q35 -enable-kvm -cpu max -smp 12 -m 512M -boot d -rtc base=localtime

XORRISO = xorriso
XORRISOFLAGS = -as mkisofs -b limine-cd.bin \
		-no-emul-boot -boot-load-size 4 -boot-info-table \
		--efi-boot limine-eltorito-efi.bin -efi-boot-part \
		--efi-boot-image --protective-msdos-label

LD = ld
AS = nasm
AOT = tysila2
CSC = mono-csc

LDFLAGS = -T $(SOURCEDIR)/linker.ld -m elf_x86_64 -z max-page-size=0x1000
ASMFLAGS = -f elf64 
AOTFLAGS = --arch x86_64-elf64-tysos -fno-rtti -fno-exceptions -q
CSCFLAGS = -unsafe -target:exe -platform:x86 
CSFILES = $(shell find $(SOURCEDIR)/ -type f -name '*.cs')
ASMFILES = $(shell find $(SOURCEDIR)/ -type f -name '*.asm')
OBJ = $(ASMFILES:.asm=_asm.o)

.PHONY: all

all: $(KERNEL) iso clean run

$(KERNEL): $(OBJ)
	$(CSC) $(CSCFLAGS) $(CSFILES) -out:$(KERNELEXE)
	$(AOT) $(AOTFLAGS) $(KERNELEXE) -o $(KERNELO) 
	$(LD) $(LDFLAGS) $(INTERNALLDFLAGS) $(OBJ) $(KERNELO) -o $@

%_asm.o: %.asm
	$(AS) $(ASMFLAGS) $^ -o $@

iso:
	cp $(KERNEL) $(BACKGROUND) $(SOURCEDIR)/../limine.cfg $(SOURCEDIR)/../limine/limine.sys \
		$(SOURCEDIR)/../limine/limine-cd.bin $(SOURCEDIR)/../limine/limine-eltorito-efi.bin $(SOURCEDIR)/../iso_root/
	$(XORRISO) $(XORRISOFLAGS) $(SOURCEDIR)/../iso_root -o $(ISO) 2> /dev/null
	$(LIMINE) $(ISO)

clean:
	rm -rf $(KERNEL) $(OBJ) $(KERNELEXE) $(KERNELO) $(SOURCEDIR)/../iso_root/*

run:
	$(QEMU) $(QEMUFLAGS) -cdrom $(ISO)