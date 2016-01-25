using UnityEngine;
using System.Collections;

public class MousePoint : MonoBehaviour
{
    public Vector3 Point;
    private RaycastHit hit;

	void Start () {
	
	}
	
	void FixedUpdate ()
	{
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    if (Physics.Raycast(ray, out hit, 1000))
	        Point = hit.point;
        //Debug.DrawRay(ray.origin, ray.direction*1000, Color.yellow);
	}

    public Vector3 GetPoint()
    {
        return Point;
    }

    public string GetColliderObjectName()
    {
        return hit.collider.name;
    }
}
