import tkinter as tk
from tkinter import ttk

URL = "https://www.pythontutorial.net/tkinter/"

def convert():
    miles_input = entry_int.get()
    kilometers_output = miles_input * 1.61
    output_string.set(kilometers_output)

# Прозорец
window = tk.Tk()
window.title("Калкулатор")
window.geometry("500x150")

# Етикет
label = ttk.Label(master = window, text = "Калкулатор за превръщане на мили в километри", font = "Calibri 15 italic bold")
label.pack()

# Поле за въвеждане
input_frame = ttk.Frame(master = window)
entry_int = tk.IntVar()
entry = ttk.Entry(master = input_frame, textvariable = entry_int)
button = ttk.Button(master = input_frame, text = "Превръщане", command = convert)
entry.pack(side = "left")
button.pack(side = "left")
input_frame.pack(pady = 15)

# Изход
output_string = tk.StringVar()
output_label = ttk.Label(master = window, text = "Изход", font = "Calibri 10 bold", textvariable = output_string)
output_label.pack()

# Стартиране
window.mainloop()
