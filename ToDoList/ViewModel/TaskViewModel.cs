using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoList.Commands;
using ToDoList.Model;

namespace ToDoList.ViewModel
{
    internal class TaskViewModel : ViewModelBase
    {
        private TaskModel _taskModel;
        public RelayCommand SetDoneCommand { get; }


        public string Description { get { return _taskModel.Description; } set { _taskModel.Description = value; OnPropertyChanged("Description"); } }
        public bool IsDone { get { return _taskModel.IsDone; } set { _taskModel.IsDone = value; } }


        private TextDecorationCollection _strikeTextDecoration;
        public TextDecorationCollection StrikeTextDecoration
        {
            get { return _strikeTextDecoration; }
            set { _strikeTextDecoration = value; OnPropertyChanged("StrikeTextDecoration"); }
        }

        public TaskViewModel(TaskModel taskModel)
        {
            _taskModel = taskModel;
            SetDoneCommand = new RelayCommand(SetDoneSwitch);

            if (IsDone)
            {
                SetDone();
            }
        }


        public void SetDone()
        {
            if (IsDone == true)
            {
                StrikeTextDecoration = new TextDecorationCollection(TextDecorations.Strikethrough);
            }
            else
            {
                StrikeTextDecoration = new TextDecorationCollection();
            }

        }

        public void SetDoneSwitch(object parameter)
        {
            SetDone();
            EditTask();
        }

        void EditTask() 
         {
            List<string> tempList;
            tempList = File.ReadAllLines(AppConfig.TASK_DATA_PATH).ToList();

            for (int i = 0; i < tempList.Count; i++)
            {
                string tempString = tempList[i];

                if (tempString.Remove(tempString.Length - 1).Equals(Description)) 
                {
                    if (tempString.Equals( Description+"0"))
                    {
                        tempString = tempString.Remove(tempString.Length - 1);
                        tempString = tempString + "1";
                        tempList[i] = tempString; 
                    }
                    else if (tempString.Equals(Description+"1"))
                    {
                        tempString = tempString.Remove(tempString.Length - 1);
                        tempString = tempString + "0";
                        tempList[i] = tempString;
                    }
                }

            }

            File.WriteAllLines(AppConfig.TASK_DATA_PATH, tempList);
        }

        
    }
}
