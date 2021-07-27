using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlertBox : MonoBehaviour
{
    public GameObject content;
    public TMP_Text messageLabel;

    //On start turn off alert box
    void Awake()
    {
        content.SetActive(false);
    }

    //Show alert and give alert box message content
    public void ShowAlert(string msg)
    {
        content.SetActive(true);
        messageLabel.text = msg;
    }
}
