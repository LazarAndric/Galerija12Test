using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControllHandler : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            GameHandler.Instance.UndoPositionOfSelectedObject();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GameHandler.Instance.RedoPositionOfSelectedObject();
        }
    }
}
