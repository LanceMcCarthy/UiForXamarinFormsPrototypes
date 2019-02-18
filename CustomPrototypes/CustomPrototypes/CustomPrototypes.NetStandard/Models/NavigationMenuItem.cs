using System;
using System.Collections.ObjectModel;

namespace CustomPrototypes.NetStandard.Models
{
    public class NavigationMenuItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Type TargetType { get; set; }

        public ObservableCollection<NavigationMenuItem> Children { get; set; }
    }
}