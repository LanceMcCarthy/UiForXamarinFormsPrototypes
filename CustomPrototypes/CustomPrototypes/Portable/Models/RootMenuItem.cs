using System;
using CustomPrototypes.Portable.Views;

namespace CustomPrototypes.Portable.Models
{
    public class RootMenuItem
    {
        public RootMenuItem()
        {
            TargetType = typeof(RootDetail);
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}