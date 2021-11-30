# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id


6. Show listings that have not received a click in 2013
- Please return at least: listing_name


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names