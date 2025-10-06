import tkinter as tk

def on_enter(event):
    print("Enter key pressed")

# Create the main window
root = tk.Tk()
root.title("Bind Enter Key Example")

# Create an Entry widget
entry = tk.Entry(root)
entry.pack(pady=10)

# Bind the Enter key to the Entry widget
entry.bind("<Return>", on_enter)

# Run the Tkinter event loop
root.mainloop()
