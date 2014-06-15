<?php

 $method = $_GET['requesttype'];
 
 try
 {
	$id = uniqid();
    $name = $_GET["devicename"];
	$starttime = $_GET["starttime"];
	$endtime = $_GET["endtime"];
	$active = $_GET["active"];
			
    $jsonModel = './model/schedule.json';
	
	$json = '';
	
    switch($method)
	{
	  case 'create':
	  
	     if (file_exists($file)) 
		 {
		    $fileContent = '';
		
		 	$json = $json.'"schedule"{';
			$json = $json.'"id":"'.uniqueid().'"';
			$json = $json.'"name":"'.$name.'"';
			$json = $json.'"starttime":"'.$starttime.'"';
			$json = $json.'"endtime":"'.$endtime.'"';
			$json = $json.'"active":"'.$active.'"';
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
		    throw new Exception('No data model exists for schedule!')
		 }
	  break;
	  
	  case 'update':
	    $id = $_GET['id'];
		
		$contentToUpdate = '';
		
		if (file_exists($file)) 
		{
		    $fileContent = '';
			
			$json = $json.'"schedule"{';
			$json = $json.'"id":"'.$id.'"';
			$json = $json.'"name":"'.$name.'"';
			$json = $json.'"starttime":"'.$starttime.'"';
			$json = $json.'"endtime":"'.$endtime.'"';
			$json = $json.'"active":"'.$active.'"';
			$json = $json.'}';
			
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			$jsonModel = json_decode($data);
			
			foreach($jsonModel->rows as $schedule)
			{ 
			  if($schedule->id == $id)
			  {
			    $contentToUpdate = $schedule->text;
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
		    throw new Exception('No data model exists for schedule!')
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
			
			foreach($jsonModel->rows as $schedule)
			{ 
			  if($schedule->id == $id)
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
		    throw new Exception('No data model exists for schedule!')
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
		    throw new Exception('No data model exists for schedule!')
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
			
			foreach($jsonModel->rows as $schedule)
			{ 
			  if($schedule->id == $id)
			  {
			    $contentToDisplay = $schedule->text;
				break;
			  }
			}
			
			echo $contentToDisplay;
		 }
		 else
		 {
		    throw new Exception('No data model exists for schedule!')
		 }
	  break;
	}
 }
 catch(Exception $e)
 {
   echo '{"status":"500","message":"Failed to execute "'.$method.'" for schedule service.See more info section for details.", "more info" :'.$e->getMessage().'"}';
 }
?>