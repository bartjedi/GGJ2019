using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField]
    private int horizontalSpeed, jumpSpeed;
    [SerializeField]
    private string horizontalInputAxis, verticalInputAxis;
    [SerializeField]
    private int joystickNumber;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis(horizontalInputAxis);
        float yAxis = Input.GetAxis(verticalInputAxis);
        Vector3 movement = new Vector3(0, yAxis, 0f);
        rb.position += movement * horizontalSpeed * Time.deltaTime;


        switch(joystickNumber)
        {
            case 1:
                if (Input.GetKeyDown("joystick 1 button 0"))
                {
                    buttonAPress();
                }
                if (Input.GetKeyDown("joystick 1 button 1"))
                {
                    buttonBPress();
                }
                break;
            case 2:
                if (Input.GetKeyDown("joystick 2 button 0"))
                {
                    buttonAPress();
                }
                if (Input.GetKeyDown("joystick 2 button 1"))
                {
                    buttonBPress();
                }
                break;
            case 3:
                if (Input.GetKeyDown("joystick 3 button 0"))
                {
                    buttonAPress();
                }
                if (Input.GetKeyDown("joystick 3 button 1"))
                {
                    buttonBPress();
                }
                break;
            case 4:
                if (Input.GetKeyDown("joystick 4 button 0"))
                {
                    buttonAPress();
                }
                if (Input.GetKeyDown("joystick 4 button 1"))
                {
                    buttonBPress();
                }
                break;
        }
    }

    private void buttonAPress()
    {
        rb.position += new Vector3(0, 2f, 0f);
    }

    private void buttonBPress()
    {
        rb.position += new Vector3(0, 2f, 0f);
    }
}
