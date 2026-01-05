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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Threading;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    #region GAME_MANAGER_BASIC

    static GameManager _instance;

    static public bool isActive
    {
        get { return _instance != null; }
    }

    protected GameManager()
    {
    }

    // Singleton pattern implementation
    static public GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = UnityEngine.Object.FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                {
                    GameObject go = new GameObject("_gamemanager");
                    //DontDestroyOnLoad(go);
                    _instance = go.AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    #endregion GAME_MANAGER_BASIC


    public static string presentWorkingProjectDirectory = @"D:\Projects\Personal\_RnD\Addressables\AWS_CMS\";

    public static string awsServerDataFilePath = @"D:\Projects\Personal\_RnD\Addressables\AWS_CMS\ServerData\StandaloneWindows\";

    public static string awsServerDataFilePathIOS = @"D:\Projects\Personal\_RnD\Addressables\AWS_CMS\ServerData\IOS\";

    public static string textureFlagPath = @"C:\Temp\Texture.txt";

    public static string batchFilepath = @"D:\Projects\Personal\_RnD\Addressables\AWS_CMS\MyBatch.bat";

    public static bool hashChanged = false;
    
    public static CancellationTokenSource _hashChangeCancellationTokenSource;




    private void Awake()
    {
        //presentWorkingProjectDirectory = System.IO.Directory.GetCurrentDirectory();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
          //  hashChanged = true;
        }

     
    }


}