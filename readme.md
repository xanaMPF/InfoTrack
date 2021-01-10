# Scraper

Simple scraper to retrieve the keyword rankings for a specific URL in several search engines. Supports storing and displaying historical data.

## Getting Started

Run the .sql script to generate your database. Please note that some mock data is included to more easily test the historical data (keyword: 'land registry search' and url: 'www.infotrack.co.uk'). You might need to change the path for Microsoft SQL Server to your installation.
The project includes two components:
.Net Backend
Vue Frontend
Both are included in the solution.

### Prerequisites

Visual Studio 2019
SQLExpress
Node.js

## Running the tests

Some sample unit tests are included, please run the tests using the Visual Studio interface.

## Authors

* **Alexandra Familiar** 

## Improvements

# Code
    - different handling of error responses from the search engines (for instance, captcha) 
    - the html sample in tests could be a global resource loaded by the test
    - more unit tests to conver the database interactions and retrival of data
	
# Functionality
    - support to add more search engines by the user (the architecture is ready to support this)
    - graph of the historical data
    - show the matching URLs in the ranking results
    - store and display previously used keyword and URLs
    - develop a queue system connected to a cron job to auto retrive the rankings for certain keyword/url pairs with a certain frequency
		
	
	
