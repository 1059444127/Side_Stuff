import re
file = open("source.html", "r")
text = file.readlines()
file.close()
firstIndex = text.find('<')
lines = []
