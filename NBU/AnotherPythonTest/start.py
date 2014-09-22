from graphics import *
win = GraphWin("Convertor", 300, 200)

win.setCoords(0.0, 0.0, 3.0, 4.0)
Text(Point(1, 3), " Celsius:").draw(win)
Text(Point(1, 1), " Fahrenheit:").draw(win)
input = Entry(Point(2, 3), 5)
input.setText("0.0")
input.draw(win)

output = Text(Point(2, 1), "")
output.draw(win)

button = Text(Point(1.5, 2.0), "Convert").draw(win)
Rectangle(Point(1, 1.5), Point(2, 2.5)).draw(win)

win.getMouse()
celsius = eval(input.getText())
fahrenheit = celsius * 9.0 / 5.0 + 32
output.setText(fahrenheit)
button.setText("Quit")

win.getMouse()
win.close()