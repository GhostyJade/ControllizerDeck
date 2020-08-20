import sys

a = []

with open("img.png", "rb") as image:
    f = image.read()
    b = bytearray(f)
    for value in b:
        a.append(hex(value))  # print(hex(value))
        pass

with open("image.h", "w") as output_file:
    output_file.write("const uint16_t test[] PROGMEM = {\n")
    for item in a:
        output_file.write("\t%s,\n" % item)
    output_file.write("};")
