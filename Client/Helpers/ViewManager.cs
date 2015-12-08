using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Client.Helpers
{
    using EsculabsCommon;

    public class ViewManager
    {
        #region Объявления

        // Событие, срабатываемое при смене вьюхи
        public event EventHandler<ViewChangeArgs> ViewChangeEventHandler;
        
        // Делегат для инициализации _впервые_ отображаемой вьюхи
        public delegate void ViewInitializeDelegate(FrameworkElement v);

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
            Container.Content = view;

            if (ViewChangeEventHandler != null)
            {
                var args = new ViewChangeArgs
                {
                    ViewName = view.Name,
                    View = view
                };

                ViewChangeEventHandler(this, args);
            }

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

            Container.Content = first;

            if (ViewChangeEventHandler != null)
            {
                var args = new ViewChangeArgs
                {
                    ViewName = first.Name,
                    View = first
                };

                ViewChangeEventHandler(this, args);
            }

            return first;            
        }

        private FrameworkElement LoadView(string className, Assembly assembly = null)
        {
            var asm = assembly ?? Assembly.GetExecutingAssembly();
            
            var type = asm.GetTypes()
                .First(t => t.Name.Equals(className));
            
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
