<?php

 $method = $_GET['requesttype'];
 
 try
 {
	$id = uniqid();
    $name = $_GET["devicename"];
	$switch = $_GET["switch"];
	$unit = $_GET["unitid"];
			
    $jsonModel = './model/device.json';
	
	$json = '';
	
    switch($method)
	{
	  case 'create':
	  
	     if (file_exists($file)) 
		 {
		    $fileContent = '';
			
		 	$json = $json.'"device"{';
			$json = $json.'"id":"'.uniqueid().'"';
			$json = $json.'"unitid:"'.$unit.'"';
			$json = $json.'"name":"'.$name.'"';
			$json = $json.'"switch":"'.$switch.'"';
			$json = $json.'}';
			
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			if($data.length > 0)
			{
			  $fileContent = $data.'\r\n'.$json;
			}
			else
			{
			 $fileContent = $json;
			}
			
			file_put_contents($file, $fileContent);
			
			echo '{"status":"200","message":'.$method.'" successfull!"}';
		 }
		 else
		 {
		    throw new Exception('No data model exists for device!')
		 }
	  break;
	  
	  case 'update':
	    $id = $_GET['id'];
		$contentToUpdate = '';
		
		if (file_exists($file)) 
		{
		    $fileContent = '';
			
			$json = $json.'"device"{';
			$json = $json.'"id":"'.$id().'"';
			$json = $json.'"unitid:"'.$unit.'"';
			$json = $json.'"name":"'.$name.'"';
			$json = $json.'"switch":"'.$switch.'"';
			$json = $json.'}';
			
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			$jsonModel = json_decode($data);
			
			foreach($jsonModel->rows as $device)
			{ 
			  if($device->id == $id)
			  {
			    $contentToUpdate = $device->text;
				break;
			  }
			}
			
			if($contentToRemove != '')
			{
			  $data = str_replace($contentToRemove,$data,$json);
			  
			  file_put_contents($file, $fileContent);
			}
			
			echo '{"status":"200","message":'.$method.'" successfull!"}';
		 }
		 else
		 {
		    throw new Exception('No data model exists for device!')
		 }
	  break;
	  
	  case 'delete':
	    $id = $_GET['id'];
		$contentToRemove = '';
		
		if (file_exists($file)) 
		{
		    $fileContent = '';
			
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			$jsonModel = json_decode($data);
			
			foreach($jsonModel->rows as $device)
			{ 
			  if($device->id == $id)
			  {
			    $contentToRemove = $device->text;
				break;
			  }
			}
			
			if($contentToRemove != '')
			{
			  $data = str_replace($contentToRemove,$data,'');
			  
			  file_put_contents($file, $fileContent);
			}
			
			echo '{"status":"200","message":'.$method.'" successfull!"}';
		 }
		 else
		 {
		    throw new Exception('No data model exists for units!')
		 }
	  break;
	  
	  case 'list':
	     if (file_exists($file)) 
	     {
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			echo $data;
		 }
		 else
		 {
		    throw new Exception('No data model exists for device!')
		 }
	  break;
	  
	  case 'get':
	    $id = $_GET['id'];
		$contentToDisplay = '';
		
		if (file_exists($file)) 
		{
		    $fileContent = '';
			
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			$jsonModel = json_decode($data);
			
			foreach($jsonModel->rows as $device)
			{ 
			  if($device->id == $id)
			  {
			    $contentToDisplay = $device->text;
				break;
			  }
			}
			
			echo $contentToDisplay;
		 }
		 else
		 {
		    throw new Exception('No data model exists for device!')
		 }
	  break;
	}
 }
 catch(Exception $e)
 {
   echo '{"status":"500","message":"Failed to execute "'.$method.'" for device service.See more info section for details.", "more info" :'.$e->getMessage().'"}';
 }
?>