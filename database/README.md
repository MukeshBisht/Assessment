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
 ``` SQL
 SELECT id,
        first_name, 
        last_name, 
        email, 
        `status`, 
        created 
 FROM	users
 WHERE	id IN (3, 2, 4);
 ```

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
 ``` SQL
SELECT  u.first_name, 
        u.last_name, 
        SUM(l.status = 2) as basic, 
        SUM(l.status = 3) premium
FROM users u
INNER JOIN listings l
On u.id = l.user_id
GROUP BY u.id;
 ```

3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium
```SQL
SELECT	u.first_name, 
		    u.last_name, 
        SUM(l.status = 2) as basic, 
        SUM(l.status = 3) premium
FROM users u
INNER JOIN listings l
On u.id = l.user_id
GROUP BY u.id
having premium > 0;
```

4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue



5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
```SQL
INSERT INTO 
clicks (listing_id, 
        price, 
        currency) 
VALUES (3, 
        4, 
        'USD');
SELECT @@identity as id;
```

6. Show listings that have not received a click in 2013
- Please return at least: listing_name
```SQL
SELECT	lst.name 
FROM	listings lst 
WHERE	lst.id NOT IN (
            SELECT	DISTINCT lst.id
            FROM	listings lst
            JOIN	clicks clk
            ON		lst.id = clk.listing_id
            AND		YEAR(clk.created) = 2013
		);
```

7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
```SQL
SELECT		usr.first_name, 
			    usr.last_name, 
        	GROUP_CONCAT(lst.name) as listing_names
FROM		  users usr
JOIN 		  listings lst
ON 			  usr.id = lst.user_id
GROUP BY	lst.user_id;
```
