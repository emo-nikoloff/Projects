import tkinter as tk
from tkinter import ttk

window = tk.Tk()
window.title("Нещо ще се случи")
window.geometry("500x150")

"""
def outer_func(parameter):
    def inner_func():
        print("Ти натисна магическия бутон и принтира:")
        print(parameter.get())

    return inner_func
"""

def button_action(parameter):
    print("Ти натисна магическия бутон и принтира:")
    print(parameter.get())

entry_string = tk.StringVar()
entry = ttk.Entry(window, textvariable = entry_string)
entry.pack()

"""
button = ttk.Button(window, text = "Магически бутон", command = outer_func(entry_string))
button.pack()
"""

button = ttk.Button(window, text = "Магически бутон", command = lambda: button_action(entry_string))
button.pack()

closeButton = ttk.Button(window, text = "Затвори програмата", command = lambda: exit())
closeButton.pack()

window.mainloop()
