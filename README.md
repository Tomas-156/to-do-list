#  To-Do List

A simple To-Do List app built using **C#** and **WPF**. The primary goal of this project was to implement the basics of the **MVVM** pattern.

## Project Goals
The main focus was to learn the basics of MVVM by decoupling the UI from the business logic using:
* **MVVM Pattern:** Separation of concerns between the Model, View, and ViewModel.
* **INotifyPropertyChanged:** Ensuring real-time UI updates when the underlying data changes.
* **ICommand Interface:** Handling user actions (Add/Remove) via Commands instead of event handlers in the Code-Behind.

## Features
* **Add Tasks:** Quickly enter new items into the list.
* **Mark as Done:** Click on the checkbox next to the task text to toggle its completed status.
* **Delete Tasks:** Easily remove tasks you no longer need.
* **Save Data:** All tasks are automatically saved to a **.txt file**, so your list is preserved even after closing the app.

## How to Run
1.  **Clone** the repository.
2.  **Open** the solution file (`.sln`) in Visual Studio.
3.  **Press F5** to build and run the application.

<img width="989" height="649" alt="image" src="https://github.com/user-attachments/assets/da5d9f0b-f825-4f05-b3db-1efbbf3cab4a" />
<p align="center"><i>Main application interface showing the task list.</i></p>
