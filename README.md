# Solicitor info
A small app that automates the extraction of solicitors contact details by location

## Requirements
* Demonstrate my skills by developing this as a .NET Core Web API & SPA pair
* Conveyancing Search Submission, scrape results from URL: https://www.solicitors.com/conveyancing.html
  - Locations List: London, Birmingham, Leeds, Manchester, Sheffield, Bradford, Liverpool, Bristol
  - Contact Details: We are looking for solicitor’s name, location, contact details, etc…
* Scrape the results page. Don't use 3rd party libraries, want to see how I structure my logic
* The UI must allow the user to adjust the locations list
* Come up with a standard report layout based on the data returned
* If a database is required use either: SQL Express or Postgres or an in-memory database

## Must include
* OO Programming & clean separation of concern – It must be engineered well in a repeatable / reusable way
* Can use JavaScript frameworks if there is time

## How to run the application
For the backend go to ~/SolicitorInfo/SolicitorInfo and run dotnet run.
For the frontend go to ~/SolicitorInfo/solicitor-ui$ and run npm start.
Both the back and frontend broswers should open. Go to the React frontend and choose from one of the cities in the dropdown. Then click Run scrape. You will see a list of results.