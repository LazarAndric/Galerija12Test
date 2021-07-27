using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = Vector3.up;
    private Transform _clickedObjectTransform;

    public UnityEvent<Vector3> SavePosition;
    public UnityEvent<SceneObject> OnHitObj;

    public static RaycastHandler Instance;
    void Awake()
    {
        if(Instance==null)
            Instance = this;
    }

    //Check if is clicked left mouse click, and what is state of click
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            OnMouseDown();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            OnMouseUp();
        else if (Input.GetKey(KeyCode.Mouse0))
            OnDrag();
    }

    //When mouse is clicked, checked if SceneObject is hit by the ray.
    //Invoke OnHit method
    private void OnMouseDown()
    {
        var raycastHit = Raycast("ObjectRay");
        if(raycastHit.transform!=null)
        {
            _clickedObjectTransform = raycastHit.transform;
            OnHitObj.Invoke(raycastHit.transform.gameObject.GetComponent<SceneObject>());
        }
    }

    //When mouse is on state drag, checked if Ground is hit by the ray,
    //In that case, with hit ground position and whit offset we set position for the selected object
    private void OnDrag()
    {
       var raycastHit=Raycast("GroundRay");
        if (_clickedObjectTransform != null)
        {
            if (raycastHit.point != Vector3.zero)
            {
                _clickedObjectTransform.position = raycastHit.point + offset;
                //For each change of position
                SavePosition.Invoke(_clickedObjectTransform.position);
            }
        }
    }

    //When mouse is in up state, save position of clicked object,
    //Set transform of clicked object to null (not exist)
    private void OnMouseUp()
    {
        if (_clickedObjectTransform != null)
        {
            _clickedObjectTransform = null;
            //For each position of dropped object
            //SavePosition.Invoke(_clickedObjectTransform.position);
        }
    }

    //Parameter is name of mask layer for hit
    //Use click of mouse from camera and cast him to scene with ray
    //Get transform value of hit object
    private RaycastHit Raycast(string maskName)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int mask = LayerMask.GetMask(maskName);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            return hit;
        }
        return hit;
    }
}