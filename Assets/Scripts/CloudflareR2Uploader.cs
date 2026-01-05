using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;
using System.Text;

public class CloudflareR2Uploader : MonoBehaviour
{
    // === CONFIGURATION ===
    // *** REPLACE THIS URL WITH YOUR LIVE WORKER URL ***
    public const string WORKER_URL = "https://your-upload-worker.kingmbox47.workers.dev/";
    public string localFilePath;
    // --- Public Method to Start the Upload ---
    public void StartR2Upload(string localFilePath, string remoteFileName, string fileContentType)
    {
        if (!File.Exists(localFilePath))
        {
            Debug.LogError($"[R2 Uploader] File not found at: {localFilePath}");
            return;
        }

        // Start the asynchronous two-step process
        StartCoroutine(UploadFileToR2(localFilePath, remoteFileName, fileContentType));
    }

  
    IEnumerator UploadFileToR2(string localFilePath, string remoteFileName, string fileContentType)
    {
        string url = $"{WORKER_URL}?filename={UnityWebRequest.EscapeURL(remoteFileName)}";

        byte[] fileBytes = File.ReadAllBytes(localFilePath);

        using (UnityWebRequest req = UnityWebRequest.Put(url, fileBytes))
        {
            req.SetRequestHeader("Content-Type", fileContentType);

            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
                Debug.Log("Upload successful!");
            else
                Debug.LogError("Upload failed: " + req.error + " | " + req.downloadHandler.text);
        }
    }

    
}

// Helper class to deserialize the JSON response from the Worker
[System.Serializable]
public class R2UrlResponse
{
    public string url;
    public string fileName;
}