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

<div style="border: 1px solid #e1e4e8; border-radius: 6px; padding: 10px; display: inline-block;">
  <img width="779" height="486" alt="image" src="https://github.com/user-attachments/assets/0c391f27-8cf6-4408-9486-be040d780de9" />
</div>
<p align="center"><i>Main application interface showing the task list.</i></p>
