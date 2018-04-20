using System;
using CustomPrototypes.NetStandard.Views;

namespace CustomPrototypes.NetStandard.Models
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