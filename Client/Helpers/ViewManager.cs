﻿using System;
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
        public delegate void ViewInitializeDelegate(FrameworkElement v);

        public ContentControl Container { get; set; }

        public FrameworkElement Current => _viewStack.First();
        public FrameworkElement Previous => _viewStack[1];

        private ObservableCollection<FrameworkElement> _loadedViews;
        private ObservableCollection<FrameworkElement> _viewStack; 

        public ViewManager()
        {
            _loadedViews = new ObservableCollection<FrameworkElement>();
            _viewStack = new ObservableCollection<FrameworkElement>();
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

            initFunc?.Invoke(view);

            Container.Content = view;

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
