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
    
    public partial class Streamer_details
    {
        public int streamer_id { get; set; }
        public string streamer_name { get; set; }
        public Nullable<int> twitch_rank { get; set; }
        public string description { get; set; }
        public string most_streamed_game { get; set; }
        public Nullable<int> number_of_followers { get; set; }
        public Nullable<int> game_id { get; set; }
    
        public virtual Game_titles Game_titles { get; set; }
    }
}