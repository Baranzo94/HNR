#pragma strict

// Variable for the projectile speed to travel at
var mySpeed : float = 10;
// Variable for the projectile range before expiring
var myRange : float = 10;
// Variable for the projectile damage
public var damage : float = 1.0f;
// Variable to help calculate projectile position
private var myDist : float;


function Update () 
{
	// This is calculating the position of all the projectiles
	// Should a projectile go further than the myRange variable allows
	// then it is destroyed
	transform.Translate(Vector3.right *Time.deltaTime * mySpeed);
	myDist += Time.deltaTime * mySpeed;
	if(myDist >= myRange)
		Destroy(gameObject);	
}

// This is called when an Enemy gameobject collides with a Projectile
function OnTriggerEnter(other:Collider)
{
	if(other.gameObject.tag == "Enemy")
		{
		Destroy(transform.root.gameObject);
		Destroy(gameObject);
		}
}