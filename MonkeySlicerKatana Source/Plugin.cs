using BepInEx;
using System;
using UnityEngine;
using Utilla;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace MonkeySlicerKatana
{
    [Description("HauntedModMenu")]
    [ModdedGamemode]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    public class Plugin : BaseUnityPlugin
    {

        GameObject rightHand;
        GameObject _Katana;

        void Awake()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            Utilla.Events.GameInitialized += OnGameInitialized;

        }

        void Update()
        {
            
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            InstantiateKatana();
        }
        void InstantiateKatana()
        {
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("MonkeySlicerKatana.Assets.katana");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);

            GameObject Katana = bundle.LoadAsset<GameObject>("katanaprefab");
            _Katana = Instantiate(Katana);

            rightHand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/");
            _Katana.transform.SetParent(rightHand.transform, false);
            _Katana.transform.localPosition = Vector3.zero;
            _Katana.transform.localScale = new Vector3(1, 1, 1);
            _Katana.transform.GetChild(0).localPosition = new Vector3(-0.0287f, 0.0555f, -0.0401f);
            _Katana.transform.GetChild(0).localRotation = Quaternion.Euler(313.9999f, 180f, 90f);
            _Katana.transform.GetChild(0).localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}
