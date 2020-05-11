using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EntityLayer.Reports
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(string label, decimal? y)
        {
            Label = label;
            Y = y;
        }

        [DataMember(Name ="label")]
        public string Label { get; set; }
        [DataMember(Name = "y")]
        public Nullable<decimal> Y { get; set; }
    }
}
