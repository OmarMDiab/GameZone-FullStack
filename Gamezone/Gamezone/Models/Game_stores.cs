//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gamezone.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game_stores
    {
        public int store_id { get; set; }
        public string store_name { get; set; }
        public Nullable<int> store_game_id { get; set; }
        public string store_description { get; set; }
    
        public virtual Game_titles Game_titles { get; set; }
    }
}
