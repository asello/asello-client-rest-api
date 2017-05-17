The asello win application (https://release.asello.at/) provides a simple rest api to control the main features of the asello application. The api is an alternative to the asello-client-api (https://github.com/asello/asello-client-api) witch is available in the browser for webapplications. 

![definition](https://github.com/asello/asello-client-rest-api/blob/master/asello%20ClientAPI%20Rest.png?raw=true)

# Create

Method: HTTP-POST
URL: http://localhost:2323/api/create?action=print
Body: data as json

**URL-Parameters:**

Name|Type|Example|
---|---|---|
action|```String("print", "overview", "options", "preview")```|```"print"```|

**Request Body**

Content-Type: application/json
Content-Description: https://github.com/asello/asello-client-api/wiki/create-invoice-object-definition

**Response status codes**

Code|Body Content|
---|---|
200 - OK|content see below|
400 - Bad Request|error message|
500 - Internal Server Error|error message|

**Response Body**

Content-Type: application/json
Content-Description: https://github.com/asello/asello-client-api/wiki/invoice-object-definition

#cancel

Method: HTTP-POST
URL: http://localhost:2323/api/cancel
Body: data as json

**Request Body**

Content-Type: application/json
Content-Description: https://github.com/asello/asello-client-api/wiki/cancel-object-definition

**Response status codes*

Code|Body Content|
---|---|
200 - OK|conent see below|
400 - Bad Request|error message|
500 - Internal Server Error|error message|

**Response Body**

Content-Type: application/json
Content-Description: https://github.com/asello/asello-client-api/wiki/cancel-object-definition
