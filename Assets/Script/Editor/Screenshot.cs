using System.IO;
using UnityEditor;
using UnityEngine;

namespace SelfEditor
{
    public class Screenshot
    {
        [MenuItem("ScreenShot/Take Screenshot")]
        public static void TakeScreenshot()
        {
            var assetDir = new DirectoryInfo(Application.dataPath);
            var screenshotsDir = assetDir.Parent.CreateSubdirectory("Screenshots");
            var file = $"{System.DateTime.Now:yyyyMMddHHmmss}.png";

            var path = Path.Combine(screenshotsDir.FullName, file);
            ScreenCapture.CaptureScreenshot(path);

            Debug.Log($"Saved screenshot: {path}");
        }
    }
}