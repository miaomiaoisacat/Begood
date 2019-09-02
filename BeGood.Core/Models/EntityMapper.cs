using System;
using System.Collections.Generic;

namespace BeGood.Core.Models
{
    public static class EntityMapper
    {
        public static Dictionary<string, string> TableNames;

        static EntityMapper()
        {
            EntityMapper.TableNames = new Dictionary<string, string>();
            TableNames.Add("Menu", "menu");
            TableNames.Add("MenuAction", "menu_action");
            TableNames.Add("Role", "role");
            TableNames.Add("RoleMenuAction", "role_menu_action");
            TableNames.Add("Store", "store");
            TableNames.Add("StoreSys", "store_sys");
            TableNames.Add("Sys", "sys");
            TableNames.Add("User", "user");
            TableNames.Add("UserRole", "user_role");
        }

        public static string GetTableName(Type type)
        {
            foreach (var item in TableNames)
            {
                if (item.Key == type.Name)
                    return item.Value;
            }
            return null;
        }
    }
}
