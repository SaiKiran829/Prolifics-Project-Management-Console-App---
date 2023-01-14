using DOMAIN;
using FluentAssertions;
using MODEL;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestingAddproject()
        {
            List<Project> fortesting = new List<Project>();
            Project projectTest = new Project("sai", "02/06/2022", "02/06/2023", 2);
            fortesting.Add(projectTest);
            ProjectManagement tests = new ProjectManagement();
            Project objectTest = new Project("sai", "02/06/2022", "02/06/2023", 2);
            tests.AddingProjects(objectTest);
            for (int i = 0; i < tests.projects.Count; i++)
            {
                for (int j = 0; j < fortesting.Count; j++)
                {
                    fortesting[j].Should().BeEquivalentTo(tests.projects[i]);
                }
            }
        }

        [Test]
        public void Test()
        {
            List<Project> fortesting = new List<Project>();
            Project projectproject = new Project("sai", "02/06/2022", "02/06/2023", 2);
            fortesting.Add(projectproject);
            ProjectManagement tests = new ProjectManagement();
            Project objector = new Project("sai", "02/06/2022", "02/06/2023", 2);
            tests.AddingProjects(objector);
            for (int i = 0; i < tests.projects.Count; i++)
            {
                Assert.That(tests.projects[i].id, Is.EqualTo(2));
                Assert.That(tests.projects[i].projectName, Is.EqualTo("sai"));
                Assert.That(tests.projects[i].startDate, Is.EqualTo("02/06/2022"));
            }
        }

        [Test]

        public void Test2(){
            List<Employee> testingList = new List<Employee>();
            Employee employee = new Employee(1, "sai", "kiran", "sai@gmail.com", "9182234756", "home", 1, "software Engineer");
            testingList.Add(employee);
            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.AddEmployee(employee);
            for(int i=0;i<employeeManagement.employeeList.Count;i++){
                for(int j=0;j<testingList.Count;j++){
                    testingList[j].Should().BeEquivalentTo(employeeManagement.employeeList[i]);
                }
            }
        }

        [Test]
        public void Test3(){
            List<Role> testingRole = new List<Role>();
            Role role = new Role(1, "karthik");
            testingRole.Add(role);
            RoleManagement roleManagement = new RoleManagement();
            roleManagement.RoleAdd(role);
            for(int i =0;i<roleManagement.roleList.Count;i++){
                for(int j=0;j<testingRole.Count;j++){
                    testingRole[j].Should().BeEquivalentTo(roleManagement.roleList[i]);
                }
            }
        }

        [Test]
        public void Test4(){
            Role role = new Role(1, "karthik");
            RoleManagement roleManagement = new RoleManagement();
            roleManagement.RoleAdd(role);
                Assert.True(roleManagement.IfExists(1));
            }
        

        [Test]
        public void Test5(){
            EmployeeManagement employeeManagement = new EmployeeManagement();
            Employee addingEmployee = new Employee(1,"sai","kiran","sai@gmail.com","9182234756","Home",1,"player");
            employeeManagement.AddEmployee(addingEmployee);
            Assert.True(employeeManagement.IfExists(1));
            Assert.False(employeeManagement.IfExists(2));
        }

        [Test]
        public void Test6(){
            ProjectManagement projectManagement = new ProjectManagement();
            Project project = new Project("sai", "02/06/2022", "02/06/2023", 2);
            projectManagement.AddingProjects(project);
            Assert.True(projectManagement.IfExist(2));
        }

        /*[Test]
        public void Test7()
        {
            ProjectManagement projectManagement = new ProjectManagement();
            Project project = new Project("kiran", "02/06/2025", "02/06/2026", 12);
            projectManagement.AddingProjects(project);
            EmployeeManagement employeeManagement = new EmployeeManagement();
            Employee employee = new Employee(1, "sai", "kiran", "sai@gmail.com", "9182234756", "Home", 1, "player");
            employeeManagement.AddEmployee(employee);
            Employee employeeinlist = new Employee();
            employeeinlist = employeeManagement.EmployeeDetails(1);
            projectManagement.AddingEmployeeToProject(12, employeeinlist);
            Assert.True(projectManagement.IfExistInEmployee(1));
        }*/
    }
  }