# ExpenseTrackerApp
Expense tracker is a personal expense management web application created using asp.net mvc architecture and api. This web application enables the user to add the category, daily expenses and set limit for those expenses. Also includes dashboard. The application contains Home, Category, Expense, Limit. It has a animated sidebar. The Category, Expense and limit contains list, form to add or edit and a button to delete which alerts the user before deletion. Also the alerts are shown while inserting, updating or deleting. Ease of navigation as breadcrumbs are used.

The application is developed in Visual Studio 2022. HTML, CSS, javaScript, alertifyJs(package for alert), Jquery(for date picker) are used.

Pre requisites of Expense tracker web application are

Visual studio 2022
Make sure you have got the right version i.e, .Net Framework 4.7.2
Entity framework 6.0
How to run the application: Since the application is built using Web Api and asp.net mvc The solution contains two projects one for web api and one for asp.net mvc. Firstly, download the solution and database. Make sure you keep the database name same as that mentioned in the models of the projects both mvc and api. Since entity framework version 6.0 is used.

The project is built following the "DB first approach".

After adding the db to the api project .edmx file will be generated.

Now, after following the steps you are good to go.

Build the project using Ctrl+Shift+B. Now your project is built. In order to run the project on the browser press Ctrl+F5 key .

Now you will be having two screens one for the api and another for the expense tracker application.

This one is the api 
![Screenshot (728)](https://user-images.githubusercontent.com/80202363/212370655-edd29056-b98c-4824-915c-037e49aab756.png)

Application
Dashboard
![Screenshot (723)](https://user-images.githubusercontent.com/80202363/212370862-cc728216-2401-4ca8-8c6c-1637ae697684.png)

Category Panel
![Screenshot (724)](https://user-images.githubusercontent.com/80202363/212370944-77fc2417-280f-4251-924d-e24e67f17322.png)
![Screenshot (725)](https://user-images.githubusercontent.com/80202363/212370949-3176d359-bbc1-4611-b723-dd4009216a8b.png)

Expense Panel
![Screenshot (727)](https://user-images.githubusercontent.com/80202363/212371388-06fc7e35-a938-4cb1-b6c9-71d8520b6fe0.png)
![Screenshot (729)](https://user-images.githubusercontent.com/80202363/212371357-00b5d9e5-fc26-436a-ab65-765493c8ffa5.png)

Limit Panel
![Screenshot (730)](https://user-images.githubusercontent.com/80202363/212371206-300be31e-0000-47c0-9697-46aae9c621db.png)
![Screenshot (731)](https://user-images.githubusercontent.com/80202363/212371122-542fcf7a-19ea-4a7e-bfa9-a5624d5cdbe9.png)
