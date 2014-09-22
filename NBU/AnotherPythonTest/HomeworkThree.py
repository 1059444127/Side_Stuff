from graphics import *
file = open("list.txt", "r")
text = file.readlines()
print(text)
studentsLength = text[0]
height = int(studentsLength) * 50
win = GraphWin("Student Bars", 400, height)
win.setCoords(0.0, 0.0, 3.0, 4.5)
del text[0]
studentStartingPointYAxis = 4
for student in text:
    studentsSplit = str(student).split(' ')

    startingPoint = Point(1, studentStartingPointYAxis)
    rectangleStartingPoint = Point(1.5, studentStartingPointYAxis - 0.4)

    studentNameDraw = Text(startingPoint, studentsSplit[0])
    studentNameDraw.draw(win)

    studentBarLength = float(studentsSplit[1]) / 100
    print(studentBarLength)
    studentBarDraw = Rectangle(rectangleStartingPoint, Point(1.5 + studentBarLength, studentStartingPointYAxis)).draw(win)

    studentStartingPointYAxis -= 0.7

# Rectangle(Point(1, 1), Point(1.5, 1.5)).draw(win)
win.getMouse()