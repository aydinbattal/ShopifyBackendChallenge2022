# ShopifyBackendChallenge2022

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
###### Create inventory item

URL:

POST - http://localhost:5000/api/items/ 

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

###### Delete inventory item

URL:

DELETE - http://localhost:5000/api/items/{id} 

###### View a list of inventory items

URL:

GET - http://localhost:5000/api/items

###### Edit inventory item

URL:

PUT - http://localhost:5000/api/items/{id}

Body:
```json
{
    "amount": 3
}
```

### LocationsController
###### Create warehouse/location and assign inventory to it

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


