//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NutriApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Measure
    {
        public string UserID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<int> IMC { get; set; }
        public Nullable<int> Fat_Percentage { get; set; }
        public Nullable<int> Muscle_Percentage { get; set; }
        public Nullable<int> Methabolic_Age { get; set; }
        public Nullable<int> Viceral_Fat { get; set; }
        public Nullable<int> Water_Percentage { get; set; }
    }
}
