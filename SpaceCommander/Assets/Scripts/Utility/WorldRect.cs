using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WorldRect : MonoBehaviour
{
    [SerializeField]
    bool showBorder = false;
    [Header("This will clamp given positions within the rect")]
    [SerializeField]
    bool closeBorder = false;
    [Header("This wil invert the given positions to canvas")]
    [SerializeField]
    bool invertPosData = false;
    [SerializeField]
    private float width;
    [SerializeField]
    private float height;

    private void Update()
    {
        //if showBorder is true draw the border lines
        if (showBorder)
        {
            DrawRect();
        }
    }

    //just draws the lines to show it visualy for easier use
    private void DrawRect()
    {
        Debug.DrawLine(new Vector3(transform.position.x - width / 2, transform.position.y, transform.position.z - height / 2), new Vector3(transform.position.x - width / 2, transform.position.y, transform.position.z + height / 2));
        Debug.DrawLine(new Vector3(transform.position.x + width / 2, transform.position.y, transform.position.z - height / 2), new Vector3(transform.position.x + width / 2, transform.position.y, transform.position.z + height / 2));
        Debug.DrawLine(new Vector3(transform.position.x - width / 2, transform.position.y, transform.position.z + height / 2), new Vector3(transform.position.x + width / 2, transform.position.y, transform.position.z + height / 2));
        Debug.DrawLine(new Vector3(transform.position.x - width / 2, transform.position.y, transform.position.z - height / 2), new Vector3(transform.position.x + width / 2, transform.position.y, transform.position.z - height / 2));
    }

    //this wil be te conversion from world to the canvas
    public Vector2 WorldToCanvas(Vector3 worldSpace, float canvasWidth, float canvasHeight)
    {
        //the magnitude of the target canvas. So it scales the position to fit the canvas
        float magWidth = (canvasWidth / width);
        float magHeight = (canvasHeight / height);
        //the rect pos it wil return for the object
        Vector2 rectPos;
        //return the rect to the canvas by calculating the position within the rect
        if (closeBorder)
        {
            rectPos = new Vector2(Mathf.Clamp((transform.position.x - worldSpace.x) * magWidth, (-width/2) * magWidth, (width/2) * magWidth), Mathf.Clamp((transform.position.z - worldSpace.z) * magHeight, (-height/2) * magHeight, (height/2) * magHeight));
        }
        else
        {
            rectPos = new Vector2((transform.position.x - worldSpace.x) * magWidth, (transform.position.z - worldSpace.z) * magHeight);
        }
        //returns the reverted pos or normal based on the bool
        if (!invertPosData)
        {
            return -rectPos;
        }
        else
        {
            return rectPos;
        }
    }
    
}
