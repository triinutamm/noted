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
    [Activity(Label = "EditNote")]
    public class EditNote : Activity
    {
        public long NoteId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.editNoteLayout);
            var confirmEditButton = FindViewById<Button>(Resource.Id.confirmEdit_btn);

            NoteId = Intent.GetLongExtra("ID", 1);
            var NoteTitle = Intent.GetStringExtra("TITLE");
            var NoteContent = Intent.GetStringExtra("CONTENT");
          
            var EditNoteTitle = FindViewById<EditText>(Resource.Id.editNoteTitle);
            var EditNoteContent = FindViewById<EditText>(Resource.Id.editNoteContent);

            EditNoteTitle.Text= NoteTitle;
            EditNoteContent.Text = NoteContent;
            confirmEditButton.Click += (s, ea) =>
            {
                var noteTitle = EditNoteTitle.Text;
                var noteContent = EditNoteContent.Text;
                DatabaseService.DisplayEdit(NoteId, noteTitle, noteContent);
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                //var title = ;
                //var content = Intent.GetStringExtra("EditContent");
                //editingNoteId = Intent.GetLongExtra("NoteID", 1);
                //PresentNote(title, content);
            };

        }
    }
}