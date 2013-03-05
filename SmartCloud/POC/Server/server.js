var http = require('http');
var util = require('util');
var url  = require('url');

var server = http.createServer(function(req, res) {
    /* Method 1*/
    if (req.url.indexOf('/POC/Demo') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;

	if(query.scheduleId != null)
	{
	  var scheduleId = query.scheduleId;

	  res.writeHead(200, {'content-type': 'text/plain'});

	  var cmd  = require('child_process').spawn('POC', ['SetSchedule', scheduleId]);
          cmd.stdout.on('data', function (data) 
	  {
             res.write(data);
	     res.end();
  	  });
	}
	else
	{
	  var id = GUID();
	  res.writeHead(200, {'content-type': 'text/plain'});
          var objToJson = { status: "200", identifier: id, exception: "no scheduleId parameter found!"};
	  res.write(JSON.stringify(objToJson));
	  res.end();
	}

      return;
    }
	
	 /* Method 2*/
    if (req.url.indexOf('/POC/SetSwitchMode') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;

	if(query.mode != null)
	{
	  var mode = query.mode;

	  res.writeHead(200, {'content-type': 'text/plain'});

	  var cmd  = require('child_process').spawn('POC', ['SetSwitchMode', mode]);
          cmd.stdout.on('data', function (data) 
	  {
             res.write(data);
	     res.end();
  	  });
	}
	else
	{
	  var id = GUID();
	  res.writeHead(200, {'content-type': 'text/plain'});
          var objToJson = { status: "200", identifier: id, exception: "no mode parameter found!"};
	  res.write(JSON.stringify(objToJson));
	  res.end();
	}

      return;
    }

   /* Handle unwanted requests */
   res.writeHead(200, {'content-type': 'text/plain'});
   var id = GUID();
   var objToJson = { status: "500", identifier: id, exception: "no processor or endpoint for request found!"};
   res.write(JSON.stringify(objToJson));
   res.end();
   
}).listen(9010);

console.log("server running on port 9010");



/* Utils */
function GUID ()
{
    var S4 = function ()
    {
        return Math.floor(
                Math.random() * 0x10000 /* 65536 */
            ).toString(16);
    };
    return (
            S4() + S4() + "-" +
            S4() + "-" +
            S4() + "-" +
            S4() + "-" +
            S4() + S4() + S4()
        );
}
