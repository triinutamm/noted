using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

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

            addNoteButton.Click += (s, e) =>
            {

                var intent = new Intent(this, typeof(AddNote));
                StartActivity(intent);
            };

            editNoteButton.Click += (s, e) =>
            {

                var intent = new Intent(this, typeof(EditNote));
                StartActivity(intent);
            };

            deleteNoteButton.Click += (s, e) =>
            {

            };
        }

    }
}