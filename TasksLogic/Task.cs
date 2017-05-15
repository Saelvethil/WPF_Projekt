using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TasksLogic
{
    public class Task
    {
        public ObservableCollection<Subtask> ToDoList;
        public ObservableCollection<Subtask> DoingList;
        public ObservableCollection<Subtask> DoneList;

        public Task()
        {
            ToDoList = new ObservableCollection<Subtask>();
            DoingList = new ObservableCollection<Subtask>();
            DoneList = new ObservableCollection<Subtask>();
        }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public Category Category { get; set; }

        public void MoveSubtask(Subtask subtask, List<Subtask> source, List<Subtask> destination)
        {
            source.Remove(subtask);
            destination.Add(subtask);
        }

    }
}
