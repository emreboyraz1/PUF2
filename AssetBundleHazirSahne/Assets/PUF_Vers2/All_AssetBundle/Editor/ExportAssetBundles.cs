using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExportAssetBundles
{
    public static string mainPath = "Assets/PUF_Vers2/All_AssetBundle/Exported_AssetBundles/";
    [MenuItem("Assets/Export Platform/activeBuildTarget %g", false, 1)]
    static void ExportResources_activeBuildTarget()
    {

        CreateMainFolder();
        string subFolderName = "activeBuildTarget";
        CreateSubFolder(subFolderName);
        BuildPipeline.BuildAssetBundles(mainPath + subFolderName, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

    }

    [MenuItem("Assets/Export Platform/IOS %l", false, 2)]
    static void ExportResources_IOS()
    {
        string subFolderName = "ios";
        CreateMainFolder();
        CreateSubFolder(subFolderName);
        BuildPipeline.BuildAssetBundles(mainPath + subFolderName, BuildAssetBundleOptions.None, BuildTarget.iOS);

    }

    [MenuItem("Assets/Export Platform/Android %a", false, 3)]
    static void ExportResources_Android()
    {
        string subFolderName = "android";
        CreateMainFolder();
        CreateSubFolder(subFolderName);
        BuildPipeline.BuildAssetBundles(mainPath + subFolderName, BuildAssetBundleOptions.None, BuildTarget.Android);

    }

    [MenuItem("Assets/Export Platform/WebGL %w", false, 4)]
    static void ExportResources_WebGL()
    {
        string subFolderName = "webgl";
        CreateMainFolder();
        CreateSubFolder(subFolderName);
        BuildPipeline.BuildAssetBundles(mainPath + subFolderName, BuildAssetBundleOptions.None, BuildTarget.WebGL);

    }


    static void CreateMainFolder()
    {
        string CreateFolderName = "Exported_AssetBundles";

        if (!AssetDatabase.IsValidFolder("Assets/PUF_Vers2/All_AssetBundle/" + CreateFolderName))
        {
            AssetDatabase.CreateFolder("Assets/PUF_Vers2/All_AssetBundle", CreateFolderName);

        }
    }
    static void CreateSubFolder(string folderName)
    {
        if (!AssetDatabase.IsValidFolder("Assets/PUF_Vers2/All_AssetBundle/Exported_AssetBundles/" + folderName))
        {
            string guid = AssetDatabase.CreateFolder("Assets/PUF_Vers2/All_AssetBundle/Exported_AssetBundles", folderName);
        }
    }

}
