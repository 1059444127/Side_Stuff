namespace ConsoleQUest.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class SaveLoadSystem
    {
        public static void LoadGameState()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var types = currentAssembly.GetTypes();
            foreach (Type currentType in types)
            {
                if (currentType.GetInterface("IJSONSerializable") != null)
                {
                    currentType.GetMethod("SaveState").Invoke(null, null);
                }
            }
        }

    }
}
