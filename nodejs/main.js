var http = require('http');
var url = require('url');

var rootUrl = "http://localhost:2323/"

function httpPost(postUrl, data) {
	return new Promise(function(resolve, reject) {
		var dataString = new Buffer(JSON.stringify(data), "utf-8");
		
		var options = {
		  hostname: url.parse(postUrl).hostname,
		  port: url.parse(postUrl).port,
		  path: url.parse(postUrl).path,
		  method: 'POST',
		  headers: {
			'Content-Type': 'application/json;charset=utf-8',
			'Content-Length': dataString.length
		  }
		};
		
		var req = http.request(options, (res) => {
		  res.setEncoding('utf8');

		  var resData = "";
		  
		  res.on('data', (chunk) => {
			resData += chunk.toString();
		  });
		  res.on('end', () => {
			  if(res.statusCode != 200) {
				  reject(resData);
			  }
			  else {
				  var obj = null;
			  
				  try {
					  obj = JSON.parse(resData);
				  }
				  catch(err) {
					  reject(err);
				  }
				  
				  resolve(obj);
			  }
		  });
		});

		req.on('error', (e) => {
		  reject(e);
		});

		req.write(dataString);
		req.end();
	});
}

function createNewInvoice() {
	var data = {
		"items": [{
			"name": "Produkt 1",
			"description": "Meine Beschreibung",
			"netprice": 20,
			"vatcode": "A",
			"quantity": 2
		}],
		"customer": {
			"salution": "Mister",
			"name": "Müller",
			"firstname": "Max",
			"street": "Straße 12",
			"zip": "8150",
			"city": "Graz"
		},
		"annotation": "Meine Anmerkung auf dieser Rechnung",
		"internal_note": "Meine interne Notiz zu dieser Rechnung",
		"discount": 20.0
	};
	
	var requestUrl = rootUrl + "api/create?action=print";

	return httpPost(requestUrl, data);
}
function cancelInvoice(id) {
	var data = {
		"id": id,
		"reason": "Meine Begründung",
		"internal_note": "Meine interne Notiz",
		"print": true,
		"printer": "default"
	};
	
	var requestUrl = rootUrl + "api/cancel";

	return httpPost(requestUrl, data);
}


createNewInvoice()
	.then(function(res) {
		console.log("invoice created", res);
		
		return cancelInvoice(res.data.id);
	})
	.then(function(res) {
		console.log("invoice canceled", res);
	})
	.catch(function(err) {
		console.log("error", err);
	});
