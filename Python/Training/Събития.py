import tkinter as tk
from tkinter import ttk

window = tk.Tk()
window.title("Събития")
window.geometry("500x500")

text = tk.Text(window)
text.pack()

entry = ttk.Entry(window)
entry.pack()

button = ttk.Button(window)
button.pack()

button.bind("<Return>", lambda event: print("an event"))

window.mainloop()
