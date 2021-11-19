using System.ComponentModel.DataAnnotations;

namespace NoteAPI.Models
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }
        public string NoteLine { get; set; }


    }
}