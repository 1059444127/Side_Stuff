import os, re
from email.utils import parseaddr

# Get a list of all directories and files in the "Test" directory
allFilesAndDirs = os.walk("Test")

# Set starting variables
totalFolderSize = 0
totalFilesCount = 0
totalDirsCount = 0

# Open the emails output file, so we don't have to reopen it on every loop cycle
emailsFile = open("emails.txt", "w")

# Set a regex pattern to match all valid email addresses
regEx = re.compile(r'\w+[.|\w]\w+@\w+[.]\w+[.|\w+]\w+')

print("Files: ")

# Loop over all dirs and files in the Test directory
for (path, dirs, files) in allFilesAndDirs:
    # Count all dirs
    for directory in dirs:
        totalDirsCount += 1
    for file in files:
        # Print filename
        print(file)
        # Count all files
        totalFilesCount += 1

        # Increment the total folder size
        filename = os.path.join(path, file)
        totalFolderSize += os.path.getsize(filename)

        # Open the current file in read mode, so we can check for emails
        file = open(filename, "r")

        containingText = file.read()

        # Find all emails
        results = regEx.findall(containingText)

        # First, modify the found email, so it replaces '@' with '(at)'
        # Then replace the original email with the modified one in the read text
        # Then save the original email in the email output file
        for result in results:
            modifiedResult = str(result).replace('@', "(at)")
            containingText = re.sub(result, modifiedResult, containingText)
            emailsFile.write(result + "\n")

        # Close the current file
        file.close()

        # Reopen it in write mode, which deletes all text
        file = open(filename, "w")

        # Write the text with the modified email addresses
        file.write(containingText)
        file.close()

emailsFile.close()

print()
print("Total folder size = %0.1f KB" % (totalFolderSize / 1024))
print("Files count = " + str(totalFilesCount))
print("Directories count = " + str(totalDirsCount))