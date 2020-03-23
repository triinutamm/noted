using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using static Android.Widget.AdapterView;

namespace Noted
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var noteListView = FindViewById<ListView>(Resource.Id.listView);
            var addNoteButton = FindViewById<Button>(Resource.Id.addNote_btn);
            var editNoteButton = FindViewById<Button>(Resource.Id.editNote_btn);
            var deleteNoteButton = FindViewById<Button>(Resource.Id.deleteNote_btn);

            DatabaseService.CreateDatabase();
            DatabaseService.CreateTableWithData();
            var notes = DatabaseService.GetAllNotes();

            noteListView.Adapter = new CustomAdapter(this, notes.ToList());

            addNoteButton.Click += (s, e) =>
            {
                var intent = new Intent(this, typeof(AddNote));
                StartActivity(intent);
            };

            noteListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var noteID = notes.ToList()[e.Position];
  
                editNoteButton.Click += (s, ea) =>
                {
                    long longid = noteID.Id;
                    var intent = new Intent(this, typeof(EditNote));
                    intent.PutExtra("ID", longid);
                    intent.PutExtra("TITLE", noteID.NoteTitle);
                    intent.PutExtra("CONTENT", noteID.NoteContent);
                    StartActivity(intent);
                };

                deleteNoteButton.Click += (s, ea) =>
                {
                        DatabaseService.DeleteNote(noteID.Id);

                        notes = DatabaseService.GetAllNotes();
                        noteListView.Adapter = new CustomAdapter(this, notes.ToList());               
                };
            };
        }
    }
}