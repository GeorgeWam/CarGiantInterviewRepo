# CarGiantInterviewRepo

**Execution Instructions and other details.** 
1)	A prerequisite for executing this test is that a user must have a login credential. These were created and are: 

Email Address: georgeiwoiltd@aol.com

Password: Testing123

The Specflow scenario for the username and password were not hardcoded. Therefore, if the current username and password changes in future for obvious reasons, all we will need to do is update the email and password field in the scenario and the test should execute as expected without changing any code. 

2)	The code for execution has been written to generate a report using extent report. (Report will be attached as an email and sent to everyone involved ie, interview stakeholders.)

3)	The code was written with a view of facilitating testing of other features of the web application. This can be noticed with the creation of a commonSteps class in the step definition folder, which can be shared by other features of the application, and thereby reducing code duplication and facilitating code maintenance. 

**Suggestions to improve the Framework.**

The framework has been currently built to add three items into the watch list, as well as deleting the first item on the watch list. This testing was to ensure that more than one item can be added to the watch list, as well as ensuring that an item can be deleted from the watch list. 
For a user to be able to repeat this test as often as possible without necessarily having to delete items in the watch list after each test runs, code has to be written with the use of a DatabaseHelper class **(we currently don't have access to Car Giant database and therefore can't write this code)**, where the system will automatically clear all data in the WishList table **pertaining to the specified user name**. The code will be written such that there is an interaction/communication between selenium and the database, where selenium will trigger the code, which will delete the existing data in the table, **pertaining to the specified user name**. This will automatically solve the issue of having to manually clear the WishList table after every code execution. It will also solve the issue of us ending up with so many items in a WishList table, if the test was meant to be executed a good number of times. 
