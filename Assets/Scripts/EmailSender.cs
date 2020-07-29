using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class EmailSender : MonoBehaviour
{
    public TMP_InputField subjectInput;
    public TMP_InputField bodyInput;

    string WebUrl(string URL)
    {
        return UnityWebRequest.EscapeURL(URL).Replace("+","%20");
    }

    public void SendEmail()
    {
        if (bodyInput.text == "" && subjectInput.text == "")
            return;

        string subject = WebUrl(bodyInput.text);
        string body = WebUrl(subjectInput.text);
        
        Application.OpenURL("mailto:angelnforlano@gmail.com" + "?subject=" + subject + "&body=" + body);
    }
}
