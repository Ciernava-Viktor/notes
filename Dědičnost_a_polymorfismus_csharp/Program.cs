using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dědičnost_a_polymorfismus_csharp
{
    internal class Note
    {
        public string noteID { get; private set; } = (Guid.NewGuid()).ToString();
        public string noteTitle { get; private set; } = "Untitled";
        public string noteText { get; private set; } = "";

        public Note() {}
        public Note(string title, string text)
        {
            noteTitle = title;
            noteText = text;
        }
        public Note(string ID, string title, string text)
        {
            noteID = ID;
            noteTitle = title;
            noteText = text;
        }
    }
    internal class Notes : Note
    {
        private readonly List<Note> notesList = new List<Note>();

        public Notes() { }

        public void TestNotes()
        {
            notesList.Add(new Note("0", "Test note", "This is test note"));
            notesList.Add(new Note("My first note", "This is my first cool note I wrote in my notebook"));
            notesList.Add(new Note("Second note", "This note is not as cool as the first one, but still works."));
        }

        public void createNote()
        {
            Console.WriteLine($"{base.noteTitle} ({base.noteID})");
            Console.WriteLine("- Please write title of your note:");
            string newNoteTitle = Console.ReadLine();
            Console.WriteLine("- Note text:");
            string newNoteText = Console.ReadLine();
            
            notesList.Add(new Note(base.noteID, newNoteTitle, newNoteText));
        }
        public void getNote(string noteID)
        {
            Note note = notesList.Find(n => n.noteID == noteID);
            if(note != null)
            {
                Console.WriteLine($"--------------- {note.noteTitle} ({note.noteID}) ------------------\n");
                Console.WriteLine($"{note.noteText}");
                Console.WriteLine("-------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine($"       I was not able to find note with id \"{noteID}\"");
                Console.WriteLine("-------------------------------------------------------------------");
            }
        }

        public void getNotes()
        {
            Console.WriteLine("------------------------ List of all notes ------------------------");
            notesList.ForEach(note =>
            {
                Console.WriteLine($"Title: {note.noteTitle}");
                Console.WriteLine($"ID: {note.noteID}");
                Console.WriteLine($"{note.noteText}");

                if(note != notesList.Last())
                {
                    Console.WriteLine("-----------------");
                }
            });
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            Notes notes = new Notes();
            
            notes.TestNotes();
            
            notes.getNote("2");
            
            notes.getNotes();
        }
    }
}