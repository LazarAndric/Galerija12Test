using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;
    private SceneObject _selectedObject;
    public UnityEvent<string> OnObjectIsNull;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        RaycastHandler.Instance.OnHitObj.AddListener(OnSelectedObjectChange);
        RaycastHandler.Instance.SavePosition.AddListener(ChangePositionOfSelectedObject);
    }

    public void ChangePositionOfSelectedObject(Vector3 position)
    {
        _selectedObject.SavePosition(position);
    }

    public void UndoPositionOfSelectedObject()
    {
        _selectedObject.Undo();
    }

    public void RedoPositionOfSelectedObject()
    {
        _selectedObject.Redo();
    }

    //Check if selected scene object is not same like last one
    //Set new selected scene object
    public void OnSelectedObjectChange(SceneObject obj)
    {
        if (obj != _selectedObject)
        {
            obj.ChangeColor(Color.cyan);
            if(_selectedObject!=null)
            {
                _selectedObject.ChangeToDefaultColor();
            }
            _selectedObject = obj;
        }
    }
    
    //Change default and current color of selected object
    //If nothing is selected OnObjectIsNull will be invoke
    public void ChangeColorOfSelectedObject(Color color)
    {
        if (_selectedObject != null)
        {
            _selectedObject.ChangeColor(color);
            _selectedObject.SetDefaultColor(color);
        }
        else
        {
            OnObjectIsNull.Invoke("First select object!");
        }
    }

    public SceneObject SelectedObject { get => _selectedObject; set => _selectedObject = value; }
}