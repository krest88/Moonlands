using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour
{

    public GameObject ClonedObject;
    private GameObject _house;
    private bool isPressed = true;
    private MousePoint _mousePoint;

	void Start () {
        _mousePoint = GameObject.Find("World").GetComponent<MousePoint>();
	}
	
	void Update () {        
        if (_house != null)
        {
            _house.transform.position = GetVector(_mousePoint.GetPoint());
        }
	}

    public void GetBuilding()
    {
        if (isPressed)
        {
            _house = (GameObject)Instantiate(ClonedObject, GameObject.Find("World").GetComponent<MousePoint>().GetPoint(), Quaternion.identity);
        }
        else
            Destroy(_house);
        isPressed = !isPressed;
    }

    public void Build()
    {
        if (!isPressed)
        {
            _house.transform.position = GetVector(_mousePoint.GetPoint());
            isPressed = !isPressed;
        }
    }

    private Vector3 GetVector(Vector3 vector)
    {
        Vector3 temp = vector;
        temp.y += _house.GetComponent<Renderer>().bounds.size.y / 2;
        return temp;
    }
}
