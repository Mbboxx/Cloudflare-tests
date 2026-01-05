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
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AsyncUniTaskExample : MonoBehaviour
{
    
    
    private CancellationTokenSource _cancellationTokenSource;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.hashChanged = true;
        }
    }

    public void Start()
    {
        _cancellationTokenSource = new CancellationTokenSource();

        WaitForHashToChange();
    }

    public async void WaitForHashToChange()
    {
        Debug.Log("hashchanged is = " + GameManager.hashChanged + "  --- WAIT to run aws commands ");
        try
        {
            await UniTask.WaitUntil((() => GameManager.hashChanged), cancellationToken: _cancellationTokenSource.Token);
        }
        catch (OperationCanceledException e)
        {
            Debug.Log(e.Message);
        }

        if (_cancellationTokenSource.IsCancellationRequested)
        {
            Debug.Log("Task is canceled");
            return;
        }

        if (GameManager.hashChanged==false)
        {
            Debug.Log("hashchanged  is false  --- WAIT to run aws commands");
        }
        else if  (GameManager.hashChanged==true)
        {
            Debug.Log("hashchanged  is True  --- RUN aws commands");
            _cancellationTokenSource.Cancel();
        }
         
    }
  

    private void OnDisable()
    {
        _cancellationTokenSource.Cancel();
        Debug.Log("OnDisable: Task is canceled");
    }
    
    
}
