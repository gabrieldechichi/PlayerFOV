using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor {

	void OnSceneGUI()
	{
		FieldOfView FOV = (FieldOfView)target;
		Handles.color = Color.white;
		Handles.DrawWireArc(FOV.transform.position, Vector3.up, Vector3.forward, 360f, FOV.viewRadius);

		//Draw the view lines
		Vector3 viewAngleA = FOV.DirFromAngle(-FOV.viewAngle/2,false);
		Vector3 viewAngleB = FOV.DirFromAngle(FOV.viewAngle/2,false);

		Handles.DrawLine(FOV.transform.position,FOV.transform.position + viewAngleA*FOV.viewRadius);
		Handles.DrawLine(FOV.transform.position,FOV.transform.position + viewAngleB*FOV.viewRadius);

		//Draw line to each visible target
		Handles.color = Color.red;
		foreach(Transform visibleTarget in FOV.visibleTargets)
			Handles.DrawLine(FOV.transform.position,visibleTarget.position);
	}
}
