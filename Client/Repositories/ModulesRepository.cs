using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Repositories
{
    using Common.Logging;
    using Models;
    using ModuleFramework;
    using System.IO;
    using System.Reflection;
    using System.Windows;

    public class ModulesRepository
    {
        private static volatile ModulesRepository _instance;
        private static readonly object SyncRoot = new object();

        private readonly ILog           _log;
        private List<IModuleProvider>   _modules;

        public static ModulesRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
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

            ReloadModules();
        }

        /// <summary>
        /// Перезагружает модули
        /// </summary>
        /// Возможно, понадобится поменять видимость на public при реализации системы обновления
        private void ReloadModules()
        {
            if (_modules == null)
            {
                _modules = new List<IModuleProvider>();
            }
            else
            {
                _modules.Clear();
            }

            if (!LoadModules())
            {
                _log.Warn("Some Esculabs modules weren't loaded");
            }
        }

        public List<object> GetWidgetsList(Window owner, List<Role> userRoles = null)
        {


            //foreach (var libFile in libFiles)
            //{
            //    _log.Info($"Loading module: {libFile}");

            //    var moduleName = Path.GetFileNameWithoutExtension(libFile);
            //    moduleName = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

            //    IModuleProvider providerInst = null;
            //    try
            //    {
            //        Assembly assembly = Assembly.LoadFrom(libFile);
            //        Type type = assembly.GetType("ModuleProvider");
            //        providerInst = (IModuleProvider)Activator.CreateInstance(type, owner, null);

            //        var methodInfo = type.GetMethod("GetWidget");
            //        if (methodInfo == null) // the method doesn't exist
            //        {
            //            throw new Exception($"Method { moduleName }.{ moduleName}Provider.GetWidget() does not exists in loaded assembly");
            //        }

            //        var res = providerInst.GetWidget();
            //        //var res = methodInfo.Invoke(providerInst, null);

            //        if (res != null)
            //        {
            //            result.Add(res);
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        _log.Error($"Can't load module {libFile}. Reason: {e.Message}");
            //    }

            //    //if (providerInst != null)
            //    //{
            //    //    result.Add(providerInst);
            //    //}
            //}

            return new List<object>();
        }

        /// <summary>
        /// Загружает все модули Esculabs
        /// </summary>
        private bool LoadModules()
        {
            // Получаем список файлов с расширением DLL из {директория приложения}\Modules
            var libFiles = Directory.GetFiles("Modules", "*.dll");

            foreach (var libFile in libFiles)
            {
                try
                {
                    _log.Info($"Loading module: {libFile}");

                    // Получаем имя модуля из имени файла библиотеки
                    var moduleName = Path.GetFileNameWithoutExtension(libFile);

                    if (string.IsNullOrEmpty(moduleName))
                    {
                        continue;
                    }

                    moduleName = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

                    // Загружаем модуль
                    var assembly = Assembly.LoadFrom(libFile);

                    // Получаем тип класса провайдера из библиотеки
                    var types = assembly.GetTypes();

                    if (types.Length == 0)
                    {
                        throw new Exception($"Assembly {libFile} contains no types");
                    }

                    var providerType = types.First(type => type.Name.EndsWith(".ModuleProvider"));

                    if (providerType == null)
                    {
                        throw new Exception($"Can't find {moduleName}.ModuleProvider type");
                    }

                    // Создаём экземпляр провайдера
                    var providerInst = (IModuleProvider)Activator.CreateInstance(providerType);

                    if (providerInst == null)
                    {
                        throw new Exception($"Can't instantiate {moduleName} module provider");
                    }

                    // Добавляем провайдер в общий список модулей
                    _modules.Add(providerInst);
                }
                catch (Exception e)
                {
                    _log.Error($"Can't load module {libFile}. Skipping. Reason: {e.Message}");
                }
            }

            // Количество экземпляров модулей должно быть равно количеству физических DLL в директории модулей
            return libFiles.Count() == _modules.Count();
        }
    }
}
