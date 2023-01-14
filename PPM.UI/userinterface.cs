using System;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using DOMAIN;
using MODEL;

namespace UserInterface
{
    public class UI
    {
        public void View()
        {

            ProjectManagement obj = new ProjectManagement();
            EmployeeManagement obj1 = new EmployeeManagement();
            RoleManagement objmain = new RoleManagement();
            Project project = new Project();
            Employee employee = new Employee();
            objmain.roleList.Add(new Role(1, "Technical Lead"));
            objmain.roleList.Add(new Role(2, "Software Engineer"));
            objmain.roleList.Add(new Role(3, "Associate Software Engineer"));
            objmain.roleList.Add(new Role(4, "Trainee Software Engineer"));
            Boolean error = false;
            Regex phoneNumber = new Regex(@"(^[0-9]{10}$)|(^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$)|(^[0-9]{3}-[0-9]{4}-[0-9]{4}$)");
            Regex emailFormat = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Regex date = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");
        View:
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("******************************************|   Hello Prolifics employee   |**********************************************");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.Write("                                           Enter \"1\" to view Project Module");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("                                           Enter \"2\" to view Employee Module");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("                                           Enter \"3\" to view Role Module");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                           Enter \"x\" to exit application");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("");
            var read = Console.ReadLine();
            while (true)
            {
            repeat:
                switch (read)
                {
                    case "1":
                        while (true)
                        {
                        projectModule:
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("********************************************|    Project Module   |*****************************************************");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.Write("                                           Enter \"1\" to Add Project");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                                           Enter \"2\" to list all Projects");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                                           Enter \"3\" to list Project by Id");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                                           Enter \"4\" to list Project by name");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"5\" to add employee to project");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"6\" to remove employee from project");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"7\" to View projects with employees");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"8\" to delete a project");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"x\" to get to main menu");
                            var projectSelector = Console.ReadLine();
                            
                            
                            switch (projectSelector)
                            {
                                case "1":
                                    do
                                    {
                                        try
                                        {
                                        inputprojectid:
                                            Console.WriteLine("Enter Project Id");
                                            int projectid = Convert.ToInt32(Console.ReadLine());
                                            for (int i = 0; i < obj.projects.Count; i++)
                                            {
                                                if (obj.projects[i].id == projectid)
                                                {
                                                    Console.WriteLine("The id already exists try new id");
                                                    Console.WriteLine("Enter any key to try again");
                                                    Console.WriteLine("Enter \"x\" to get to main menu");
                                                    string idTry = Console.ReadLine();
                                                    if (idTry == "x")
                                                    {
                                                        goto projectModule;
                                                    }
                                                    else
                                                    {
                                                        goto inputprojectid;
                                                    }
                                                }
                                            }
                                            Console.WriteLine("Enter the name of project");
                                            string name = Console.ReadLine();
                                        StartDate:
                                            Console.WriteLine("Enter start date of project in DD/MM/YYYY format");
                                            string start = Console.ReadLine();
                                            if (!date.IsMatch(start))
                                            {
                                                Console.WriteLine("Invalid date format");
                                                Console.WriteLine("Enter any key to retry again");
                                                Console.WriteLine("Enter \"x\" to exit to main menu");
                                                var sDateread = Console.ReadLine();
                                                if (sDateread == "x")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    goto StartDate;
                                                }

                                            }
                                        EndDate:
                                            Console.WriteLine("Enter end date of project in DD/MM/YYYY format");
                                            string end = Console.ReadLine();
                                            if (!date.IsMatch(end))
                                            {
                                                Console.WriteLine("Invalid date format");
                                                Console.WriteLine("Enter any key to retry again");
                                                Console.WriteLine("Enter \"x\" to exit to main menu");
                                                var eDateread = Console.ReadLine();
                                                if (eDateread == "x")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    goto EndDate;
                                                }
                                            }
                                            Project project1 = new Project(name, start, end, projectid);
                                            obj.AddingProjects(project1);
                                            project = project1;
                                            Console.WriteLine("");
                                            Console.WriteLine("");
                                            Console.WriteLine("Added Successfully!");
                                            Console.WriteLine("");
                                            Console.WriteLine("Would to like to add employees to this project ?");
                                            Console.WriteLine("Enter \"Yes\"  to add or enter anything to deny");
                                            var addEmployeeOrNot = Console.ReadLine();
                                            if (addEmployeeOrNot == "Yes")
                                            {
                                                obj1.ShowEmployees();
                                                Console.WriteLine("Above are the available employees");
                                                Console.WriteLine("Enter the id of employee to add into project");
                                                int employeeIdSelect = Convert.ToInt32(Console.ReadLine());
                                                if (obj1.IfExists(employeeIdSelect))
                                                {
                                                    employee = obj1.EmployeeDetails(employeeIdSelect);
                                                    obj.AddingEmployeeToProject(projectid, employee);
                                                    Console.WriteLine("Added Successfully !");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Employee does not Exist");
                                                }

                                            }
                                            Console.WriteLine("Enter any key to get to main menu");
                                            Console.ReadLine();
                                        }

                                        catch (FormatException e)
                                        {
                                            Console.WriteLine("\nError : Only use numbers for id");
                                            Console.WriteLine("Enter any key to try again");
                                            Console.WriteLine("Enter \"x\" to get to main menu");

                                            read = Console.ReadLine();
                                            if (read == "x")
                                            {

                                                break;
                                            }
                                            error = true;
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("\nError : Only use numbers for id");
                                            Console.WriteLine("Enter any key to try again");
                                            Console.WriteLine("Enter \"x\" to get to main menu");

                                            read = Console.ReadLine();
                                            if (read == "x")
                                            {

                                                break;
                                            }
                                            error = true;
                                        }
                                    } while (error);
                                    break;

                                case "2":
                                    obj.DisplayAllProjects();
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;

                                case "3":
                                    try
                                    {
                                        Console.WriteLine("Search via project id");
                                        Console.WriteLine("Enter the id of project");
                                        int eid = Convert.ToInt32(Console.ReadLine());
                                        obj.ShowProject(eid);
                                        Console.WriteLine("Enter any key to get to main menu");
                                        Console.ReadLine();
                                    }
                                    catch (Exception e) { Console.WriteLine("Id can only be in numbers"); }
                                    break;

                                case "4":
                                    Console.WriteLine("Type to search for project");
                                    read = Console.ReadLine();
                                    obj.SearchProjectByName(read);
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    try
                                    {
                                        Console.WriteLine("");
                                        obj.DisplayAllProjects();
                                        Console.WriteLine("Above are the available projects");
                                        Console.WriteLine();
                                        obj1.ShowEmployees();
                                        Console.WriteLine("Above are the available employees");
                                        Console.WriteLine("Enter the Id of the project for which you want to add employees");
                                        int PROJId = Convert.ToInt32(Console.ReadLine());
                                        if (obj.IfExist(PROJId))
                                        {
                                            Console.WriteLine("Enter the id of employee to add into project");
                                            int employeeIdSelecting = Convert.ToInt32(Console.ReadLine());
                                            if (obj1.IfExists(employeeIdSelecting))
                                            {
                                                Employee employeeSelect = new Employee();
                                                employeeSelect = obj1.EmployeeDetails(employeeIdSelecting);
                                                if (!obj.IfExistInEmployee(employeeIdSelecting))
                                                {
                                                    obj.AddingEmployeeToProject(PROJId, employeeSelect);
                                                    Console.WriteLine("Added Successfully!!!!!!!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Employee already exists in this project");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Employee does not exist");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Project does not exist");
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid entry");
                                    }
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;

                                case "6":
                                    try
                                    {
                                        Console.WriteLine("Enter the Id of the project for which you want to delete employees");
                                        int PROJId1 = Convert.ToInt32(Console.ReadLine());
                                        if (obj.IfExist(PROJId1))
                                        {
                                            Console.WriteLine("Enter the id of employee to delete from project");
                                            int EmpId1 = Convert.ToInt32(Console.ReadLine());
                                            employee = obj1.EmployeeDetails(EmpId1);
                                            obj.EmployeeFromProject(PROJId1, employee);
                                            Console.WriteLine("\nSuccessfully deleted");

                                        }
                                        else
                                        {
                                            Console.WriteLine("The project do not IfExist");
                                        }
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("Id can only be integer");
                                    }
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;

                                case "7":
                                    Console.WriteLine("Enter the id of the project");
                                    int readForId = Convert.ToInt32(Console.ReadLine());
                                    if(obj.IfExist(readForId)){
                                    obj.DisplayEmployeesInProjectById(readForId);
                                    Console.WriteLine("-------------------------------------------------------------------------------------");
                                    }
                                    else{
                                        Console.WriteLine("No project present with that id");
                                    }
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;


                                case "8":
                                    Console.WriteLine("Enter the Id of the project to delete");
                                    int idforDeleting = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < obj.projects.Count; i++)
                                    {
                                        for (int j = 0; j < obj.projects[i].EmployeeListfromEmployeeManagement.Count; j++) {
                                            if (obj.projects[i].id == idforDeleting)
                                            {
                                                obj.EmployeeFromProject(idforDeleting, obj.projects[i].EmployeeListfromEmployeeManagement[j]);
                                            }
                                        }
                                        if (obj.projects[i].id == idforDeleting)
                                        {
                                            obj.DeleteProject(idforDeleting, obj.projects[i]);
                                        }
                                    }
                                    Console.WriteLine("");
                                    Console.WriteLine("Deleted Successfully !");
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;

                                case "x":
                                    goto View;
                                    break;

                                default:
                                    Console.WriteLine("");
                                    Console.WriteLine("Invalid input, please provide correct input");
                                    break;
                            }
                        }

                    case "2":
                        while (true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("********************************************|    Employee Module   |****************************************************");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.Write("                                           Enter \"1\" to Add Employee");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                                           Enter \"2\" to list all Employees");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"3\" to list Employees by Id");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"4\" to delete Employee");
                            Console.WriteLine("");
                            Console.WriteLine("                                           Enter \"x\" to get to main menu");
                            var employeeSelector = Console.ReadLine();
                            switch (employeeSelector)
                            {
                                case "1":

                                tryagain:
                                    try
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("");
                                    inputempid:
                                        Console.WriteLine("Enter the Id of employee");
                                        int empId = Convert.ToInt32(Console.ReadLine());
                                        for (int i = 0; i < obj1.employeeList.Count; i++)
                                        {
                                            if (empId == obj1.employeeList[i].employeeID)
                                            {
                                                Console.WriteLine("The id already exists try new id");
                                                Console.WriteLine("Enter any key to try again");
                                                Console.WriteLine("Enter \"x\" to get to main menu");
                                                string empidTry = Console.ReadLine();
                                                if (empidTry == "x")
                                                {
                                                    goto tryagain;
                                                }
                                                else
                                                {
                                                    goto inputempid;
                                                }
                                            }
                                        }
                                        Console.WriteLine("Enter employee first name");
                                        var fname = Console.ReadLine();
                                        Console.WriteLine("Enter employee last name");
                                        var lname = Console.ReadLine();
                                    Email:
                                        Console.WriteLine("Enter employee email id");
                                        var EMAIL = Console.ReadLine();
                                        if (!emailFormat.IsMatch(EMAIL))
                                        {
                                            Console.WriteLine("Invalid email format");
                                            Console.WriteLine("Enter any key to retry again");
                                            Console.WriteLine("Enter \"x\" to exit to main menu");
                                            var emailread = Console.ReadLine();
                                            if (emailread == "x")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                goto Email;
                                            }

                                        }
                                    mobile:
                                        Console.WriteLine("Enter employee mobile number");
                                        var mobile = Console.ReadLine();
                                        if (!phoneNumber.IsMatch(mobile))
                                        {
                                            Console.WriteLine("Invalid mobile number format");
                                            Console.WriteLine("Enter any key to retry again");
                                            Console.WriteLine("Enter \"x\" to exit to main menu");
                                            var mobread = Console.ReadLine();
                                            if (mobread == "x")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                goto mobile;
                                            }
                                        }

                                        Console.WriteLine("Enter address of the employee");
                                        var address = Console.ReadLine();
                                    Opt:
                                        Console.WriteLine("Select 1 for assinging employee with new role name and new role id");
                                        Console.WriteLine("Select 2 for assinging existing role to the employee");
                                        int selecting = Convert.ToInt32(Console.ReadLine());
                                        if (selecting == 1)
                                        {
                                            try
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine("");
                                            roleID:
                                                Console.WriteLine("Enter the Role Id");
                                                int roleID = Convert.ToInt32(Console.ReadLine());
                                                if (objmain.IfExists(roleID))
                                                {
                                                    Console.WriteLine(" Role with this id already exists");
                                                    Console.WriteLine("Enter any key to retry again");
                                                    Console.WriteLine("Enter \"x\" to exit to main menu");
                                                    var tryagain = Console.ReadLine();
                                                    if (tryagain == "x")
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        goto roleID;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Enter the name of Role");
                                                    string rolename = Console.ReadLine();
                                                    Console.WriteLine(rolename);
                                                    Role role1 = new Role(roleID, rolename);
                                                    objmain.RoleAdd(role1);
                                                    Employee employee1 = new Employee(empId, fname, lname, EMAIL, mobile, address, roleID, rolename);
                                                    obj1.AddEmployee(employee1);
                                                    employee = employee1;
                                                    Console.WriteLine("");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Added Successfully!");
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Role Id can only be in numbers");
                                            }
                                        }
                                        else if (selecting == 2)
                                        {
                                            try
                                            {
                                            Selectrole:
                                                objmain.DisplayRole();
                                                Console.WriteLine("Select Role id from above list to assign role to employee");
                                                int role1 = Convert.ToInt32(Console.ReadLine());
                                                string? roleNAME1 = null;
                                                switch (role1)
                                                {
                                                    case 1:
                                                        roleNAME1 = "Technical Lead";
                                                        break;
                                                    case 2:
                                                        roleNAME1 = "Software Engineer";
                                                        break;
                                                    case 3:
                                                        roleNAME1 = "Associate Software Engineer";
                                                        break;
                                                    case 4:
                                                        roleNAME1 = "Trainee Software Engineer";
                                                        break;
                                                    default:
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Invalid Entry !");
                                                        Console.WriteLine("");
                                                        Console.WriteLine("Enter any key to try again");
                                                        Console.WriteLine("Enter \"x\" to get to main menu");
                                                        string tryemprole = Console.ReadLine();
                                                        if (tryemprole == "x")
                                                        {
                                                            goto repeat;
                                                        }
                                                        else
                                                        {
                                                            goto Selectrole;
                                                        }
                                                }
                                                Employee employee1 = new Employee(empId, fname, lname, EMAIL, mobile, address, role1, roleNAME1);
                                                obj1.AddEmployee(employee1);
                                                employee = employee1;
                                                Console.WriteLine("");
                                                Console.WriteLine("");
                                                Console.WriteLine("Added Successfully!");
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Emp id can only be in numbers");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid entry");
                                            Console.WriteLine("Try again");
                                            goto Opt;
                                        }
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("Id can only be in numbers");
                                        Console.WriteLine("");
                                        Console.WriteLine("Enter any key to try again");
                                        Console.WriteLine("Enter \"x\" to get to main menu");
                                        string EmpIdTry = Console.ReadLine();
                                        if (EmpIdTry == "x")
                                        {
                                            goto breaking;
                                        }
                                        else
                                        {
                                            goto tryagain;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid Entry");
                                        Console.WriteLine("");
                                        Console.WriteLine("Enter any key to try again");
                                        Console.WriteLine("Enter \"x\" to get to main menu");
                                        string EmpIdTry1 = Console.ReadLine();
                                        if (EmpIdTry1 == "x")
                                        {
                                            goto breaking;
                                        }
                                        else
                                        {
                                            goto tryagain;
                                        }
                                    }

                                    Console.WriteLine("");
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                breaking:
                                    break;

                                case "2":
                                    obj1.ShowEmployees();
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;

                                case "3":
                                    try
                                    {
                                        Console.WriteLine("Enter the id of the employee");
                                        int searchEmployeeById = Convert.ToInt32(Console.ReadLine());
                                        obj1.ShowEmployee(searchEmployeeById);
                                        Console.WriteLine("Enter any key to get to main menu");
                                        Console.ReadLine();
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("Id can only be numbers");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                    break;

                                case "4":
                                    try
                                    {
                                        Console.WriteLine("Enter id of the employee ");
                                        int idForDeleting = Convert.ToInt32(Console.ReadLine());
                                        for (int i = 0; i < obj1.employeeList.Count; i++)
                                        {
                                            if (obj1.employeeList[i].employeeID == idForDeleting)
                                            {
                                                obj1.DeleteEmployee(idForDeleting, obj1.employeeList[i]);
                                                Console.WriteLine("");
                                                Console.WriteLine("Deleted Successfully !");
                                                Console.WriteLine("Enter any key to get to main menu");
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine("No employee found");
                                                Console.WriteLine("Enter any key to get to main menu");
                                                Console.ReadLine();
                                            }
                                        }
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("Enter valid input");
                                    }
                                    break;
                                case "x":
                                    goto View;
                                    break;

                                default:
                                    Console.WriteLine("");
                                    Console.WriteLine("Invalid input, please provide correct input");
                                    break;
                            }
                        }

                    case "3":
                        while (true)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("************************************************|    Role Module   |****************************************************");
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            Console.Write("                                                Enter \"1\" to Add Role");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.Write("                                                Enter \"2\" to list all Roles");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("                                                Enter \"3\" to list Roles by Id");
                            Console.WriteLine("");
                            Console.WriteLine("                                                Enter \"4\" to delete Role");
                            Console.WriteLine("");
                            Console.WriteLine("                                                Enter \"x\" to ");
                            Console.WriteLine("");
                            var roleSelector = Console.ReadLine();
                            switch (roleSelector)
                            {
                                case "1":
                                    try
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("");
                                    inputroleid:
                                        Console.WriteLine("Enter the Role Id");
                                        int roleIDD = Convert.ToInt32(Console.ReadLine());
                                        for (int i = 0; i < objmain.roleList.Count; i++)
                                        {
                                            if (roleIDD == objmain.roleList[i].roleId)
                                            {
                                                Console.WriteLine("The id already exists try new id");
                                                Console.WriteLine("Enter any key to try again");
                                                Console.WriteLine("Enter \"x\" to get to main menu");
                                                string roleidTry = Console.ReadLine();
                                                if (roleidTry == "x")
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    goto inputroleid;
                                                }
                                            }
                                        }
                                        Console.WriteLine("Enter the name of Role");
                                        string role_name = Console.ReadLine();
                                        Role newRole = new Role(roleIDD, role_name);
                                        objmain.RoleAdd(newRole);
                                        Console.WriteLine("");
                                        Console.WriteLine("");
                                        Console.WriteLine("Added Successfully!");


                                        Console.WriteLine("");
                                        Console.WriteLine("Enter any key to get to main menu");
                                        Console.ReadLine();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Role Id can only be in numbers");
                                        Console.ReadLine();
                                    }
                                    break;

                                case "2":
                                    objmain.DisplayRole();
                                    Console.WriteLine("Enter any key to get to main menu");
                                    Console.ReadLine();
                                    break;

                                case "3":
                                    try
                                    {
                                        Console.WriteLine("Enter the id of the role");
                                        int searchRoleById = Convert.ToInt32(Console.ReadLine());
                                        if (objmain.IfExists(searchRoleById))
                                        {
                                            objmain.ListRoleById(searchRoleById);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Id does not exists");
                                        }
                                        Console.WriteLine("Enter any key to get to main menu");
                                        Console.ReadLine();
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("Id can only be numbers");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                    break;

                                case "4":
                                    try
                                    {
                                        Console.WriteLine("Enter the id of the role");
                                        int deleteRoleById = Convert.ToInt32(Console.ReadLine());
                                        if (objmain.IfExists(deleteRoleById))
                                        {
                                            objmain.DeleteRole(deleteRoleById);
                                            Console.WriteLine("Successfully deleted !");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Id does not exists");
                                        }
                                        Console.WriteLine("Enter any key to get to main menu");
                                        Console.ReadLine();
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("Id can only be numbers");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Invalid input");
                                    }
                                    break;
                                case "x":
                                    goto View;
                                    break;

                                default:
                                    Console.WriteLine("Invalid entry");
                                    break;

                            }
                        }
                  case "x":
                  return;
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("******************************************|   Hello Prolifics employee   |**********************************************");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.Write("                                           Enter \"1\" to view Project Module");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("                                           Enter \"2\" to view Employee Module");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("                                           Enter \"3\" to view Role Module");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                                           Enter \"x\" to exit application");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                read = Console.ReadLine();
            }
        }
    }

}