using System;

namespace MODEL
{

    //project class
    public class Project :  IComparable<Project>
    {
        public string projectName { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int id { get; set; }
        public List<Employee> EmployeeListfromEmployeeManagement { get; set; } = new List<Employee>();

        public int employeeId;

        public Project(string projectname, string startdate, string enddate, int Id)
        {
            this.projectName = projectname;
            this.startDate = startdate;
            this.endDate = enddate;
            this.id = Id;
        }


        public Project(int empidd)
        {
            this.employeeId = empidd;
        }
        public Project()
        {

        }

        public int CompareTo(Project other)
        {
            return this.id.CompareTo(other.id);
        }

    }

    //Employee class
    public class Employee : IComparable<Employee>
    {
        public int employeeID { get; set; }

        public string employeefirstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }


        public Employee(int empid, string FirstName, string LastName, string Email, string Mobile, string Address, int ROleID, string ROlename)
        {
            this.employeeID = empid;
            this.employeefirstName = FirstName;
            this.lastName = LastName;
            this.email = Email;
            this.mobile = Mobile;
            this.address = Address;
            this.roleId = ROleID;
            this.roleName = ROlename;
        }

        public Employee()
        {

        }

        public int CompareTo(Employee other)
        {
            return this.roleId.CompareTo(other.roleId);
        }

    }
    //Role class
    public class Role : IComparable<Role>
    {
        public string roleName { get; set; }
        public int roleId { get; set; }

        public Role(int roleid, string roleName)
        {
            this.roleName = roleName;
            roleId = roleid;
        }

        public Role()
        {

        }

        public int CompareTo(Role other)
        {
            return this.roleId.CompareTo(other.roleId);
        }
    }

    public class SortEmployeeById : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.employeeID.CompareTo(y.employeeID);
        }
    }

}