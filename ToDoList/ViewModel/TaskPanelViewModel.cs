using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using ToDoList.Commands;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    internal  class TaskPanelViewModel : ViewModelBase
    {
        private TaskViewModel _newTaskViewModel;
        private List<string> _tasksDescription;

        public RelayCommand AddTaskCommand { get; }
        public RelayCommand RemoveTaskCommand { get; }

        private string _newTask;
        public string NewTask
        {
            get { return _newTask; }
            set { _newTask = value; }
        }

        private TaskViewModel _selectedTask;
        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set { _selectedTask = value; }
        }

        private ObservableCollection<TaskViewModel> _tasks;
        public ObservableCollection<TaskViewModel> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
            }
        }

        public TaskPanelViewModel()
        {
            _tasks = new ObservableCollection<TaskViewModel>();
            _tasksDescription = new List<string>();
            AddTaskCommand = new RelayCommand(AddTask);
            RemoveTaskCommand = new RelayCommand(RemoveTask);

            _tasksDescription = File.ReadAllLines(AppConfig.TASK_DATA_PATH).ToList();

            LoadToTaskPanel();
        }

        

        private void AddTask(object parameter) 
        {
            _newTaskViewModel = new TaskViewModel(new TaskModel(NewTask, false));

            if (_newTaskViewModel.Description != null)
            { 
                Tasks.Add(_newTaskViewModel);
                _tasksDescription.Add(NewTask+"0");
                File.WriteAllLines(AppConfig.TASK_DATA_PATH, _tasksDescription);
            }
        }

        private void RemoveTask(object parameter) 
        {

            if (SelectedTask != null)
            {

                List<string> tempList = new List<string>();

                foreach (var taskDescription in _tasksDescription)
                {
                    string tempString = taskDescription.Remove(taskDescription.Length - 1);

                    if (!tempString.Equals(SelectedTask.Description) )
                    { 
                        tempList.Add(taskDescription);
                    }
                }

                File.WriteAllLines(AppConfig.TASK_DATA_PATH, tempList);
                _tasksDescription = tempList;
                Tasks.Remove(SelectedTask);

            }

        }


        private void LoadToTaskPanel() 
        {
            if (!File.Exists(AppConfig.TASK_DATA_PATH )) return;

            _tasksDescription = File.ReadAllLines(AppConfig.TASK_DATA_PATH).ToList();

            if (_tasksDescription.Any())
            {

                char[] chars = { '0', '1' };


                for (int i = 0; i < _tasksDescription.Count; i++)
                {
                    string stringTemp = _tasksDescription[i];
                    bool tempBool;

                    if (stringTemp.Last().Equals('0'))
                    {
                        tempBool = false;
                    }
                    else
                    {
                        tempBool = true;
                    }

                    Tasks.Add(new TaskViewModel(new TaskModel(_tasksDescription.ElementAt(i).Remove(stringTemp.Length - 1), tempBool)));

                }
            }
        }

    }
}
