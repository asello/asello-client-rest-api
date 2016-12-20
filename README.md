# asello-client-rest-api-csharp

The asello win application (https://asello.at/apps) provides a simple rest api to control the main features of asello.

## create a invoice

Method: HTTP-POST
URL: http://localhost:2323/api/create?action=print
Body: data as json

**URL-Parameters:**

Name|Type|Example|
---|---|---|
action|```String("print", "overview", "options", "preview")```|```"print"```|

**Request Body**

```javascript
{
    "items": [{
        "name": "Produkt 1",
        "description": "Meine Beschreibung",
        "netprice": 20,
        "vatcode": "A",
        "quantity": 2,
        "articlenumber": "ART00001"
    }],
    "customer": {
        "salution": "Mister",
        "name": "Müller",
        "firstname": "Max",
        "street": "Straße 12",
        "zip": "8150",
        "city": "Graz",
        "customerid": "KN000001"
    },
    "annotation": "Meine Anmerkung auf dieser Rechnung",
    "internal_note": "Meine interne Notiz zu dieser Rechnung",
    "discount": 20.0
}
```

**Response status codes*

Code|Body Content|
---|---|
200 - OK|conent see below|
400 - Bad Request|error message|
500 - Internal Server Error|error message|

**Response Body**

```javascript
{
    id: 1234,
    number: ’R0000001’,
    status: ’created’
}
```

##cancel invoice

Method: HTTP-POST
URL: http://localhost:2323/api/cancel
Body: data as json

**Request Body**

```javascript
{
    "id": 1234,
    "reason": "Meine Begründung",
    "internal_note": "Meine interne Notiz",
    "print": true,
    "printer": ""
}
```

**Response status codes*

Code|Body Content|
---|---|
200 - OK|conent see below|
400 - Bad Request|error message|
500 - Internal Server Error|error message|

**Response Body**

```javascript
{
    id: 1234,
    number: ’R0000001’,
    status: ’created’
}
```
