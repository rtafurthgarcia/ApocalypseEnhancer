using ICities;
using UnityEngine;

namespace ApocalypseEnhancer
{
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
    }
}