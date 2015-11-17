using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.Helpers
{
    public class ViewManager
    {
        private ContentControl _container;

        private ObservableCollection<FrameworkElement> _loadedViews;
        private ObservableCollection<FrameworkElement> _viewStack; 

        public FrameworkElement Current => _viewStack.First();
        public FrameworkElement Previous => _viewStack[1];

        public ViewManager()
        {
            _loadedViews = new ObservableCollection<FrameworkElement>();
            _viewStack = new ObservableCollection<FrameworkElement>();

            LoadView("LoaderView");
        }

        public void SetContainer(ContentControl container)
        {
            _container = container;
        }

        public FrameworkElement SetView(string viewName)
        {
            FrameworkElement view = null;
            
            lock (_loadedViews)
            {
                view = _loadedViews.FirstOrDefault(x => x.Name.Equals(viewName));
            }

            if (view == null)
            {
                SetView("LoaderView");

                var viewLoadTask = new Task(() => view = LoadView(viewName));
                viewLoadTask.RunSynchronously();
            }

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

            _container.Content = view;

            return view;
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
