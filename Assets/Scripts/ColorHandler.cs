using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorHandler : MonoBehaviour
{
    //Set color to red
    public void ChangeOnRed()
    {
        GameHandler.Instance.ChangeColorOfSelectedObject(Color.red);
    }

    //Set color to green
    public void ChangeOnGreen()
    {
        GameHandler.Instance.ChangeColorOfSelectedObject(Color.green);
    }

    //Set color to blue
    public void ChangeOnBlue()
    {
        GameHandler.Instance.ChangeColorOfSelectedObject(Color.blue);
    }
}