using ICities;
using UnityEngine;

namespace ApocalypseEnhancer
{
    #region Mod Definition
    /// <summary>
    /// Provide description of the mod to the game, this is shown during mod loading screen.
    /// </summary>
    public class AE : IUserMod
    {
        public string Name
        {
            get { return "Apocalypse Enhancer v0.0.1"; }
        }

        public string Description
        {
            get { return "Enhancing visual effects in destroyed cities and automatically disabling destroyed public buidlings "; }
        }

        public void OnSettingsUI(UIHelperBase helper) {
            UIHelperBase group = helper.AddGroup(this.Name);
        }
    }
    #endregion

    #region Mod Behavior
    /// <summary>
    /// Will first look at all roads, and if they are flooded, will turn off their street lights.
    /// Will also look at all public buildings, and turn them off if they are flooded or destroyed
    /// </summary>
    public class AELoader : LoadingExtensionBase
    {
        /// <summary>
        /// This event is triggerred when a level is loaded
        /// </summary>
        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);

            DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "AE Loaded");
        }
    }
    #endregion
}