using BepInEx;
using System;
using UnityEngine;
using Utilla;

namespace ThirdPersonHatFix
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        Plugin() => Events.GameInitialized += OnGameInitialized;
        void OnGameInitialized(object sender, EventArgs e)
        {
            int mirrorOnlyMask = 1 << LayerMask.NameToLayer("MirrorOnly");
            int noMirrorMask = 1 << LayerMask.NameToLayer("NoMirror");

            Camera.allCameras[1].cullingMask |= mirrorOnlyMask;
            Camera.allCameras[1].cullingMask &= ~noMirrorMask;

            Destroy(this);
        }
    }
}
