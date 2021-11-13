using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfHomeWork.Implementations;

namespace WpfHomeWork
{
    internal class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            Employees = new ObservableCollection<Employee>();
            SortedEmployees = new ObservableCollection<Employee>();
        }

        public ICommand AddEmployeeCommand { get { return new Command(AddEmployee); } }
        public ICommand CreateTreeCommand { get { return new Command(CreateTree); } }
        public ICommand SearchCommand { get { return new Command(Search); } }
        public ObservableCollection<Employee> Employees { get; private set; }
        public ObservableCollection<Employee> SortedEmployees { get; private set; }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int InputForSearch { get; set; }
        public string FoundedEmployee { get; set; }
        private void AddEmployee()
        {
            var employee = new Employee() { Name = this.Name, Salary = this.Salary };
            Employees.Add(employee);

            Name = null;
            Salary = 0;
            RaisePropertyChanged(() => Name);
            RaisePropertyChanged(() => Salary);
        }

        private void CreateTree()
        {
            Employee employee = null;

            for (int i = 0; i < Employees.Count; i++)
            {
                if (employee == null)
                {
                    employee = new Employee { Name = Employees[i].Name, Salary = Employees[i].Salary };
                }

                else
                {
                    Employee.Add(employee, new Employee { Name = Employees[i].Name, Salary = Employees[i].Salary });
                }
            }

            Employee.Traverse(employee, SortedEmployees);
        }

        private void Search()
        {
            FoundedEmployee = Employee.SearchSalary(Employees, InputForSearch);
            RaisePropertyChanged(() => FoundedEmployee);
        }
    }
}