KERNELDIR := $(shell dirname $(realpath $(firstword $(MAKEFILE_LIST))))

all: limine
	@mkdir -p $(KERNELDIR)/iso_root
	@make -s -C $(KERNELDIR)/source

limine:
	@git clone https://github.com/limine-bootloader/limine.git --single-branch --branch=latest-binary --depth=1
	@make -C $(KERNELDIR)/limine

clean:
	@make -s -C $(KERNELDIR)/source clean

distclean:
	@make -s -C $(KERNELDIR)/source clean
	@rm -rf $(KERNELDIR)/limine
	@rm -rf $(KERNELDIR)/iso_root
