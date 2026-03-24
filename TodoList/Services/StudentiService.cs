using TodoList.Models;
using System.Linq;

namespace TodoList.Services;

public class StudentiService
{
    private readonly List<Studenti> _students = new();

    public event Action? OnChange;

    public StudentiService()
    {
        // initial sample data
        _students.Add(new Studenti { StudenteId = 1, Nome = "Maianna", Cognome = "Ricci", Email = "m.ricci@gmail.com", DataNascita = new DateOnly(1987, 2, 5) });
        _students.Add(new Studenti { StudenteId = 2, Nome = "Luca", Cognome = "Bianchi", Email = "l.bianchi@example.com", DataNascita = new DateOnly(1992, 7, 18) });
        _students.Add(new Studenti { StudenteId = 3, Nome = "Giulia", Cognome = "Verdi", Email = "g.verdi@example.com", DataNascita = new DateOnly(1995, 11, 2) });
        _students.Add(new Studenti { StudenteId = 4, Nome = "Matteo", Cognome = "Russo", Email = "m.russo@example.com", DataNascita = new DateOnly(2000, 5, 9) });
        _students.Add(new Studenti { StudenteId = 5, Nome = "Sara", Cognome = "Conti", Email = "s.conti@example.com", DataNascita = new DateOnly(1989, 3, 22) });
    }

    public IReadOnlyList<Studenti> GetAll() => _students.AsReadOnly();

    public void Add(Studenti studente)
    {
        studente.StudenteId = _students.Any() ? _students.Max(x => x.StudenteId) + 1 : 1;
        _students.Add(studente);
        NotifyStateChanged();
    }

    public void Remove(int id)
    {
        var item = _students.FirstOrDefault(x => x.StudenteId == id);
        if (item != null)
        {
            _students.Remove(item);
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
