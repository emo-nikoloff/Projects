import tkinter as tk
from tkinter import ttk

# Прозорец
window = tk.Tk()
window.title("Бутончета")
window.geometry("300x300")

# Бутон
def button_action():
    button_string.set("БУТОН!!!")

def disableButton_action():
    button["state"] = "disabled"
    printButton["state"] = "disabled"
    checkButton["state"] = "disabled"
    radio1["state"] = "disabled"
    radio2["state"] = "disabled"

def enableButton_action():
    button["state"] = "enabled"
    printButton["state"] = "enabled"
    checkButton["state"] = "enabled"
    radio1["state"] = "enabled"
    radio2["state"] = "enabled"

def printButton_action():
    print(radio_var.get())

button_string = tk.StringVar(value = "Бутонче")
button = ttk.Button(window, text = "Бутонче", command = button_action, textvariable = button_string)
button.pack()
disableButton = ttk.Button(window, text = "Заключи бутоните", command = disableButton_action)
disableButton.pack(side = "bottom")
enableButton = ttk.Button(window, text = "Отключи бутоните", command = enableButton_action)
enableButton.pack(side = "bottom")
printButton = ttk.Button(window, text = "Принтирай", command = printButton_action)
printButton.pack()

# Отметка
def checkButton_action():
    if checkButton_var.get() == "СЛАГАЙ!":
        checkButton.config(text = "Ти сложи отметка ;)")
    if checkButton_var.get() == "МАХАЙ!":
        checkButton.config(text = "Ти премахна отметката ;(")

checkButton_var = tk.StringVar()
checkButton = ttk.Checkbutton(window, text = "Сложи отметка", variable = checkButton_var, command = checkButton_action, onvalue = "СЛАГАЙ!", offvalue = "МАХАЙ!")
checkButton.pack()

# Радио бутон
radio_var = tk.StringVar()
radio1 = ttk.Radiobutton(window, text = "Радиобутон 1", value = 1, variable = radio_var)
radio1.pack()
radio2 = ttk.Radiobutton(window, text = "Радиобутон 2", value = 2, variable = radio_var)
radio2.pack()

# Стартиране
window.mainloop()
