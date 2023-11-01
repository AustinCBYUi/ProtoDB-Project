using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project.src.Notepad
{
    /// <summary>
    /// Reference to a main notepad that stores multiple different notes.
    /// </summary>
    internal class Notepad
    {
        private string _notepadName;
        private List<Note> _notes = new List<Note>();

        public Notepad()
        {
        }

        Menu setColor = new Menu();


        /// <summary>
        /// Starts the Note/Notepad creation instance.
        /// </summary>
        public void Start(Notepad getPad)
        {
            setColor.WriteColor("Please type / to end the note.", ConsoleColor.Yellow);
            setColor.WriteColor("Continue your note until you move on to a different topic.\nType n to create a new note after your previous, ] to exit.", ConsoleColor.Cyan);
            setColor.WriteColor("Notepad Name: ", ConsoleColor.White);
            getPad._notepadName = Console.ReadLine();
            bool userQuit = false;
            while (userQuit != true)
            {
                Console.Write(@"
                n = New note
                e = Export notepad
                / = Exit Notes module
                ");
                string inputForSwitch = Console.ReadLine().ToLower();

                switch (inputForSwitch)
                {
                    case "n":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Topic: ");
                        string topic = Console.ReadLine();
                        Console.WriteLine("Entry: ");
                        string entry = Console.ReadLine();

                        Note newNote = new Note(topic, entry);
                        getPad.AddNoteToList(newNote);
                        break;
                    //Quit
                    case "/":
                        userQuit = true;
                        break;
                    case "e":
                        ExportNotepad(getPad);
                        break;
                }
            }

        }


        /// <summary>
        /// Adds note to the _notes list of Notes
        /// </summary>
        /// <param name="newNote">Individual note created by user.</param>
        protected void AddNoteToList(Note newNote)
        {
            _notes.Add(newNote);
        }


        /// <summary>
        /// Displays notes with no special format.
        /// </summary>
        /// <param name="getPad">Primary notepad manager as a param.</param>
        protected void ViewNotes(Notepad getPad)
        {
            foreach (Note note in _notes)
            {
                Console.WriteLine(note);
            }
        }


        /// <summary>
        /// Exports notes to a text file.
        /// </summary>
        /// <param name="getPad">Primary notepad manager as a param.</param>
        public void ExportNotepad(Notepad getPad)
        {
            try
            {
                using (StreamWriter output = new StreamWriter($"{_notepadName}.txt"))
                {
                    foreach (Note note in _notes)
                    {
                        output.WriteLine($">>> Notepad Name: {_notepadName} <<<");
                        output.WriteLine($"**Note Topic: {note.FormatTopicNote()}**");
                        output.WriteLine($"- {note.FormatEntry()}");
                        output.WriteLine("----------------------------------------------------");
                    }
                }
                setColor.WriteColor("Notes written!", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                setColor.WriteColor($"{ex.Message}", ConsoleColor.Red);
            }
        }
    }
}
