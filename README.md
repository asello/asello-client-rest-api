# asello-client-rest-api-csharp

The asello win application (https://asello.at/apps) provides a simple rest api to control the main features of the asello application.

[definition]: https://github.com/asello/asello-client-rest-api/blob/master/asello%20ClientAPI%20Rest.png?raw=true "Logo"

## create an invoice

Method: HTTP-POST
URL: http://localhost:2323/api/create?action=print
Body: data as json

**URL-Parameters:**

Name|Type|Example|
---|---|---|
action|```String("print", "overview", "options", "preview")```|```"print"```|

**Request Body**

Content-Type: application/json

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

Name|Type|Example|
---|---|---|
items (required)|```Array<Item>```||
items[0].name (required)|```String```|```"Position 1"```|
items[0].description|```String```|```"Beschreibung"```|
items[0].netprice (required)|```Number```|```20.0"```|
items[0].vatcode (required)|```String("A", "B", "C", "D", "E")```|```A```|
items[0].quantity (required)|```Number```|```2```|
items[0].articlenumber|```String```|```"ART00001"```|
customer|```Object```||
customer.salutation|```String("Mister", "Muss", "Company")```|```"Mister"```|
customer.name|```String```|```"Mustermann"```|
customer.firstname|```String```|```"Max"```|
customer.attention|```String```|```"z.H. Frau Müller"```|
customer.street|```String```|```"Straße 12"```|
customer.zip|```String```|```"1234"```|
customer.city|```String```|```"Musterstadt"```|
customer.customerid|```String```|```"KN000001"```|
annotation|```String```|```"Meine Anmerkung"```|
internal_note|```String```|```"Interne Notiz"```|
discount|```Number```|```20.0```|

**Note:** If an articlennumber is specified, the other properties are ignored expect for quantity.

**Note:** If an customerid is specified, the other properties will be ignored. 

**Note:** attention and uid are only available if salutation = 'Comany'



**Response status codes**

Code|Body Content|
---|---|
200 - OK|content see below|
400 - Bad Request|error message|
500 - Internal Server Error|error message|

**Response Body**

Content-Type: application/json

```javascript
{
    id: 1234,
    number: ’R0000001’,
    status: ’created’
}
```

Name|Type|Example|
---|---|---|
id|```Number (long)```|```1234```|
number|```String```|```"R0000001"```|
status|```String("created", "canceled")```|```"created"```|

##cancel invoice

Method: HTTP-POST
URL: http://localhost:2323/api/cancel
Body: data as json

**Request Body**

Content-Type: application/json

```javascript
{
    "id": 1234,
    "reason": "Meine Begründung",
    "internal_note": "Meine interne Notiz",
    "print": true,
    "printer": ""
}
```

Name|Type|Example|
---|---|---|
id (required)|```Number (long)```|```1234```|
reason|```String```|```"Meine Begründung"```|
internal_note|```String```|```"Meine interne Notiz"```|
print|```Boolean```|```true```|
printer|```String```|```Canon XXXXX```|

**Note:** internal_note or reason is required

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

Name|Type|Example|
---|---|---|
id|```Number (long)```|```1235```|
number|```String```|```"R00002"```|
status|```String("created", "canceled"```|```"created```|

**Note:** the result contains the number of the cancelation invoice
