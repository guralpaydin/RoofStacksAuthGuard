# RoofStacksAuthGuard

**Default Client Information:**
Id = 1, Name = "DefaultClient", UserName = "ClientName", Password = "ClientPassword", ClientSecret = "client_1 icin secret degeri default olarak verildi" 

### Success Authenticate
![AuthenticateSuccess](https://github.com/guralpaydin/RoofStacksAuthGuard/blob/master/ScreenShots/Authenticate.PNG)
### Fail Authenticate
![AuthenticateFail](https://github.com/guralpaydin/RoofStacksAuthGuard/blob/master/ScreenShots/AuthenticateFail.PNG)
### Success GetEmployee
![GetEmployeeSuccess](https://github.com/guralpaydin/RoofStacksAuthGuard/blob/master/ScreenShots/GetEmployeesSuccess.PNG)
### Fail Authenticate
![GetEmployeesUnAuthorized](https://github.com/guralpaydin/RoofStacksAuthGuard/blob/master/ScreenShots/GetEmployeesUnAuthorized.PNG)

### Employee Api Methods
**Employee/CreateEmployee** ==> Needs EmployeeRequest (Name,LastName,Address,Department,Phone all fields required)<br/>
**Employee/GetEmployee/{id}**<br/>
**Employee/GetEmployees**<br/>
**Employee/UpdateEmployee/{id}** ==> Need EmployeeUpdateRequest(Name,LastName,Address,Department,Phone)<br/>

### AuthGuard Api Methods
**Authenticate** ==> Needs AuthenticateRequest (UserName,Password,ClientSecret all fields required) <br/>
**RefreshToken** <br/>
**ValidateToken** ==> Needs ValidateTokenRequest (ClientId,Token all fields required) <br/>
