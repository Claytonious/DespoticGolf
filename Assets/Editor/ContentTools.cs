using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public static class ContentTools
{
    [MenuItem("Tools/DespoticGolf/Hello")]
    public static void Hello()
    {
        Debug.Log("Hello!");
    }

    [MenuItem("Tools/DespoticGolf/Build Asset Bundles")]
    public static void BuildAssetBundles()
    {
        BuildAssetBundles(BuildTarget.StandaloneWindows64);
        BuildAssetBundles(BuildTarget.StandaloneOSX);
        BuildAssetBundles(BuildTarget.iOS);
        BuildAssetBundles(BuildTarget.Android);
    }

    private static void BuildAssetBundles(BuildTarget target)
    {
        var outputPath = Path.Combine(Application.dataPath, "..", "AssetBundles", target.ToString());
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);        
    }
}
