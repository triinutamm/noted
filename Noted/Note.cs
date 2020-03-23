using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Noted
{
    class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public long Id { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public string PostTime { get; set; }
    }
}