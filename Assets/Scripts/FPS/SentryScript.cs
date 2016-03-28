using UnityEngine;
using System.Collections;

public class SentryScript : MonoBehaviour {
	//public Transform Target;	
	//public float smooth = 2.0f;
	//public float tiltAngle = 30.0f;

	/*

	public Transform bulletSpawn;
	public Transform turretTop;
	public Transform Turret;
	public GameObject bullet;

	public float reloadTime = 1f;
	public float firePauseTime = .25f;

	private float nextFireTime;
	private float nextMoveTime;
	private Quaternion desiredRotation;


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Check");
			Target = other.gameObject.transform;
			nextFireTime = Time.deltaTime + (reloadTime * 0.75f);

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == Target) {
			Target = null;
		}
	}

	void CalculateAimPosition(Vector3 targetpos)
	{
		Vector3 aimPoint = new Vector3 (targetpos.x, targetpos.y, targetpos.z);
		desiredRotation = Quaternion.LookRotation (aimPoint);
	}

	void FireProjectile()
	{
		nextFireTime = Time.time + reloadTime;
		nextMoveTime = Time.time + firePauseTime;

		Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
	}
		
	void Update()
	{
		//transform.LookAt (Target);
		if (Target != null) {
		
			if (Time.time >= nextMoveTime) {
				CalculateAimPosition (Target.position);
			}

			if (Time.time >= nextFireTime) {
				FireProjectile ();
			}
		}
	}
*/
	/*void Update()
	{
		//transform.LookAt (Target);
		//transform.Rotate (0, 0, Time.deltaTime*5);

		//Vector3 relativePos = Target.position - transform.position;
		//Quaternion rotation = Quaternion.LookRotation (relativePos);
		//transform.rotation = rotation;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("Check");
			Target = other.gameObject.transform;

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.transform == Target) {
			Target = null;
		}
	}
	*/


}
