using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class Employee : ViewModel
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string OutputData => Name + " - " + Salary;
        public Employee Left { get; set; }
        public Employee Right { get; set; }

        public static void Add(Employee current, Employee toAdd)
        {
            if (toAdd.Salary < current.Salary)
            {
                if (current.Left != null)
                {
                    Add(current.Left, toAdd);
                }

                else
                {
                    current.Left = toAdd;
                }
            }

            else
            {
                if (current.Right != null)
                {
                    Add(current.Right, toAdd);
                }

                else
                {
                    current.Right = toAdd;
                }
            }
        }

        public static void Traverse(Employee employee, ObservableCollection<Employee> SortedEmployees)
        {

            if (employee.Left != null)
            {
                Traverse(employee.Left, SortedEmployees);
            }

            SortedEmployees.Add(employee);

            if (employee.Right != null)
            {
                Traverse(employee.Right, SortedEmployees);
            }

        }

        public static string SearchSalary(ObservableCollection<Employee> Employees, int inputForSearch)
        {
            for (int i = 0; i < Employees.Count; i++)
            {
                if (Employees[i].Salary == inputForSearch)
                {
                    return Employees[i].OutputData;
                }
            }
            return "Ничего не найдено";
        }
    }
}