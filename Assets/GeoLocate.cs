using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoLocate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector2 CartesianToPolar(Vector3 point)
	{
		Vector2 polar;

		//calc longitude
		polar.y = Mathf.Atan2(point.x,point.z);

		//this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
		//float xzLen = Vector2 (point.x, point.z).magnitude;

		Vector2 vec2 = Vector2(point.x, point.z);
		float xzLen = vec2.magnitude;

		//atan2 does the magic
		polar.x = Mathf.Atan2(-point.y, xzLen);

		//convert to deg
		polar *= Mathf.Rad2Deg;

		return polar;
	}


//	Vector3 PolarToCartesian(Vector2 polar)
	void PolarToCartesian(Vector2 polar)
	{

		//an origin vector, representing lat,lon of 0,0. 

		Vector3 origin=Vector3(0,0,1);

		//build a quaternion using euler angles for lat,lon
		Quaternion rotation = Quaternion.Euler(polar.x,polar.y,0);

		//transform our reference vector by the rotation. Easy-peasy!
		Vector3 point = rotation * origin;

		Debug.Log ("Point = " + point);
		Instantiate (gameObject, point);
		//return point;
	}
}
