using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// Takes screenshots at three moments:
// when the Unity project is loaded
// when you press play,
// and when you press the space key in play mode

public class ScreenShot : MonoBehaviour
{
    // ----------
    // Start by setting this filepath to wherever you want to save your screenshots
    // ----------
    static string customFilePath = ""; // path to (new) screenshots folder, no "/" at the end

    static int photoIndex = 1;
    
    [InitializeOnEnterPlayMode]
    public static void InitializeOnEnterPlayMode ()
    {
        EditorApplication.playModeStateChanged += AddGameObjectToScene;        
    }

    static void AddGameObjectToScene(PlayModeStateChange playModeStateChange)
    {
        if (playModeStateChange.ToString().Equals("EnteredPlayMode"))
        {
            GameObject newGO = new GameObject();
            newGO.AddComponent<ScreenShot>();
        }        
    }

    private void Update()
    {
        #if ENABLE_INPUT_SYSTEM
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                TakeScreenshot();
            }
        #else
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeScreenshot();
            }
        #endif
    }

    [InitializeOnLoadMethod]
    public static void TakeScreenshot()
    {        
        string screenshotPath = GetNewScreenshotPath();
        ScreenCapture.CaptureScreenshot(screenshotPath, 1);
    }

    private static string GetNewScreenshotPath()
    {
        string applicationName = Application.productName;
        string newPath = customFilePath +"/" + applicationName + "/screenshot" + photoIndex + ".png";        
        if (System.IO.File.Exists(newPath))
        {
            photoIndex++;
            return GetNewScreenshotPath();
        }
        else
        {
            string directoryPath = customFilePath + applicationName + "/";
            if (!System.IO.Directory.Exists(directoryPath)) {
                System.IO.Directory.CreateDirectory(directoryPath);
            }
            return newPath;
        }
    }
}
