var http = require('http');
var util = require('util');
var url  = require('url');

var server = http.createServer(function(req, res) {
    /* Notifications */
    if (req.url.indexOf('/smartpower/smartcloud/notifications') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var token = query.token;

	  if(token != null)
	 {
	  /* Keep as sample for processing */
	  //var scheduleId = query.scheduleId;

	  //res.writeHead(200, {'content-type': 'text/plain'});

	  //var cmd  = require('child_process').spawn('POC', ['SetSchedule', scheduleId]);
          //cmd.stdout.on('data', function (data) 
	  //{
             //res.write(data);
	     //res.end();
  	  //});
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Users - Create */
    if (req.url.indexOf('/smartpower/smartcloud/users/create') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Users - Edit */
    if (req.url.indexOf('/smartpower/smartcloud/users/edit') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Users - Delete */
    if (req.url.indexOf('/smartpower/smartcloud/users/delete') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Users - List */
    if (req.url.indexOf('/smartpower/smartcloud/users/list') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - login */
    if (req.url.indexOf('/smartpower/smartcloud/security/login') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - logout */
    if (req.url.indexOf('/smartpower/smartcloud/security/logout') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - AssignRole */
    if (req.url.indexOf('/smartpower/smartcloud/security/assignrole') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - ListRoles */
    if (req.url.indexOf('/smartpower/smartcloud/security/listroles') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - RemoveRole */
    if (req.url.indexOf('/smartpower/smartcloud/security/removerole') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - CreateRole */
    if (req.url.indexOf('/smartpower/smartcloud/security/createrole') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - EditRole */
    if (req.url.indexOf('/smartpower/smartcloud/security/editrole') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - DeleteRole */
    if (req.url.indexOf('/smartpower/smartcloud/security/deleterole') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - Create */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/create') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - edit */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/edit') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - Delete */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/delete') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - Enable */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/enable') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - Disable */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/disable') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Priority - Create */
    if (req.url.indexOf('/smartpower/smartcloud/priority/create') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Priority - Edit */
    if (req.url.indexOf('/smartpower/smartcloud/priority/edit') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Priority - Delete */
    if (req.url.indexOf('/smartpower/smartcloud/priority/delete') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Priority - Link */
    if (req.url.indexOf('/smartpower/smartcloud/priority/link') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Priority - Unlink */
    if (req.url.indexOf('/smartpower/smartcloud/priority/unlink') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Zone - Create */
    if (req.url.indexOf('/smartpower/smartcloud/zone/create') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }

	/* Zone - Edit */
    if (req.url.indexOf('/smartpower/smartcloud/zone/edit') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Zone - Delete */
    if (req.url.indexOf('/smartpower/smartcloud/zone/delete') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Zone - State */
    if (req.url.indexOf('/smartpower/smartcloud/zone/state') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Switch - Create */
    if (req.url.indexOf('/smartpower/smartcloud/switch/create') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Switch - Edit */
    if (req.url.indexOf('/smartpower/smartcloud/switch/edit') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Switch - Delete */
    if (req.url.indexOf('/smartpower/smartcloud/switch/delete') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Switch - State */
    if (req.url.indexOf('/smartpower/smartcloud/switch/state') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - Create */
    if (req.url.indexOf('/smartpower/smartcloud/device/create') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - Edit */
    if (req.url.indexOf('/smartpower/smartcloud/device/edit') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - Delete */
    if (req.url.indexOf('/smartpower/smartcloud/device/delete') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - State */
    if (req.url.indexOf('/smartpower/smartcloud/device/state') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - Link */
    if (req.url.indexOf('/smartpower/smartcloud/device/link') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - Unlink */
    if (req.url.indexOf('/smartpower/smartcloud/device/unlink') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	   
	 var token = query.token;

	 if(token != null)
	 {
	  
	 }
	 else
	 {
	   var id = GUID();
	   res.writeHead(200, {'content-type': 'text/plain'});
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
   /* Standard exception handler. Do not remove */ 
   /* Handle unwanted requests */
   res.writeHead(200, {'content-type': 'text/plain'});
   var id = GUID();
   var objToJson = { status: "500", identifier: id, exception: "No processor or endpoint for request found!"};
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
