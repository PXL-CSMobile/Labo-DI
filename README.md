# Labo - Dependency Injection
## Intro
In dit labo bouwen we verder aan de TODO applicatie, gebruik makend van dependency injection.

## Deel 1
- Registreer het TodoListViewModel in de MauiProgram.cs klasse
- Injecteer de TodoListViewModel in de TodoListPage en gebruik deze als *BindingContext*

## Deel 2
- Maak een nieuwe folder aan: *Repositories*
- Maak een nieuwe klasse aan in deze folder: *TodoRepository*

```csharp
public class TodoRepository
{
    // Create fake data using Bogus data generator:
    // https://github.com/bchavez/Bogus
    private Faker<TodoItem> fake = new Faker<TodoItem>()
        .RuleFor(todo => todo.Title, (f, todo) => f.Lorem.Word())
        .RuleFor(todo => todo.Description, (f, todo) => f.Lorem.Sentence())
        .RuleFor(todo => todo.IsCompleted, (f, todo) => f.Random.Bool())
        .RuleFor(todo => todo.DueDate, (f, todo) => f.Date.Soon(7));

    public async Task<List<TodoItem>> GetTodoItems(int numberOfItems)
    {
        List<TodoItem> items = new List<TodoItem>();

        for (int i = 0; i < numberOfItems; i++)
        {
            items.Add(fake.Generate());
            await Task.Delay(10);
        }

        return items;
    }
}
```
- Registreer de TodoRepository in de MauiProgram.cs klasse
- Injecteer de TodoRepository in de TodoListViewModel en gebruik deze om de TodoItems op te halen
- Verwijder de volledige data folder

### Extra
- Maak een interface aan voor de TodoRepository en gebruik deze in de TodoListViewModel

## Deel 3
- Maak in de Pages folder een nieuwe *ContentPage* aan: *TodoDetailPage*
- Voorzie een bijhorend ViewModel: *TodoDetailViewModel* 
- Registreer beide in de MauiProgram.cs klasse en injecteer de *TodoDetailViewModel* in de *TodoDetailPage*
- Verwijder de *Entry* bovenaan in de *TodoListPage* en zorg dat de toevoegen-knop navigeert naar de *TodoDetailPage*
- Voorzie *Labels* en *Entries* voor alle properties van een TodoItem in de *TodoDetailPage* met onderaan een *Button*: "Toevoegen"
- Gebruik het *PubSub* pattern om een *message* te versturen wanneer op de "Toevoegen" knop wordt gedrukt
- Zorg dat de *TodoListViewModel* zich abonneert op deze *message* en een nieuwe TodoItem toevoegt aan de lijst

### Extra
- Refactor de TodoRepository zodat deze ook de mogelijkheid biedt om een TodoItem toe te voegen
- Verplaats de "navigatie-logica" naar een *[NavigationService](https://learn.microsoft.com/en-us/dotnet/architecture/maui/navigation)*