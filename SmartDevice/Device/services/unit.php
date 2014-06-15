<?php

 $method = $_GET['requesttype'];
 
 try
 {
	$id = uniqid();
    $unitname = $_GET["unitname"];
	$address = $_GET["address"];
	$dateadded = getdate();
			
    $jsonModel = './model/unit.json';
	
	$json = '';
	
    switch($method)
	{
	  case 'create':
	  
	     if (file_exists($file)) 
		 {
		    $fileContent = '';
			
		 	$json = $json.'"unit"{';
			$json = $json.'"id":"'.uniqueid().'"';
			$json = $json.'"name":"'.$unitname.'"';
			$json = $json.'"dateadded":"'.$dateadded.'"';
			$json = $json.'"address":"'.$address.'"';
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
		    throw new Exception('No data model exists for units!')
		 }
	  break;
	  
	  case 'update':
	    $id = $_GET['id'];
		$contentToUpdate = '';
		
		if (file_exists($file)) 
		{
		    $fileContent = '';
			
			$json = $json.'"unit"{';
			$json = $json.'"id":"'.$id.'"';
			$json = $json.'"name":"'.$unitname.'"';
			$json = $json.'"dateadded":"'.$dateadded.'"';
			$json = $json.'"address":"'.$address.'"';
			$json = $json.'}';
			
		    $data = file_get_contents($jsonModel, FILE_USE_INCLUDE_PATH);
			
			$jsonModel = json_decode($data);
			
			foreach($jsonModel->rows as $unit)
			{ 
			  if($unit->id == $id)
			  {
			    $contentToUpdate = $unit->text;
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
		    throw new Exception('No data model exists for units!')
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
			
			foreach($jsonModel->rows as $unit)
			{ 
			  if($unit->id == $id)
			  {
			    $contentToRemove = $unit->text;
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
		    throw new Exception('No data model exists for units!')
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
			
			foreach($jsonModel->rows as $unit)
			{ 
			  if($unit->id == $id)
			  {
			    $contentToDisplay = $unit->text;
				break;
			  }
			}
			
			echo $contentToDisplay;
		 }
		 else
		 {
		    throw new Exception('No data model exists for units!')
		 }
	  break;
	}
 }
 catch(Exception $e)
 {
   echo '{"status":"500","message":"Failed to execute "'.$method.'" for device service.See more info section for details.", "more info" :'.$e->getMessage().'"}';
 }
?>