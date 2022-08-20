using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform outLocation;

	private bool colliding = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (colliding)
		{
			Vector3 playerDiff = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, playerDiff);
			if (dotProduct < 0f)
			{
				float rotationDiff = -Quaternion.Angle(transform.rotation, outLocation.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);
				Vector3 offset = Quaternion.Euler(0f, rotationDiff, 0f) * playerDiff;
				player.position = outLocation.position + offset;

                colliding = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") colliding = true;
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") colliding = false;
	}
}
