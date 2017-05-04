using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class AssetBundleLoadManager  {

    static private Dictionary<string, AssetBundleRef> dictAssetBundleRefs;
    static AssetBundleLoadManager()
    {
        dictAssetBundleRefs = new Dictionary<string, AssetBundleRef>();
    }

    private class AssetBundleRef
    {
        public AssetBundle assetBundle = null;
        public string url;
        public AssetBundleRef(string strUrlIn)
        {
            url = strUrlIn;
        }
    };
    public static AssetBundle getAssetBundle(string url)
    {
        string keyName = url ;
        AssetBundleRef abRef;
        if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
            return abRef.assetBundle;
        else
            return null;
    }
    public static void LoadAssetBundle(string url)
    {
        string keyName = url;
        if (dictAssetBundleRefs.ContainsKey(keyName))
            Debug.Log("AssetBundle Contains Key");
            
        else
        {          

            AssetBundleRef abRef = new AssetBundleRef(url);
            abRef.assetBundle = AssetBundle.LoadFromFile(Application.persistentDataPath + "/" + url);
            dictAssetBundleRefs.Add(keyName, abRef);

            if (abRef.assetBundle != null)
                SceneManager.LoadSceneAsync(abRef.assetBundle.GetAllScenePaths()[0]);
            else
                Debug.LogError("Asset is Null");
        }
    }
    public static void Unload(string url, bool allObjects)
    {
        string keyName = url ;
        AssetBundleRef abRef;
        if (dictAssetBundleRefs.TryGetValue(keyName, out abRef))
        {
            abRef.assetBundle.Unload(allObjects);
            abRef.assetBundle = null;
            dictAssetBundleRefs.Remove(keyName);
        }
    }
}
