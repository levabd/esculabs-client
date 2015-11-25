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
        
        public FrameworkElement SetView(string viewName, ViewInitializeDelegate initFunc = null)
        {
            FrameworkElement view;
            
            lock (_loadedViews)
            {
                view = _loadedViews.FirstOrDefault(x => x.Name.Equals(viewName));
            }

            if (view == null)
            {
                view = LoadView(viewName);

                if (view == null)
                {
                    return null;
                }

                initFunc?.Invoke(view);
            }

            if (_viewStack.Any())
            {
                _viewStack.Insert(0, view);
            }
            else
            {
                _viewStack.Add(view);
            }

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

        private FrameworkElement LoadView(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.Name.Equals(className));

            if (type == null)
            {
                return null;
            }

            var view = (FrameworkElement) Activator.CreateInstance(type);
            if (view != null)
            {
                view.Name = className;

                lock (_loadedViews)
                {
                    _loadedViews.Add(view);
                }
            }

            return view;
        }


    }
}
