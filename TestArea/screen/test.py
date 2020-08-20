import sys
from PIL import Image  # pip install pillow

a = []


def rgb_to_hex(r, g, b):
    return '0x%02x%02x%02x' % (r, g, b)


with Image.open('img.png') as image:
    pixels = image.load()
    for y in range(image.height):
        for x in range(image.width):
            r = pixels[x, y][0]
            g = pixels[x, y][1]
            b = pixels[x, y][2]
            rgb = ((r & 0b11111000) << 8) | ((g & 0b11111100) << 3) | (b >> 3)
            a.append('0x%02x' % rgb)

with open("image.h", "w") as output_file:
    output_file.write("const uint16_t test[] PROGMEM = {\n")
    for item in a:
        output_file.write("\t%s,\n" % item)
    output_file.write("};")
