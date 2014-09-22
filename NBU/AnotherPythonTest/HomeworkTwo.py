import re
# Homework 2: Write a script that takes an HTML source file as input and prints it so that a newline follows only
# "closing tags", i.e. tags that are of the form </...>.

# Open and read the HTML file
htmlFile = open("test.html", "r")
fullHtmlText = htmlFile.read()

# Remove all NewLine operators
fullHtmlText = fullHtmlText.replace("\n", '')

# Compile the Regex pattern
regEx = re.compile(r'</(?!/?(?=>|\s.*>))/?.*?>')

# Find all start and end indexes of matches
foundMatches = re.finditer(regEx, fullHtmlText)

# Initialize a string to hold the modified result and a variable which holds the last end index
lineList = ""
lastEnd = 0

# Loop over all matches and append the index of the last match end to the index of the next match end
# + a NewLine character
for match in foundMatches:
    lineList += fullHtmlText[lastEnd:match.end(0)] + "\n"
    # Set the last match end index to the current match end index
    lastEnd = match.end(0)
print(lineList)