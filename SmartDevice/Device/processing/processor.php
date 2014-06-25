<?php

 try
 {		
    $stateArray = new Array(8,8);
	
    $statesList = '';
	$jsonUnit = './model/schedule.json';
    $jsonSchedules = './model/schedule.json';
	$jsonScheduleDevices = './model/scheduledevice.json';
	$jsonDevices  = './model/scheduledevice.json';
	
	$data = file_get_contents($jsonSchedules, FILE_USE_INCLUDE_PATH);
	
	$unitJSON = json_decode($data);
	$address = $unitJSON ->address;
	
	$data = file_get_contents($jsonSchedules, FILE_USE_INCLUDE_PATH);
	
	$scheduleJSON = json_decode($data);
			
	foreach($scheduleJSON->rows as $schedule)
	{ 
	  $currentTime = date('H:i');
	  $scheduleId = $schedule->id;
	  
	  if($currentTime >= $schedule->starttime && $currentTime < $schedule->endtime)
	  {
		 $data = file_get_contents($jsonScheduleDevices, FILE_USE_INCLUDE_PATH);
		 
		 $scheduleDeviceJSON = json_decode($data);
		 
		 foreach($scheduleDeviceJSON->rows as $scheduleDevice)
		 { 
		    if($scheduleDevice->scheduleid == $scheduleId)
			{
			   $deviceId = $scheduleDevice->deviceid;
			   $deviceState = $scheduleDevice->state;
			   
			   $data = file_get_contents($jsonDevices, FILE_USE_INCLUDE_PATH);
		 
			   $deviceJSON = json_decode($data);
			   
			   foreach($deviceJSON->rows as $device)
			   { 
			     if($device->id == $deviceId)
				 {
				    $switch = $device->switch;
					
					if($switch == 'switch1')
					{
					   $switchArray[0] = $switch;
					   $switchArray[0][0] = $deviceState;
					}
					
					if($switch == 'switch2')
					{
					   $switchArray[1] = $switch;
					   $switchArray[1][1] = $deviceState;
					}
					
					if($switch == 'switch3')
					{
					   $switchArray[2] = $switch;
					   $switchArray[2][2] = $deviceState;
					}
					
					if($switch == 'switch4')
					{
					   $switchArray[3] = $switch;
					   $switchArray[3][3] = $deviceState;
					}
					
					if($switch == 'switch5')
					{
					   $switchArray[4] = $switch;
					   $switchArray[4][4] = $deviceState;
					}
					
					if($switch == 'switch6')
					{
					   $switchArray[5] = $switch;
					   $switchArray[5][5] = $deviceState;
					}
					
					if($switch == 'switch7')
					{
					   $switchArray[6] = $switch;
					   $switchArray[6][6] = $deviceState;
					}
					
					if($switch == 'switch8')
					{
					   $switchArray[7] = $switch;
					   $switchArray[7][7] = $deviceState;
					}
				  }
			   }
			}
		 }
		 
		 $switchList .= $switchArray[0][0].','
		 $switchList .= $switchArray[1][1].','
		 $switchList .= $switchArray[2][2].','
		 $switchList .= $switchArray[3][3].','
		 $switchList .= $switchArray[4][4].','
		 $switchList .= $switchArray[5][5].','
		 $switchList .= $switchArray[6][6].','
		 $switchList .= $switchArray[7][7]
		 
		 $serviceURL = './services/brava.php?address='.$address.'&states='.$switchList;
		 
		 header('Location:'.$serviceURL);
		 die();
	  }
	}
 }
 catch(Exception $e)
 {
   throw $e;
 }
?>