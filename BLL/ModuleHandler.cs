using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class ModuleHandler
    {
        ModuleDBAccess moduleDB = null;

        public ModuleHandler()
        {
            moduleDB = new ModuleDBAccess();
        }

        public List<Module> GetModuleList(int lecturerID)
        {
            return moduleDB.GetModuleList(lecturerID);
        }

        public List<Module> GetDisabledModuleList(int lecturerID)
        {
            return moduleDB.GetDisabledModuleList(lecturerID);
        }

        public int AddNewModule(Module module)
        {
            return moduleDB.AddNewModule(module);
        }

        public bool DisableModule(int moduleID)
        {
            return moduleDB.DisableModule(moduleID);
        }

        public bool EnableModule(int moduleID)
        {
            return moduleDB.EnableModule(moduleID);
        }

        public Module GetModuleDetails(int moduleID)
        {
            return moduleDB.GetModuleDetails(moduleID);
        }
    }
}
