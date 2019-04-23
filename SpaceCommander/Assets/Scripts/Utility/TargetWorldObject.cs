using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWorldObject : MonoBehaviour
{
    private enum RotateAxis { x , y, z }
    [SerializeField]
    RotateAxis folowingAxis;
    private WorldRect converter;
    private RectTransform thisPos;
    [SerializeField]
    Transform target;
    [SerializeField]
    bool folowRotation = false;
    [SerializeField]
    float rotationOffset = 0;
    RectTransform targetCanvas;

    private void Start()
    {
        thisPos = GetComponent<RectTransform>();
        targetCanvas = gameObject.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        converter = GameObject.FindObjectOfType<WorldRect>();
        if(converter == null)
        {
            Debug.LogWarning("No world rect has been found!");
        }
    }

    private void Update()
    {
        PositionBasedOnWorld();
        SetRotation();
    }

    private void PositionBasedOnWorld()
    {
        thisPos.anchoredPosition = converter.WorldToCanvas(target.position, targetCanvas.rect.width, targetCanvas.rect.height);
    }

    private void SetRotation()
    {
        if (folowRotation)
        {
            switch (folowingAxis)
            {
                case RotateAxis.z:
                thisPos.localEulerAngles = new Vector3(thisPos.localEulerAngles.x, thisPos.localEulerAngles.y, -target.eulerAngles.y + rotationOffset);
                break;
                case RotateAxis.x:
                thisPos.localEulerAngles = new Vector3(-target.eulerAngles.y + rotationOffset, thisPos.localEulerAngles.y, thisPos.localEulerAngles.z);
                break;
                case RotateAxis.y:
                thisPos.eulerAngles = new Vector3(thisPos.localEulerAngles.x, -target.eulerAngles.y + rotationOffset, thisPos.localEulerAngles.y);
                break;

            }
        }
    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
