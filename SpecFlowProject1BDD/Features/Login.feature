Feature: Login

@functional
Scenario: Login with valid credentials
	Given launch the browser "chrome"
	And   navigate to the given url "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login"
	When  enter valid "Admin" and "admin123"
	And   click on the login button
	Then  user should be in the userdashboard