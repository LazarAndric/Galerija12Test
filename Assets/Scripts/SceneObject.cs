using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    //_defaultColor is used when object is not select
    [SerializeField]
    private Color _defaultColor;
    private MeshRenderer mesh;
    private List<Vector3> historyOfTransform = new List<Vector3>();
    private int index;

    //Get instance of mesh and set defaultColor
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        SavePosition(transform.position);
    }

    public void ChangeColor(Color color)
    {
        mesh.material.color = color;
    }

    public void SetDefaultColor(Color color)
    {
        _defaultColor = color;
    }
    
    //Set default color as the current color
    public void ChangeToDefaultColor()
    {
        mesh.material.color = _defaultColor;
    }

    //Checked if index is on the end of list
    //If is not, deletes everything behind the index
    //And then add new position in list
    public void SavePosition(Vector3 position)
    {
        if(index < historyOfTransform.Count -1)
        {
            RemoveItemBehindIndex();
        }
        historyOfTransform.Add(position);
        index = historyOfTransform.IndexOf(position);
    }

    public void Undo()
    {
        if (index > 0)
        {
            index -= 1;
            var undoPosition = historyOfTransform[index];
            gameObject.transform.position = undoPosition;
        }
    }

    public void Redo()
    {
        if(index +1 < historyOfTransform.Count)
        {
            index +=  1;
            var redoPosition = historyOfTransform[index];
            gameObject.transform.position = redoPosition;
        }
    }

    //Uses all items after the index in the list and removes them
    private void RemoveItemBehindIndex()
    {
        historyOfTransform.RemoveRange(index + 1, historyOfTransform.Count - index - 1);
    }

    public Color DefaultColor { get => _defaultColor; set => _defaultColor = value; }
}