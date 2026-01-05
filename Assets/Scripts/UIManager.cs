//The MIT License (MIT)

//Copyright © 2022 Hitlab Studios

//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
//documentation files (the “Software”), to deal in the Software without restriction, including without limitation
//the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
//and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
//WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.




using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 

    GameObject FileManager;
    
    void Awake()
    {
        FileManager = GameObject.FindGameObjectWithTag("FileManager");
    }
      
    public TMP_Text displayMessage;

    public Button ButtonVanilla = null;
    public Button ButtonAlmond = null;
    public Button ButtonOrange = null;

    public GameObject DeleteAllObjectsButton;
    public GameObject UploadAllObjectsButton;

    bool enableAWSOpButtons = false;



    void Start()
    {
        ButtonVanilla.onClick.AddListener(() => { ButtonChangeToVanillaOnClick(); });
        ButtonAlmond.onClick.AddListener(() => { ButtonChangeToAlmondOnClick(); });
        ButtonOrange.onClick.AddListener(() => { ButtonChangeToOrangeOnClick(); });
    }

    public void ToggleAWSUtilOpButtons()
    {
        enableAWSOpButtons = !enableAWSOpButtons;
        DeleteAllObjectsButton.SetActive(enableAWSOpButtons);
        UploadAllObjectsButton.SetActive(enableAWSOpButtons);
    }

    public void ManageDisplayMessage(string message)
    {
        displayMessage.text = message;
    }


    public void ManageDisplayMessage(string message, float delay)
    {
        StartCoroutine(DelayMessage(message, delay));

    }

    IEnumerator DelayMessage(string message, float delay)
    {
        yield return new WaitForSeconds(delay);
        displayMessage.text = message;
    }

    public void BlinkText()
    {
        displayMessage.GetComponent<Animator>().SetTrigger("Blink");      
    }


    //BUTTON HANDLERS --------------------------------------------------------------------------
    //ButtonChangeToVanillaOnClick   BUTTON HANDLER
    public void ButtonChangeToVanillaOnClick()
    {
        //Save the name of the texture that needs to be loaded to a text file in C:\Temp
        FileManager.GetComponent<FileManager>().SaveTextureFlagToFile("Vanilla");
        FileManager.GetComponent<FileManager>().AccessCoroutineCallBatchFile();
        ManageDisplayMessage("Rebuilding content for Vanilla...");
        BlinkText();
    }
    //------------------------------


    //ButtonChangeToAlmondOnClick   BUTTON HANDLER
    public void ButtonChangeToAlmondOnClick()
    {
        //Save the name of the texture that needs to be loaded to a text file in C:\Temp
        FileManager.GetComponent<FileManager>().SaveTextureFlagToFile("Almond");
        FileManager.GetComponent<FileManager>().AccessCoroutineCallBatchFile();
        ManageDisplayMessage("Rebuilding content for Almond...");
        BlinkText();
    }
    //------------------------------


    //ButtonChangeToOrangeOnClick   BUTTON HANDLER
    public void ButtonChangeToOrangeOnClick()
    {
        //Save the name of the texture that needs to be loaded to a text file in C:\Temp
        FileManager.GetComponent<FileManager>().SaveTextureFlagToFile("Orange");
        FileManager.GetComponent<FileManager>().AccessCoroutineCallBatchFile();
        ManageDisplayMessage("Rebuilding content for Orange...");
        BlinkText();
    }
    //------------------------------


}