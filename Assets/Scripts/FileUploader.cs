using UnityEngine;

public class FileUploader : MonoBehaviour
{
    // Create a public variable to hold the reference
    public CloudflareR2Uploader R2Uploader;

    // An example file path and details to use for the upload
    public string SampleFilePath = "C:/Users/User/Desktop/screenshot.png";
    public string RemoteKeyName = "user_uploads/my_first_screenshot.png";
    public string ContentType = "image/png";

    void Start()
    {
        // 1. OPTION A: Find the script on the GameObject (if it's not set in the Inspector)
        if (R2Uploader == null)
        {
            // This is efficient if the script is on the same GameObject as this script
            R2Uploader = GetComponent<CloudflareR2Uploader>();
        }

        // 2. OPTION B: Find the script using the GameObject's name
        if (R2Uploader == null)
        {
            // Finds the component on a GameObject named "UploaderManager" in the scene
            R2Uploader = GameObject.Find("UploaderManager")?.GetComponent<CloudflareR2Uploader>();
        }

        if (R2Uploader == null)
        {
            Debug.LogError("R2Uploader script reference not found! Attach it in the Inspector or check the GameObject name.");
        }
    }

    // --- 2. Call the Upload Function ---

    public void OnUploadButtonClicked()
    {
        if (R2Uploader != null)
        {
            // Call the public method, passing the required parameters.
            R2Uploader.StartR2Upload(SampleFilePath, RemoteKeyName, ContentType);
        }
        else
        {
            Debug.LogError("Cannot start upload: Uploader script is missing.");
        }
    }
}