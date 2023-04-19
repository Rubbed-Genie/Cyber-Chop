var target : Transform; 
	
	
	function Update() {
		var relativePos = target.position - transform.position;
		var rotation = Quaternion.LookRotation(relativePos);
		transform.rotation = rotation;
	// if(Input.GetKeyDown("space"))
	//	{
	//	    transform.Translate (0,0,11);
	//	}
	}
	