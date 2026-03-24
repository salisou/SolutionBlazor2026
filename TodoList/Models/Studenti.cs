namespace TodoList.Models
{
    public class Studenti
    {
        public int StudenteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DataNascita { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int Eta {get;set;}

    }
}
