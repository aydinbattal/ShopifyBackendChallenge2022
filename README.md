# ShopifyBackendChallenge2022
An inventory tracking web application for a logistics company.

## Technologies
* C#
* ASP.NET
* Entity Framework
* Sqlite
* VSCode
* Postman
* Git

## Setting Up
1. Download .NET 5.0 SDK: https://dotnet.microsoft.com/en-us/download/dotnet
2. Download VSCode: https://code.visualstudio.com/download
3. Download Git: https://git-scm.com/download
4. Open a new terminal and get into the folder you want to clone the repository to using "cd" command
5. Use "git clone https://github.com/aydinbattal/ShopifyBackendChallenge2022.git" command to clone the repository
6. Make sure you are inside the project folder then run "dotnet run -p .\Api\" command

## API Endpoints
These endpoints can be tested using Postman (https://www.postman.com/downloads/)

### ItemsController
#### Create inventory item

URL:

POST - http://localhost:5000/api/items/ 

Header Key: Content-Type

Header Value: application/json

Body:
```json
{
    "name": "Pixel 6 Pro",
    "amount": 18,
    "inventories": [
        {
            "name": "Google Phones"
        }
    ]
}
```

Example Output:

![image](https://user-images.githubusercontent.com/59744728/150261273-0b1d23de-6232-4b8e-aee6-cc8978d836e3.png)

#### Delete inventory item

URL:

DELETE - http://localhost:5000/api/items/{id} 

Example URL:

DELETE - http://localhost:5000/api/items/E22473AA-98D8-44A7-8B10-45177B7E3095

Example Output:

![image](https://user-images.githubusercontent.com/59744728/150261486-fd676d1c-84e1-469e-9737-574fc1068a24.png)

#### View a list of inventory items

URL:

GET - http://localhost:5000/api/items

Example Output:

![image](https://user-images.githubusercontent.com/59744728/150261816-02bfa77d-8ce7-40bc-a001-9f0731199c9d.png)
![image](https://user-images.githubusercontent.com/59744728/150261849-331f9dda-50ed-47b2-bd1a-daf98ec15f86.png)

#### Edit inventory item

URL:

PUT - http://localhost:5000/api/items/{id}

Example URL:

PUT - http://localhost:5000/api/items/E22473AA-98D8-44A7-8B10-45177B7E3095

Header Key: Content-Type

Header Value: application/json

Body:
```json
{
    "amount": 3
}
```

Example Output:

![image](https://user-images.githubusercontent.com/59744728/150261637-29099d20-bdc8-46c5-845c-da55b18455e4.png)

### LocationsController
#### Create warehouse/location and assign inventory to it

URL: 

POST - http://localhost:5000/api/locations/

Body:
```json
{
    "name": "Hamilton",
    "address": "12 Frost St",
    "inventories": [
        {
            "name": "iPhones"
        }
    ]
}
```

Example Output:

![image](https://user-images.githubusercontent.com/59744728/150262060-9f8b33f6-554c-49f9-9725-f35919200621.png)

