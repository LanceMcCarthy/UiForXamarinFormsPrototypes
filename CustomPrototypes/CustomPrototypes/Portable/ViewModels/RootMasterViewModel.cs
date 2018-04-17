﻿using System.Collections.ObjectModel;
using CustomPrototypes.Portable.Models;
using CustomPrototypes.Portable.Views;

namespace CustomPrototypes.Portable.ViewModels
{
    public class RootMasterViewModel : ViewModelBase
    {
        public RootMasterViewModel()
        {
            MenuItems = new ObservableCollection<RootMenuItem>(new[]
            {
                new RootMenuItem { Id = 0, Title = "DataGrid EditContext", TargetType = typeof(DataGridEditContext)},
                new RootMenuItem { Id = 1, Title = "Global Styles", TargetType = typeof(GloballyStyledControls)},
                new RootMenuItem { Id = 2, Title = "Badges Idea", TargetType = typeof(BadgesIdeaPage)},
                new RootMenuItem { Id = 3, Title = "About", TargetType = typeof(AboutPage) }
            });
        }
        public ObservableCollection<RootMenuItem> MenuItems { get; set; }
    }
}