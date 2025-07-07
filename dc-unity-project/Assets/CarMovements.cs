using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class CarMovements : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float movementSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float movementAmount = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        if (movementAmount != 0)
        {
            transform.Rotate(0, 0, -steerAmount);    
        }
        transform.Translate(0, movementAmount, 0);
        
    }
}
