using UnityEngine;
using UnityEditor;
using System.Collections;
using Google.Android.AppBundle.Editor;
using Google.Android.AppBundle.Editor.Internal;

public class AssetbundlesMenuItems
{
	const string kSimulateAssetBundlesMenu = "AssetBundles/Simulate AssetBundles";

	[MenuItem(kSimulateAssetBundlesMenu)]
	public static void ToggleSimulateAssetBundle ()
	{
		AssetBundleManager.SimulateAssetBundleInEditor = !AssetBundleManager.SimulateAssetBundleInEditor;
	}

	[MenuItem(kSimulateAssetBundlesMenu, true)]
	public static bool ToggleSimulateAssetBundleValidate ()
	{
		Menu.SetChecked(kSimulateAssetBundlesMenu, AssetBundleManager.SimulateAssetBundleInEditor);
		return true;
	}
	
	[MenuItem ("AssetBundles/Build AssetBundles")]
	static public void BuildAssetBundles ()
	{
		BuildScript.BuildAssetBundles();
	}

	[MenuItem ("AssetBundles/Build Player")]
	static void BuildPlayer ()
	{
		BuildScript.BuildPlayer();
	}
	
		
	[MenuItem ("AssetBundles/Build Player By Google")]
	static void BuildByGoogle ()
	{
		BuildPlayerOptions buildPlayerOptions =
			AndroidBuildHelper.CreateBuildPlayerOptions(Application.dataPath.Replace("/Assets", "/bin/demo.aab"));
		AssetPackConfig assetPackConfig = new AssetPackConfig
		{
			DefaultTextureCompressionFormat  = TextureCompressionFormat.Astc,
			SplitBaseModuleAssets = false
		};

		string projectPath = Application.dataPath.Replace("/Assets", "/");
		string assetBundlePath = projectPath + "AssetBundles";
		string assetBundlePath2 = projectPath + "AssetBundles2";
		
		assetPackConfig.AddAssetsFolder("AssetBundles", assetBundlePath, AssetPackDeliveryMode.InstallTime);
		// assetPackConfig.AddAssetsFolder("AssetBundles2", assetBundlePath2, AssetPackDeliveryMode.InstallTime);
		
		AppBundlePublisher.Build(buildPlayerOptions, assetPackConfig,true);
	}

}
