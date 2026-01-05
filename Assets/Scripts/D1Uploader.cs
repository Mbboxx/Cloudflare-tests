using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using static UnityEditor.FilePathAttribute;

public class D1Uploader : MonoBehaviour
{
    public EventData eventData;
    string newSessionID;

    private void Start()
    {
        newSessionID = System.Guid.NewGuid().ToString();
    }


    public IEnumerator UploadEvent(string eventName, int value, string location )
    {
        string url = "https://database-worker.kingmbox47.workers.dev/";

        EventData data = new EventData(eventName, value, location, newSessionID);
        string json = JsonUtility.ToJson(data);

        UnityWebRequest req = new UnityWebRequest(url, "POST");
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        req.uploadHandler = new UploadHandlerRaw(body);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("D1 insert/update success: " + req.downloadHandler.text);
        }
        else
        {
            Debug.LogError("D1 insert/update failed: " + req.error);
            Debug.LogError("Server Response: " + req.downloadHandler.text);
        }
    }

    [System.Serializable]
    public class EventData
    {
        public string EventName;
        public string UserDevice;
        public string SessionID;
        public string TimeStamp;
        public string Location;
        public int Value;

        public EventData(string evntName, int s, string eventLocation, string session)
        {
            EventName = evntName;
            Value = s;
            UserDevice = SystemInfo.deviceModel;
            SessionID = session;
            TimeStamp = System.DateTime.UtcNow.ToString("o");
            Location = eventLocation;
        }
    }

    public void UploadEventData()
    {
        StartCoroutine(UploadEvent(eventData.EventName, 1, eventData.Location));
    }

    public void UpdateEventData()
    {

    }
}
