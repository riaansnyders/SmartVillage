<?php
  $host = $_GET["address"];
  $switchStates = $_GET["states"];
  
  $port = '9000';
  $timeout = 30;  //timeout in seconds
  
  $switchOn = '0x02';
  $switchOff = '0x03';
  
  try
  {
    $socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP)
      or die("Unable to create socket\n");

    socket_set_nonblock($socket)
      or die("Unable to set nonblock on socket\n");

    $time = time();
	
    while (!@socket_connect($socket, $host, $port))
    {
      $err = socket_last_error($socket);
	  
      if ($err == 115 || $err == 114)
      {
        if ((time() - $time) >= $timeout)
        {
          socket_close($socket);
          die("Connection timed out.\n");
        }
        sleep(1);
        continue;
      }
      die(socket_strerror($err) . "\n");
    }
	
    socket_set_block($this->socket)
      or die("Unable to set block on socket\n");
	 
	$switch = explode(",",$switchStates);
	
	$message = str_repeat(chr(4),8);
	
	for ($i = 0; $i <= 8; $i++) 
	{
		if($switch[$i] == 'on')
		{
		  $message.= $switchOn;
		}
		else
		{
		   $message.= $switchOff;
		}
	}
	
	if(!socket_send ($sock , $message , strlen($message) , 0))
	{
		$errorcode = socket_last_error();
		$errormsg = socket_strerror($errorcode);
		
		die("Could not send data: [$errorcode] $errormsg \n");
	}

	if(socket_recv ($sock , $buf , 2045 , MSG_WAITALL ) === FALSE)
	{
		$errorcode = socket_last_error();
		$errormsg = socket_strerror($errorcode);
		
		die("Could not receive data: [$errorcode] $errormsg \n");
	}

	socket_close($socket);
	
	echo '{"status":"200","message":"Switch commands executed with success!"}';
  }
  catch(Exception $e)
  {
    echo '{"status":"500","message":"Failed to execute device switch state command.See more info section for details.", "more info" :'.$e->getMessage().'"}';
  }
?>