using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using SQLite;
using Android.Widget;
using System.IO;

namespace Noted
{
    class DatabaseService
    {
        static SQLiteConnection db;
        public static void CreateDatabase()
        {

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase.db3");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Note>();
        }

        public static void CreateTableWithData()
        {
            db.CreateTable<Note>();
        }

        public static void AddNote(string title, string content)
        {
            var newNote = new Note();
            newNote.NoteTitle = title;
            newNote.NoteContent = content;
            newNote.PostTime = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            db.Insert(newNote);
        }

        public static void DisplayEdit(long NoteId, string NoteTitle,string NoteContent)
        {
            var editedNote = new Note();
            editedNote.NoteTitle = NoteTitle;
            editedNote.NoteContent = NoteContent;
            editedNote.Id = NoteId;
            editedNote.PostTime = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            db.Update(editedNote);
        }

        public static void DeleteNote(long id)
        {
            db.Delete<Note>(id);
        }

        public static TableQuery<Note> GetAllNotes()
        {
            var table = db.Table<Note>();
            return table;
        }
    }
}