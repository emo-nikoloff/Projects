import tkinter as tk
import ttkbootstrap as ttk
import _tkinter
import tkinter.messagebox as msgbox

def convert():
    try:
        miles_input = entry_var.get()
        if miles_input != str:
            kilometers_output = miles_input * 1.61
            output_string.set(round(kilometers_output, 2))
        else:
            raise _tkinter.TclError
    except _tkinter.TclError:
        msgbox.showerror("Грешка", "САМО ЧИСЛА!!!!")

window = ttk.Window(themename = "united")
window.title("Калкулатор")
window.geometry("500x150")
window.bind("<Return>", lambda event: convert())

label = ttk.Label(master = window, text = "Калкулатор за превръщане на мили в километри", font = "Calibri 15 italic bold")
label.pack()

input_frame = ttk.Frame(master = window, borderwidth = 5)
entry_var = tk.DoubleVar(value = "")
entry = ttk.Entry(master = input_frame, textvariable = entry_var, font = "Calibri 10")
button = ttk.Button(master = input_frame, text = "Превръщане", command = convert)
miles_label = ttk.Label(master = input_frame, text = "Мили:", font = "Calibri 10 bold")
miles_label.pack(side = "left")
entry.pack(side = "left")
button.pack(side = "left")
input_frame.pack(pady = 15)

output_frame = ttk.Frame(master = window)
output_string = tk.StringVar()
output_box = ttk.Entry(master = output_frame, font = "Calibri 10", textvariable = output_string, state = "readonly")
kilometers_label = ttk.Label(master = output_frame, text = "Километри:", font = "Calibri 10 bold")
kilometers_label.pack(side = "left")
output_box.pack(side = "left")
output_frame.pack()

window.mainloop()
