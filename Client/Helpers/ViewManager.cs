using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Client.Annotations;

namespace Client.Helpers
{
    using EsculabsCommon;

    public class ViewManager : INotifyPropertyChanged
    {
        #region Объявления
        public event PropertyChangedEventHandler    PropertyChanged;

        // Событие, срабатываемое при смене вьюхи
        //public event EventHandler<ViewChangeArgs>   ViewChangeEventHandler;

        public FrameworkElement                     CurrentView => _viewStack.FirstOrDefault();

        // Контейнер, отображающий вьюхи
        public ContentControl                       Container { get; set; }

        // Все загруженные вьюхи
        private readonly List<FrameworkElement>     _loadedViews;

        // Текущий стек отображённых вьюх (для навигации)
        private readonly List<FrameworkElement>     _viewStack;

        #endregion

        public ViewManager()
        {
            _loadedViews = new List<FrameworkElement>();
            _viewStack = new List<FrameworkElement>();
        }

        public void HandleModuleViewChange(object sender, ViewChangeArgs args)
        {
            var assembly = sender.GetType().Assembly;

            SetView(args.ViewName, args.ViewInitDelegate, assembly);
        }

        public FrameworkElement SetView(string viewName, ViewInitializeDelegate initDelegate = null, Assembly assembly = null)
        {
            var view = LoadView(viewName, assembly);

            if (view == null)
            {
                return null;
            }
            
            if (_viewStack.Any())
            {
                _viewStack.Insert(0, view);
            }
            else
            {
                _viewStack.Add(view);
            }

            initDelegate?.Invoke(view);

            ((BaseView) view).ClearInput();

            OnPropertyChanged(nameof(CurrentView));

            return view;
        }

        public FrameworkElement SetPrevious()
        {
            if (_viewStack.Count < 2)
            {
                return null;
            }

            var list = _viewStack.GetRange(1, _viewStack.Count - 1);
            _viewStack.Clear();
            _viewStack.AddRange(list);

            var first = _viewStack.FirstOrDefault();

            if (first == null)
            {
                return null;
            }

            OnPropertyChanged(nameof(CurrentView));

            return first;            
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private FrameworkElement LoadView(string className, Assembly assembly = null)
        {
            var asm = assembly ?? Assembly.GetExecutingAssembly();
            
            var type = asm.GetTypes()
                .FirstOrDefault(t => t.FullName.Equals(className));
            
            if (type == null)
            {
                return null;
            }

            var viewName = type.FullName;            
            var view = _loadedViews.FirstOrDefault(x => x.GetType().FullName == viewName);

            if (view == null)
            {
                view = (FrameworkElement)Activator.CreateInstance(type);

                if (view == null)
                {
                    return null;
                }

                _loadedViews.Add(view);
            }
            
            return view;
        }
    }
}
