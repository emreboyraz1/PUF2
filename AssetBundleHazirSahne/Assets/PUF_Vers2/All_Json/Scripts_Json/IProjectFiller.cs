using BestHTTP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IProjectFiller : MonoBehaviour {

    public string jsonPath;
    private bool downloadStarted;
    private string jsonStream;

    public void Execute(string targetID)
    {
      
        downloadStarted = false;
        jsonStream = string.Empty;
        HTTPRequest req = new HTTPRequest(new Uri(jsonPath), (request, response) => {
            switch (request.State)
            {
                case HTTPRequestStates.Finished:
                    jsonStream = response.DataAsText;
                    Debug.Log("jsonstream " + jsonStream);
                    break;
                case HTTPRequestStates.Error:
                    Debug.LogError("Request Finished with Error" +
                        (request.Exception != null ?
                        (request.Exception.Message + "\n" +
                        request.Exception.StackTrace) :
                        "No Exception"));
                    break;
                case HTTPRequestStates.Aborted:
                    Debug.LogWarning("Request Aborted");
                    break;
                case HTTPRequestStates.ConnectionTimedOut:
                    Debug.LogError("Connection Timed Out");
                    break;
                case HTTPRequestStates.TimedOut:
                    Debug.LogError("Processing the request Timed Out!");
                    break;
                default:
                    Debug.LogError("Other Errors");
                    break;
            }
        });

        req.Send();
        downloadStarted = true;
        Debug.Log("execute Finished ");

    }

    void Update()
    {
        if (downloadStarted)
        {
            if (jsonStream != string.Empty)
            {
                downloadStarted = false;
                Parse(jsonStream);
            }
        }
    }


    public abstract void Parse(string jsonStream);

}
