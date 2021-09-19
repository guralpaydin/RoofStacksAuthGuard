using Employee.Entities;
using Employee.Model;
using Employee.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EmployeeTest.ServiceTest
{
    public class EmployeeServiceTest
    {
        private readonly Mock<IEmployeeService> employeeService;
        public EmployeeServiceTest()
        {
            employeeService = new Mock<IEmployeeService>();
        }

        [Fact]
        public void Employee_GetEmployees_ShouldReturnEmployees()
        {
            ///Arrange
            List<EmployeeEntity> expectedValue = new List<EmployeeEntity>();
            employeeService.Setup(e => e.GetEmployees()).Returns(expectedValue);

            ///Act
            var result = employeeService.Object.GetEmployees();

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Employee_GetEmployee_ShouldReturnEmployee()
        {
            ///Arrange
            EmployeeEntity employee = new EmployeeEntity();
            EmployeeResponse expectedValue = new EmployeeResponse(employee);
            employeeService.Setup(e => e.GetEmployee(1)).Returns(expectedValue);

            ///Act
            var result = employeeService.Object.GetEmployee(1);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Employee_GetEmployee_ShouldReturnNull()
        {
            ///Arrange
            EmployeeResponse expectedValue = null;
            employeeService.Setup(e => e.GetEmployee(0)).Returns(expectedValue);

            ///Act
            var result = employeeService.Object.GetEmployee(0);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Employee_Create_ShouldReturnNewEmployee()
        {
            ///Arrange
            EmployeeEntity employee = new EmployeeEntity();
            EmployeeResponse expectedValue = new EmployeeResponse(employee);
            EmployeeRequest request = new EmployeeRequest();
            employeeService.Setup(e => e.CreateEmployee(request)).Returns(expectedValue);

            ///Act
            var result = employeeService.Object.CreateEmployee(request);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Employee_Update_ShouldReturnUpdatedEmployee()
        {
            ///Arrange
            EmployeeEntity employee = new EmployeeEntity();
            EmployeeResponse expectedValue = new EmployeeResponse(employee);
            EmployeeUpdateRequest request = new EmployeeUpdateRequest();
            employeeService.Setup(e => e.UpdateEmployee(1,request)).Returns(expectedValue);

            ///Act
            var result = employeeService.Object.UpdateEmployee(1,request);

            ///Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void Employee_Update_ShouldReturnNull()
        {
            ///Arrange
            EmployeeResponse expectedValue = null;
            EmployeeUpdateRequest request = new EmployeeUpdateRequest();
            employeeService.Setup(e => e.UpdateEmployee(0, request)).Returns(expectedValue);

            ///Act
            var result = employeeService.Object.UpdateEmployee(0, request);

            ///Assert
            Assert.Equal(expectedValue, result);
        }
    }
}
