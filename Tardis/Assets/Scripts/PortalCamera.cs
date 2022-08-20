using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform mainCamera;
	public Transform thisPortal;
	public Transform destinationPortal;
	
	void LateUpdate () {
		Vector3 playerOffsetFromPortal = mainCamera.position - destinationPortal.position;
		transform.position = thisPortal.position + playerOffsetFromPortal;
		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(thisPortal.rotation, destinationPortal.rotation);
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * mainCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
