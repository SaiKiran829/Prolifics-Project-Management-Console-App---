using MODEL;
using System.Net.Http.Headers;

namespace DOMAIN
{
    //Class which consists of methods for adding and viewing projects
    public class ProjectManagement
    {
        private static readonly List<Project> projects1 = new List<Project>();
        public List<Project> projects = projects1;
        readonly EmployeeManagement obj1 = new EmployeeManagement();

        //Method for adding projects
        public void AddingProjects(Project project)
        {
            projects.Add(project);
        }
        public void DisplayProject(Project project)
        {
            Console.WriteLine(" Name of the project - " + project.projectName + "\n Project Id - " + project.id + "\n Start date of project - " + project.startDate + "\n End date of project - " + project.endDate);
            Console.WriteLine("");
        }

        public void DisplayAllProjects()
        {
            if (projects.Count == 0)
            {
                Console.WriteLine("The List is Empty !!!");
            }
            else
            {
                foreach (var e in projects)
                {
                    DisplayProject(e);
                }
            }
        }

        public Boolean IfNoEmployeesInProject(int pid)
        {
            for(int i =0;i< projects.Count;i++)
            {
                if (projects[i].id == pid && projects[i].EmployeeListfromEmployeeManagement.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Employee> SearchForEmployee(int readingProjectId)
        {
            foreach(Project e in projects)
            {
                e.EmployeeListfromEmployeeManagement.Sort();
                if (!IfNoEmployeesInProject(readingProjectId) && e.id == readingProjectId)
                {
                    return e.EmployeeListfromEmployeeManagement;
                }
            }
            return null;
        }
        

        public void DisplayEmployeesInProjectById(int readingProjectId)
        {
            List<Employee> employee = SearchForEmployee(readingProjectId);
            if(employee != null)
            {
                for(int i =0;i<employee.Count;i++)
                {
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("Below are the details of employees in this project");
                        Console.WriteLine("-------------------------------------------------------------------------------------");
                        Console.WriteLine(employee[i].employeefirstName + " [" + employee[i].roleName + "]");
                    
                }
            }
            else
            {
                Console.WriteLine("No employees in this project");
            }
            /*foreach(Project e in projects)
            {
                e.EmployeeListfromEmployeeManagement.Sort();
                if (!IfNoEmployeesInProject(readingProjectId))
                {
                    if (e.id == readingProjectId)
                    {
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("\nProject Name - " + e.projectName + "\n");
                        Console.WriteLine("Below are the details of employees in this project");
                        foreach(Employee f in e.EmployeeListfromEmployeeManagement)
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine(f.employeefirstName + " [" + f.roleName + "]");
                        }
                    }
                }
            }*/
        }

        public void EmployeeToProject(int pid, Employee ename)
        {
            if (obj1.IfExists(pid))
            {
                for (int i = 0; i < projects.Count; i++)
                {
                    if (projects[i].id == pid)
                    {
                        projects[i].EmployeeListfromEmployeeManagement.Add(ename);
                    }
                }

            }
            else
            {
                Console.WriteLine("The employee with this id already exists in this project");
                Console.WriteLine("Enter any key to get to main menu");
                Console.ReadLine();
            }
        }

        public Project SearchProject(List<Project> projects ,int first,int last,int pid)
        {
            if (first <= last)
            {
                int midpoint = (first + last) / 2;
                if (projects[midpoint].id == pid)
                {
                    return projects[midpoint];
                }
                else if (projects[midpoint].id > pid)
                {
                    return SearchProject(projects, first, midpoint-1, pid);
                }
                else if (projects[midpoint].id < pid)
                {
                    return SearchProject(projects, midpoint+1, last, pid);
                }
            }
            return null;
        }

        public void AddingEmployeeToProject(int pid, Employee ename)
        {
            /*if (IfExist(pid))
            {
                for (int i = 0; i < projects.Count; i++)
                {
                    if (projects[i].id == pid)
                    {
                        projects[i].employeeListfromEmployeeManagement.Add(ename);
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Project does not exist");
                Console.WriteLine("Enter any key to get to main menu");
                Console.ReadLine();
            }*/
            /*List<Employee> emp = SearchProject(pid);
            if(emp != null)
            {
                emp.Add(ename);
            }
            else
            {
                Console.WriteLine("No project found");
            }*/
            foreach(Project e in projects)
            {
                if(e.id == pid)
                {
                        e.EmployeeListfromEmployeeManagement.Add(ename);
                }
            }
        }
        
        public void DeleteProject(int pid, Project project)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].id == pid)
                {
                    projects.Remove(project);
                }
            }
        }

