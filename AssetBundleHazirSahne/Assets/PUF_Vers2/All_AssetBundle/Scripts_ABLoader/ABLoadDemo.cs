using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABLoadDemo : MonoBehaviour {

    AssetBundle bundle;
    string filePath;
    private void Start()
    {
        filePath = "Enter File Path";
        bundle = AssetBundleLoadManager.getAssetBundle(filePath);
        if (!bundle)
            LoadAssetBundle(filePath);
    }
    void LoadAssetBundle(string filePath)
    {
        AssetBundleLoadManager.LoadAssetBundle(filePath);
        bundle = AssetBundleLoadManager.getAssetBundle(filePath);
    }
    private void OnDisable()
    {
        if (filePath != null)
        {
            AssetBundleLoadManager.Unload(filePath, true);
        }
    }
}
