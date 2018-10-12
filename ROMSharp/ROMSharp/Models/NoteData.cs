using System;
namespace ROMSharp.Models
{
    public class NoteData
    {
        /// <summary>
        /// Is the note data valid
        /// </summary>
        /// <value><c>true</c> if is valid; otherwise, <c>false</c>.</value>
        public bool IsValid { get; set; }

        /// <summary>
        /// The note's note type
        /// </summary>
        public Enums.NoteType NoteType { get; set; }

        /// <summary>
        /// The sender of the note
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// The date of the note
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// THe recipient list of the note
        /// </summary>
        public string ToList { get; set; }

        /// <summary>
        /// The subject of the note
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The body text of the note
        /// </summary>
        public string Text { get; set; }

        public NoteData()
        {
        }
    }
}
