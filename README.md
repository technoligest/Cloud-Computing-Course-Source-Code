README
Team Project - Workflow Coordination with Security Features

Brandon Lange - B00688070
Sarah Redmond - B00636646
Yaser Alkayale - B00

RUNNING THE APPLICATION
------------------------------------------------------------------------------------------------------------------------------------------

Go to main URL: https://projectfrontend.azurewebsites.net/. This opens a page where the different portals can be accessed, such as the Employer, Martgage Broker, and Real Estate Company.

Navigate to the Employer page and click the "Create employee" button in the top-right corner, which will navigate to a new form. Fill in all of the fields and click "Create Employee". A success message will be displayed if all fields were filled in with valid information.

Full in the field at the top of the page with the Employee ID and click "Sign In". This will navigate to a page with all the employee's information, as well as a field for Broker ID. To obtain the Broker ID, press the back button to go back to the portal navigation page.

Enter the Mortgage Broker's portal. This will open a Mortagage Application form. Fill in the fields with valid values, including a new Multiple Listings Service ID, and click the "Submit Application" button.

A message will appear at the top of the screen displaying a Mortgage ID and a message stating that more information is needed. Copy this ID number and keep it on hand.

Click on the "Check Application" tab on this page. Enter the copied Mortage ID to check the status of the application (which, at this point, is not completed). Return to this page at any point to check is the application is completed. 

Press back to return to the portal navication page. Return to the Employer page and sign in with the Employee ID. Enter the copied Mortage Broker ID into the appropriate field, and click "I Agree" to submit information to the Mortgage Broker. A success message will be displayed at the top of the screen.

Press back to return to the portal navigation page. Enter the Real Estate Company's page which will open a form to apply for an appraisal. Fill in the fields with the copied Mortage ID, as well as the Multiple Listings Service ID that was chosen earlier. Click the "Submit" button, and a success message will be displayed.

NOTE: It is possible to Apply for the appraisal before submitting the Broker ID on the Employer page. In this example the Employer page was completed first.

Press back to return to the portal navigation page. Enter the Mortgage Broker portal and click the "Check Application" tab. Enter the Application ID, and a success message is displayed.


TESTING THE APPLICATION
------------------------------------------------------------------------------------------------------------------------------------------

To test the application, enter valid and invalid values for the required fields, or do not enter anything. All valid values will result in success messages while invalid values will not. Run through all of the above steps to fully test the application.
