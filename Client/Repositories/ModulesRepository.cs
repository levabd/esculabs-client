using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Client.Repositories
{
    using Common.Logging;
    using Models;
    using EsculabsCommon;
    using System.IO;
    using System.Reflection;
    using Helpers;

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

        public List<UserControl> GetWidgetsList(Patient patient)
        {
            return _modules.Any() ? _modules.Select(module => module.GetWidget(patient)).Where(w => w != null).ToList(): null;
        }

        public void SubscribeViewManager(ViewManager viewManager)
        {
            if (!_modules.Any())
            {
                return;
            }

            _modules.ForEach(mp => mp.ViewSwitchEventHandler += viewManager.HandleModuleViewChange);
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

                    Type[] types;

                    // Получаем тип класса провайдера из библиотеки
                    try
                    {
                        types = assembly.GetTypes();
                    }
                    catch (ReflectionTypeLoadException e)
                    {
                        var s = e.LoaderExceptions;

                        throw new Exception($"Can't load {moduleName} types");
                    }

                    if (types.Length == 0)
                    {
                        throw new Exception($"Assembly {libFile} contains no types");
                    }

                    var providerType = types.FirstOrDefault(type => type.Name == "ModuleProvider");

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
