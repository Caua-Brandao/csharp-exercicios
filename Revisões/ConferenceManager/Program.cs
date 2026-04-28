using ConferenceManager.Entities;
using ConferenceManager.Entities.Exceptions;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== EVENT MANAGER SYSTEM ===");

        // Criando eventos
        Event techConf = new Event("Tech Conference 2026",
            new DateTime(2026, 6, 1),
            new DateTime(2026, 6, 3),
            100);

        Event businessSummit = new Event("Business Summit 2026",
            new DateTime(2026, 7, 10),
            new DateTime(2026, 7, 12),
            200);

        Event aiWorkshop = new Event("AI Workshop 2026",
            new DateTime(2026, 5, 20),
            new DateTime(2026, 5, 20),
            30);

        Console.WriteLine("✓ Eventos criados com sucesso!\n");

        // Criando EventManager
        EventManager manager = new EventManager();
        manager.AddEvent(techConf);
        manager.AddEvent(businessSummit);
        manager.AddEvent(aiWorkshop);

        // Adicionando participantes
        techConf.AddParticipant(new Speaker("Dr. John Smith", "john@email.com", "Artificial Intelligence", 5000));
        techConf.AddParticipant(new Attendee("Maria Santos", "maria@email.com", "Student"));
        techConf.AddParticipant(new Attendee("Carlos Silva", "carlos@email.com", "Professional"));
        techConf.AddParticipant(new Organizer("Ana Costa", "ana@email.com", "Event Coordinator"));

        businessSummit.AddParticipant(new Attendee("Pedro Lima", "pedro@email.com", "Professional"));
        businessSummit.AddParticipant(new Attendee("Julia Souza", "julia@email.com", "Student"));

        aiWorkshop.AddParticipant(new Attendee("Lucas Rocha", "lucas@email.com", "Other"));

        // Testando listagens
        Console.WriteLine("\n=== PARTICIPANTES DO TECH CONF ===");
        techConf.ListAllParticipants();

        // Testando resumo
        Console.WriteLine("\n=== EVENT SUMMARY ===");
        Console.WriteLine(techConf.GetEventSummary());

        // Testando exceções
        Console.WriteLine("\nTentando adicionar participante duplicado...");
        try
        {
            techConf.AddParticipant(new Speaker("Dr. John Smith", "john@email.com", "AI", 5000));
        }
        catch (EventException ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }

        Console.WriteLine("\nTentando iniciar evento antes da data...");
        try
        {
            techConf.StartEvent();
        }
        catch (EventException ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }

        try
        {
            techConf.CloseEvent();
            Console.WriteLine("✓ Evento encerrado com sucesso!");
        }
        catch (EventException ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }

        // Testando EventManager
        Console.WriteLine("\n=== TODOS OS EVENTOS ===");
        manager.ListAllEvents();

        Console.WriteLine("\n=== EVENTOS POR STATUS (Planned) ===");
        manager.ListEventsbyStatus(EventStatus.Planned);

        Console.WriteLine("\n=== TOTAL ACROSS ALL EVENTS ===");
        Console.WriteLine($"Total Participants: {manager.GetTotalParticipants()}");
        Console.WriteLine($"Total Revenue: R$ {manager.GetTotalRevenue()}");
    }
}
