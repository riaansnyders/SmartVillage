/*
   SmartCloud Server Version 1.0.0
*/

var http = require('http');
var util = require('util');
var url  = require('url');

var server = http.createServer(function(req, res) {
    /* Notifications */
    if (req.url.indexOf('/smartpower/smartcloud/notifications') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['Notification', loadId, token]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Security - Login */
    if (req.url.indexOf('/smartpower/smartcloud/security/login') > -1)
    {
     var url_parts = url.parse(req.url, true);
     var query = url_parts.query;
	 
	 var loadId = query.loadid;  
	 var token = query.token;

	 if(token != null)
	 {
	    res.writeHead(200, {'content-type': 'text/plain'});
		
		var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['Login', loadId, token]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['CreateSchedule', loadId, token,query.name,query.startDateTime,query.endDateTime]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - Edit */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/edit') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['EditSchedule', loadId, token,query.id,query.name,query.startDateTime,query.endDateTime]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['DeleteSchedule', loadId, token,query.id]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['EnableSchedule', loadId, token,query.id]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['DisableSchedule', loadId, token,query.id]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Schedule - List */
    if (req.url.indexOf('/smartpower/smartcloud/schedule/list') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['ListSchedule', loadId, token]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['CreatePriority', loadId, token,query.scheduleId,query.name]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['DeletePriority', loadId, token,query.id]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Priority - List */
    if (req.url.indexOf('/smartpower/smartcloud/priority/list') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['ListPriority', loadId, token]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['CreateZone', loadId, token,query.name,query.serial]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['EditZone', loadId, token,query.id,query.name]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['DeleteZone', loadId, token,query.id]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['SetZoneState', loadId, token, query.id,query.state,query.serial]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Zone - List */
    if (req.url.indexOf('/smartpower/smartcloud/zone/list') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['ListZone', loadId, token]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['CreateSwitch', loadId, token,query.deviceId,query.name,query.deviceSwitch]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['EditSwitch', loadId, token,query.id,query.deviceId,query.name]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['DeleteSwitch', loadId, token,query.id]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['SetSwitchState', loadId, token,query.id,query.state]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Switch - List */
    if (req.url.indexOf('/smartpower/smartcloud/switch/list') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['ListDevice', loadId, token]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['CreateDevice', loadId, token, query.zoneid, query.name,query.address]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['EditDevice', loadId, token,query.id,query.zoneid,query.name,query.address]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['DeleteDevice', loadId, token,query.id]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['SetDeviceState', loadId, token,query.id,query.state,query.serial]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['LinkDevice', loadId, token,query.id,query.scheduleid]);
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
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['UnlinkDevice', loadId, token,query.id,query.scheduleid]);
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
       var objToJson = { status: "200", identifier: id, exception: "Security token invalid or empty!"};
	   res.write(JSON.stringify(objToJson));
	   res.end();
	 }
      return;
    }
	
	/* Device - List */
    if (req.url.indexOf('/smartpower/smartcloud/device/list') > -1)
    {
       var url_parts = url.parse(req.url, true);
       var query = url_parts.query;
	   
	   var loadId = query.loadid;  
	   var token = query.token;

	  if(token != null)
	  {
	      res.writeHead(200, {'content-type': 'text/plain'});
		  
		  var cmd  = require('child_process').spawn('C:\\Smartpower\\smartcloud\\Adapter.exe', ['ListDevice', loadId, token, query.zoneid]);
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
