using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoDB_Project
{
    internal class Note : Notepad
    {
        private string _topic;
        private string _entry;

        public Note(string topic, string entry)
        {
            _topic = topic;
            _entry = entry;
        }


        /// <summary>
        /// Returns the topic of the note.
        /// </summary>
        /// <returns></returns>
        public string FormatTopicNote()
        {
            string newFormat = $"       Topic: {_topic}";
            return newFormat;
        }


        /// <summary>
        /// Returns the user entry of the note.
        /// </summary>
        /// <returns></returns>
        public string FormatEntry() 
        {
            string newFormat = $"{_entry}";
            return newFormat;
        }
    }
}
