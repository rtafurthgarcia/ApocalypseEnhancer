using ColossalFramework;
using ColossalFramework.UI;
using ICities;
using System.Linq;
using System;

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

        public void OnSettingsUI(UIHelperBase helper)
        {
            UIHelperBase group = helper.AddGroup("Apocalypse Enhancer");
            group.AddButton("Disable incapacitated buildings", DisableIncapacitatedPublicBuildings);
        }

        #endregion
        #region Mod Behavior
        public void DisableIncapacitatedPublicBuildings()
        {
            DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "[AE] Clicked");
            Building.Flags incapacitationFlags = Building.Flags.BurnedDown | Building.Flags.Collapsed | Building.Flags.Flooded;

            Singleton<BuildingManager>.instance.m_buildings.m_buffer
                .TakeWhile(building => building.m_flags == incapacitationFlags)
                .TakeWhile(building =>
                       building.Info.GetService().Equals(Service.PoliceDepartment)
                    || building.Info.GetService().Equals(Service.FireDepartment)
                    || building.Info.GetService().Equals(Service.PublicTransport)
                    || building.Info.GetService().Equals(Service.Beautification)
                    || building.Info.GetService().Equals(Service.Garbage)
                    || building.Info.GetService().Equals(Service.Monument)
                    || building.Info.GetService().Equals(Service.Water)
                    || building.Info.GetService().Equals(Service.Education)
                    || building.Info.GetService().Equals(Service.HealthCare)
                    || building.Info.GetService().Equals(Service.Tourism)
                    || building.Info.GetService().Equals(Service.Electricity))
                .ForEach(building => building.m_productionRate = 0);
                //.Count();

            //DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "[AE] Total concerned: " + total.ToString());
        }
        #endregion
    }

    
    
}