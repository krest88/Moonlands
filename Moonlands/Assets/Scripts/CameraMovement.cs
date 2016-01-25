using UnityEngine;
using System.Collections;
using System.Security.Policy;
using UnityEngineInternal;

public class CameraMovement : MonoBehaviour {

    public float CamSpeed = 1;
    public float GUISize = 25;
    public Vector3 DeltaHeight = new Vector3(0, 1.5f, 0);
    private Rect recdown;
    private Rect recup;
    private Rect recleft;
    private Rect recright;
    private bool isPressed;
    private Vector3 CurrentPosition;

	void Start () {
        recdown = new Rect(0, 0, Screen.width, GUISize);
        recup = new Rect(0, Screen.height - GUISize, Screen.width, GUISize);
        recleft = new Rect(0, 0, GUISize, Screen.height);
        recright = new Rect(Screen.width - GUISize, 0, GUISize, Screen.height);
	    CurrentPosition = transform.position;
	}

    void Update()
    {
        Movements();
    }

    private void Movements()
    {
        MoveForward();
        MoveBackward();
        MoveLeft();
        MoveRight();
        MoveHeight();
        MoveWithHoldMouseButton();
    }

    private void MoveForward()
    {
        if (recup.Contains(Input.mousePosition))
            transform.Translate(0, 0, CamSpeed, Space.World);
    }

    private void MoveBackward()
    {
        if (recdown.Contains(Input.mousePosition))
            transform.Translate(0, 0, -CamSpeed, Space.World);
    }

    private void MoveLeft()
    {
        if (recleft.Contains(Input.mousePosition))
            transform.Translate(-CamSpeed, 0, 0, Space.World);
    }

    private void MoveRight()
    {
        if (recright.Contains(Input.mousePosition))
            transform.Translate(CamSpeed, 0, 0, Space.World);
    }

    private void MoveHeight()
    {
        transform.Translate(Input.GetAxis("Mouse ScrollWheel") * DeltaHeight);
    }

    private void SetPressedRightButton()
    {
        if (Input.GetMouseButtonDown(1))
            isPressed = true;
        if (Input.GetMouseButtonUp(1))
            isPressed = false;
    }

    private void MoveWithHoldMouseButton()
    {
        SetPressedRightButton();
        if (isPressed)
        {
            transform.Translate(Vector3.right * Input.GetAxis("Mouse X") * CamSpeed);
            transform.Translate(Vector3.forward * Input.GetAxis("Mouse Y") * CamSpeed);
        }
        CurrentPosition = transform.position;
    }
}
