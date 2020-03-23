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

namespace Noted
{
    [Activity(Label = "AddNote")]
    public class AddNote : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.addNoteLayout);
            var confirmAddButton = FindViewById<Button>(Resource.Id.confirmAdd_btn);

            confirmAddButton.Click += (s, e) =>
            {
                var AddNoteTitle = FindViewById<EditText>(Resource.Id.addNoteTitle);
                var AddNoteText = FindViewById<EditText>(Resource.Id.addNoteText);
                var noteTitle = AddNoteTitle.Text;
                var noteContent = AddNoteText.Text;
                DatabaseService.AddNote(noteTitle, noteContent);

                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            };
        }
    }
}