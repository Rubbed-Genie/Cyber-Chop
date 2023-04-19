var target : Transform; //the enemy's target
var moveSpeed = 3; //move speed
var rotationSpeed = 3; //speed of turning
var myTransform : Transform; //current transform data of this enemy


//var hasCollided : boolean = false;
//var labelText : String = "";
//var activated : boolean = false;
 
function Awake()
{
    myTransform = transform; //cache transform data for easy access/preformance
}

//function OnGUI()
//{
//	if (hasCollided ==true)
//	{  
//		GUI.Box(Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
//	}
//}

function Start()
{
     target = GameObject.FindWithTag("Target").transform; //target the player
 
}

//function OnTriggerEnter(other : Collider)
//{
//	if(other.gameObject.tag =="Player")
//	{
//		hasCollided = true;
//		labelText = "Press E Activate";
//	}
//}

//function OnTriggerStay()
//{
//	if(Input.GetKeyDown( KeyCode.E ))
//	{
//		activated = true;
//	}
//} 

//function OnTriggerExit(other : Collider )
//{
//    hasCollided = false;
 
//}

function Update ()
{
   // if (activated == true)
   // {
    //rotate to look at the player
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
 
    //move towards the player
    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
 
 //	}
}