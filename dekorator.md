# Dekorator — wzorzec, który ubiera obiekty jak cebulę

## Co to za wzorzec?
Dekorator (ang. Decorator) to taki wzorzec projektowy, który pozwala dokładać nowe funkcje do obiektu, bez zmieniania jego wnętrza.

Wyobraźmy sobie, że mamy zwykłą kawę. Chcemy dodać mleko, cukier i bitą śmietanę — ale nie chcemy robić osobnych klas dla każdej kombinacji. Z pomocą przychodzi dekorator.

## Problem: powiadomienia
Mamy klasę `Powiadamiacz`, która wysyła e-maile. Działa super... aż klient mówi:

„Chcemy też SMS-y, Slacka, Facebooka... i wszystko naraz!”

Próbujemy tworzyć klasy jak `PowiadamiaczSMS`, `PowiadamiaczSlack` itd., potem kombinacje typu `PowiadamiaczEmailSMS`. Z naszego kodu robi się z tego kombinacyjna tragedia.

## Rozwiązanie: dekorator
Zamiast pisać wiele podklas, opakowujemy jeden obiekt kolejnymi "nakładkami".

Każda „nakładka” (czyli dekorator):
- implementuje ten sam interfejs co `Powiadamiacz`
- robi coś swojego (np. wysyła SMS)
- przekazuje dalej – do następnego

Schemat:
```
[PowiadamiaczEmail]
     ↓
[SMSDekorator]
     ↓
[SlackDekorator]
```

Wysyłamy jedno powiadomienie, a ono leci wszystkimi kanałami.

## Jak to wygląda w kodzie?

### Interfejs bazowy
```csharp
public interface INotifier
{
    void Send(string message); // Wspólna metoda dla wszystkich powiadamiaczy
}
```

### Klasa podstawowa
```csharp
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"[Email] Wysłano wiadomość: {message}");
    }
}
```

### Dekorator bazowy
```csharp
public abstract class NotifierDecorator : INotifier
{
    protected INotifier wrappee;

    public NotifierDecorator(INotifier notifier)
    {
        wrappee = notifier; // Zapisujemy referencję do dekorowanego obiektu
    }

    public virtual void Send(string message)
    {
        wrappee.Send(message); // Domyślnie przekazujemy wywołanie dalej
    }
}
```

### Konkretne dekoratory
```csharp
public class SMSDecorator : NotifierDecorator
{
    public SMSDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        Console.WriteLine($"[SMS] Wysłano wiadomość: {message}");
        base.Send(message); // Wywołanie kolejnego dekoratora lub klasy bazowej
    }
}

public class SlackDecorator : NotifierDecorator
{
    public SlackDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        Console.WriteLine($"[Slack] Wysłano wiadomość: {message}");
        base.Send(message);
    }
}
```

### Kod klienta
```csharp
class Program
{
    static void Main()
    {
        INotifier notifier = new EmailNotifier(); // Bazowy powiadamiacz
        notifier = new SMSDecorator(notifier);    // Dodajemy SMS
        notifier = new SlackDecorator(notifier);  // Dodajemy Slack

        notifier.Send("Pożar w serwerowni!");
    }
}
```

### Wynik działania:
```
[Slack] Wysłano wiadomość: Pożar w serwerowni!
[SMS] Wysłano wiadomość: Pożar w serwerowni!
[Email] Wysłano wiadomość: Pożar w serwerowni!
```

## Diagram UML

Diagram pokazuje strukturę klas we wzorcu Dekorator:

- `INotifier` to wspólny interfejs, który implementują wszystkie klasy.
- `EmailNotifier` to podstawowa implementacja – wysyła e-maile.
- `NotifierDecorator` to klasa bazowa dla dekoratorów, zawiera referencję do innego obiektu `INotifier`.
- `SMSDecorator` i `SlackDecorator` rozszerzają `NotifierDecorator` i dodają nowe zachowanie.

Strzałki oznaczają dziedziczenie (lub implementację interfejsu), a pole `wrappee` w dekoratorze to mechanizm delegowania działania.

```
          +------------------+
          |   INotifier      |<--------------------------+
          +------------------+                           |
          | + Send(msg)      |                           |
          +------------------+                           |
                    ^                                     |
          +---------+----------+                +--------+---------+
          |  EmailNotifier     |                | NotifierDecorator |
          +-------------------+                +-------------------+
          | + Send(msg)       |                | - wrappee:INotifier|
          +-------------------+                | + Send(msg)        |
                                               +--------+----------+
                                                        ^
                                     +------------------+------------------+
                                     |                                     |
                         +-----------+----------+              +----------+---------+
                         |     SMSDecorator     |              |   SlackDecorator   |
                         +----------------------+              +--------------------+
                         | + Send(msg)          |              | + Send(msg)        |
                         +----------------------+              +--------------------+
```

## Po co nam to?
- Dodajemy funkcje bez ruszania istniejącego kodu
- Działa w czasie działania programu (runtime) – możemy zmieniać kombinacje dynamicznie
- Możemy dowolnie mieszać warstwy – kompresja, szyfrowanie, logowanie

## Przykład z życia
Czujemy chłód → zakładamy sweter  
Pada deszcz → dorzucamy płaszcz  
Wieje wiatr → dokładamy kaptur  

To nadal my, tylko z warstwami ubrań. Tak samo działa obiekt z dekoratorami.

## Kiedy używać?
- Gdy chcemy rozszerzyć obiekt bez dziedziczenia
- Gdy mamy zbyt dużo kombinacji klas
- Gdy potrzebujemy warstwowej logiki (np. logowanie → szyfrowanie → kompresja)

## Uwaga
Nie przesadzajmy – zbyt wiele warstw dekoratorów może być trudne do ogarnięcia. Debugowanie też robi się jak labirynt.

## Podsumowanie
Dekorator to wzorzec, który ubiera obiekty w nowe funkcje, jak cebula warstwy.

Nie musimy przerabiać klas ani kombinować z dziedziczeniem. Bierzemy bazowy obiekt, owijamy go dekoratorami – i gotowe. Idealne do powiadomień, formatowania, strumieni danych i... kawy z mlekiem.
