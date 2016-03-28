#pragma strict

// Variable for the 
var myProjectile : GameObject;
// Variable setting the reload time of the turret
var reloadTime : float = 1;
// Variable setting the turret turn speed
var turnSpeed : float = 5;
// Variable setting the time inbewteen reloading and firing
var firePauseTime : float = .25;
// Variable for the Enemies
var myTarget : Transform;
// Variable for the muzzle position of turret, where projectiles are forced from
var muzzlePositions : Transform[];
// Variable for the direction the turret is facing
// mainly so that it faces towards enemies
var turretBall : Transform;

// Variable for when the turret is to fire next
private var nextFireTime : float;
// Variable for when the turret is to move next
private var nextMoveTime : float;
// Variable for what roation is needed to face a target
private var desiredRotation : Quaternion;


function Update () 
{
	// Checks if there is an Enemy present
	if(myTarget)
	{
		// If there is, it's checked if the turret can move to look at Enemy
		if(Time.time >= nextMoveTime)
		{
			//If it can, it looks towards Enemy
			CalculateAimPosition(myTarget.position);
			turretBall.rotation = Quaternion.Lerp(turretBall.rotation,desiredRotation,Time.deltaTime*turnSpeed);
		}
		
		// If there is, it's checked if the turret can fire at the enemy
		if(Time.time >= nextFireTime)
		{
			// If it can, it will fire at the enemy
			FireProjectile();
		}
	}
}

// Called when an object enters turret collider
function OnTriggerEnter(other : Collider)
{
	// Checks if the colliding object is tagged as Enemy
	if(other.gameObject.tag == "Player")
	{
		// If it is, it will be aimed and fired at
		nextFireTime = Time.time+(reloadTime*.5);
		myTarget = other.gameObject.transform;
		transform.LookAt(myTarget);
		Debug.Log("What?");
	}
}

// Called when an object exits the turret collider
function OnTriggerExit(other : Collider)
{
	// Checks if the leaving object is tagged Enemy
	if(other.gameObject.transform == myTarget)
	{
		// If it is, it cannot be shot at anymore
		myTarget = null;
	}
}

// Called to calculate where to aim
function CalculateAimPosition(targetPos : Vector3)
{
	var aimPoint = Vector3(targetPos.x, targetPos.z);
//	var aimPoint = Vector3(targetPos.z);
	desiredRotation = Quaternion.LookRotation(myTarget.position-turretBall.position);
}

// Called to fire a Projectile at Enemies
function FireProjectile()
{
	// Calculate when to next fire
	nextFireTime = Time.time + reloadTime;
	// Calculates when next to move your aim
	nextMoveTime = Time.time + firePauseTime;

	for(theMuzzlePos in muzzlePositions) //for each
	{
		Instantiate(myProjectile, theMuzzlePos.position, theMuzzlePos.rotation);
	}
}
