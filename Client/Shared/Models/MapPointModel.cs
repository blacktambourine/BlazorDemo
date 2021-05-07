using System.Collections.Generic;

namespace BlazorDemo.Client.Shared.Models
{
    public class MapPointModel
    {
        public string Identifier { get; set; }
        
        public string Label { get; set; }

        public List<double> Coordinates { get; set; }

    }
}
