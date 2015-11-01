using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories
{
    using Common.Logging;
    using Models;
    using ModuleFramework;
    using System.IO;
    using System.Reflection;
    using Controls;
    using System.Windows;

    class ModulesRepository
    {
        private static volatile ModulesRepository _instance;
        private static object _syncRoot = new object();

        private ILog _log;

        public static ModulesRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new ModulesRepository();
                    }
                }

                return _instance;
            }
        }

        public ModulesRepository()
        {
            _log = LogManager.GetLogger("Modules Repository");

        }

        public List<object> GetWidgetsList(Window owner, List<Role> userRoles = null)
        {
            var libFiles = Directory.GetFiles("Modules", "*.dll");
            var result = new List<object>(libFiles.Count());

            foreach (var libFile in libFiles)
            {
                _log.Info($"Loading module: {libFile}");

                var moduleName = Path.GetFileNameWithoutExtension(libFile);
                moduleName = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

                IModuleProvider providerInst = null;
                try
                {
                    Assembly assembly = Assembly.LoadFrom(libFile);
                    Type type = assembly.GetType($"{moduleName}.{moduleName}Provider");
                    providerInst = Activator.CreateInstance(type, new object[] { owner, null } ) as IModuleProvider;

                    var methodInfo = type.GetMethod("GetWidget");
                    if (methodInfo == null) // the method doesn't exist
                    {
                        throw new Exception($"Method { moduleName }.{ moduleName}Provider.GetWidget() does not exists in loaded assembly");
                    }
                    
                    var res = methodInfo.Invoke(providerInst, null);

                    if (res != null)
                    {
                        result.Add(res);
                    }
                }
                catch (Exception e)
                {
                    _log.Error($"Can't load module {libFile}. Reason: {e.Message}");
                }

                //if (providerInst != null)
                //{
                //    result.Add(providerInst);
                //}
            }

            return result;
        }

        //public List<IModuleProvider> GetProviders(List<Role> userRoles = null)
        //{
        //    var libFiles = Directory.GetFiles("Modules", "*.dll");
        //    var result = new List<IModuleProvider>(libFiles.Count());

        //    foreach (var libFile in libFiles)
        //    {
        //        _log.Info($"Loading module: {libFile}");

        //        var moduleName = Path.GetFileNameWithoutExtension(libFile);
        //        moduleName = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        //        IModuleProvider providerInst = null;
        //        try
        //        {
        //            Assembly assembly = Assembly.LoadFrom(libFile);
        //            Type type = assembly.GetType($"{moduleName}.{moduleName}Provider");
        //            providerInst = Activator.CreateInstance(type) as IModuleProvider;

        //            var methodInfo = type.GetMethod("GetWidget", new Type[] { typeof(IPatient) });
        //            if (methodInfo == null) // the method doesn't exist
        //            {
        //                throw new Exception($"Method { moduleName }.{ moduleName}Provider.GetWidget() does not exists in loaded assembly");
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _log.Error($"Can't load module {libFile}. Reason: {e.Message}");
        //        }

        //        if (providerInst != null)
        //        {
        //            result.Add(providerInst);
        //        }
        //    }

        //    return result;
        //}
    }
}
