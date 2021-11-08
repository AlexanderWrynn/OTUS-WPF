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
        }

        public ICommand AddEmployeeCommand { get { return new Command(AddEmployee); } }
        public ICommand CreateTreeCommand { get { return new Command(CreateTree); } }
        public ObservableCollection<Employee> Employees { get; private set; }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public Employee TreeEmployee = null;

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

            TreeEmployee = employee;
        }

    }
}