        public void EmployeeFromProject(int pid, Employee ename)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (projects[i].id == pid)
                {
                    projects[i].EmployeeListfromEmployeeManagement.Remove(ename);
                }
            }
        }

        public void DeleteEmployeeFromProject(int eid, Employee ename)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                for(int j =0;i< projects[i].EmployeeListfromEmployeeManagement.Count;j++)
                {
                    if (projects[i].EmployeeListfromEmployeeManagement[j].employeeID == eid)
                    {
                        projects[i].EmployeeListfromEmployeeManagement.Remove(ename);
                    }
                }
                
            }
        }


        public Boolean IfExist(int pid)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (pid == projects[i].id)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean IfExistInEmployee(int empid)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                for (int j = 0; j < projects[i].EmployeeListfromEmployeeManagement.Count; j++)
                {
                    if (empid == projects[i].EmployeeListfromEmployeeManagement[j].employeeID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //Method to View all projects
        public void ShowProject(int eid)
        {
            projects.Sort();
            /*foreach (Project e in projects)
            {
                if (e.id == eid)
                {
                    DisplayProject(e);
                }
                else
                {
                    Console.WriteLine("Id not found");
                }
            }*/
            int first = 0;
            int last = projects.Count - 1;
            Project project = SearchProject(projects, first, last, eid);
            if (project != null)
            {
                DisplayProject(project);
            }
            else
            {
                Console.WriteLine("No project found with that id");
            }
        }

        public void SearchProjectByName(string search)
        {

            var match = projects.Where(c => c.projectName.Contains(search));
            foreach (var e in match)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" Name of the project - " + e.projectName + "\n Project Id - " + e.id + "\n Start date of project - " + e.startDate + "\n End date of project - " + e.endDate);
            }

        }
    }
    
    //Class which consists of methods for adding and viewing Employees 
    public class EmployeeManagement
    {
        private static readonly List<Employee> employees = new();
        public List<Employee> employeeList = employees;


        //Method for adding new employee
        public void AddEmployee(Employee emp)
        {
            employeeList.Add(emp);
        }


        public void DisplayEmployee(Employee emp)
        {


            Console.WriteLine(" Employee Id - " + emp.employeeID + "\n Employee first name - " + emp.employeefirstName + "\n Employee last name - " + emp.lastName + "\n Employee email id - " + emp.email + "\n Employee mobile number - " + emp.mobile + "\n Employee address - " + emp.address + "\n Role Id - " + emp.roleId + "\n Role Name - " + emp.roleName);
            Console.WriteLine("");
            Console.WriteLine("");

        }


        public Employee EmployeeDetails(int eid)
        {
            Employee emp = new Employee();
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (eid == employeeList[i].employeeID)
                {
                    emp = employeeList[i];
                    return emp;
                }
            }
            return emp;
        }



        //Method for viewing all employees
        public void ShowEmployees()
        {
            SortEmployeeById sortEmployeeById = new SortEmployeeById();
            employeeList.Sort(sortEmployeeById);
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No employees available");
            }
            else
            {
                foreach (var e in employeeList)
                {
                    DisplayEmployee(e);
                }
            }
        }

        public Employee SearchingEmployeeInEmployeeList(List<Employee> list, int first,int last,int x)
        {
            if (first <= last)
            {
                int midpoint = (first + last) / 2;
                if (list[midpoint].employeeID == x)
                {
                    return list[midpoint];
                }
                else if (list[midpoint].employeeID > x)
                {
                    return SearchingEmployeeInEmployeeList(list, first, midpoint - 1, x);
                }
                else if (list[midpoint].employeeID < x)
                {
                    return SearchingEmployeeInEmployeeList(list, midpoint + 1, last, x);
                }
            }
            return null;
        }
        public void ShowEmployee(int eid)
        {
            SortEmployeeById sortEmployeeById = new SortEmployeeById();
            employeeList.Sort(sortEmployeeById);
            int first = 0;
            int last = employeeList.Count - 1;
            Employee x = SearchingEmployeeInEmployeeList(employeeList,first,last,eid);
            if (x != null)
            {
                Console.WriteLine(" Employee Id - " + x.employeeID + "\n Employee first name - " + x.employeefirstName + "\n Employee last name - " + x.lastName + "\n Employee email id - " + x.email + "\n Employee mobile number - " + x.mobile + "\n Employee address - " + x.address + "\n Role Id - " + x.roleId + "\n Role Name - " + x.roleName);
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

        }

        public Boolean IfExists(int eid)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].employeeID == eid)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteEmployee(int employeeId, Employee employee)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                if (employeeList[i].employeeID == employeeId)
                {
                    ProjectManagement projectManagement = new ProjectManagement();
                    projectManagement.DeleteEmployeeFromProject(employeeId,employee);
                    employeeList.Remove(employee);
                }
            }
        }
    }

    //Class which consists of methods for adding and viewing roles
    public class RoleManagement
    {
        private static readonly List<Role> roles = new();
        public List<Role> roleList = roles;



        //Method for adding roles
        public void RoleAdd(Role role)
        {
            roleList.Add(role);
        }

        //Method for viewing all roles
        public void DisplayRole()
        {
            roleList.Sort();
            foreach (Role e in roleList)
            {
                Console.WriteLine(" Name of the Role - " + e.roleName + "\n Role Id - " + e.roleId);
                Console.WriteLine();
            }
        }

        public Role SearchRole(List<Role> roleList, int first, int last, int roleId)
        {
            if (first <= last)
            {
                int midpoint = (first + last)/ 2;
                if (roleList[midpoint].roleId == roleId)
                {
                    return roleList[midpoint];
                }
                else if (roleList[midpoint].roleId < roleId)
                {
                    return SearchRole(roleList, midpoint+1, last, roleId);
                }
                else if (roleList[midpoint].roleId > roleId)
                {
                    return SearchRole(roleList, first, midpoint-1, roleId);
                }
            }
            return null;
        }

        public void ListRoleById(int roleId)
        {
            roleList.Sort();
            int first = 0;
            int last = roleList.Count - 1;
            Role roleSelect = SearchRole(roleList,first,last,roleId);
            if(roleSelect != null)
            {
                Console.WriteLine(" Name of the Role - " + roleSelect.roleName + "\n Role Id - " + roleSelect.roleId);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Role with this roleSelect id does not exist");
            }
        }

        public void DeleteRole(int roleId)
        {
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].roleId == roleId)
                {
                    roleList.RemoveAt(i);
                }
            }
        }

        public Boolean IfExists(int roleId)
        {
            for (int i = 0; i < roleList.Count; i++)
            {
                if (roleList[i].roleId == roleId)
                {
                    return true;
                }
            }
            return false;
        }
    }

}