# LINQDb
## I passi per svolgere il programma LINQDb :
#### Il progetto di LINQDb è basato sul lavoro con il database per far leggere al nostro programma i nomi degli artisti in ordine decrescente.

#### 1) Creiamo la cartella nome.cognome.4h.LINQDb dove lavoreremo con il database.
#### 2) Aperta la cartella con visual studio, apriamo un nuovo terminale per creare un nuovo progetto. Inseriamo questo comando inziale sul terminale :
####
    dotnet new console

#### 3) Il progetto di LINQDb è basato sul lavoro col database. Avendo creato la cartella nome.cognome.4h.LINQDb e cercando chinook.db su google 
####
    https://www.sqlitetutorial.net

#### si può scaricare il database con cui possiamo lavorarci.
#### 4) Iniziamo a scrivere il programma con questo codice :
####
    using SQLite;

    Console.WriteLine("Hello, DBWorld!");
    // Connessione al db
    SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
    var tblArtists = cn1.Query<Artist>("select * from artists");
    Console.WriteLine($"In questa tabella ci sono {tblArtists.Count} record!");

#### 5) Verifichiamo se funziona il programma con un comando per il test sul terminale aperto prima :
####
    dotnet run

#### non funziona il programma e non legge il nostro database.
#### 6) Scarichiamo ora sul visual studio l'estensione SQLite per SQLiteConnection che dava errore al collegamento con la tabella artists.
#### Tabella artists :
![tabella artist](https://user-images.githubusercontent.com/116793076/236861408-d828a0fd-b18c-496c-911d-71087014319e.png)

#### 7) Andiamo sul terminale e scriviamo un nuovo comando:
####
      dotnet add package sqlite-net-pcl
      
#### Andando a vedere sul nome.cognome.4h.LINQDb.csproj, vediamo che si è aggiunto:
####
    <ItemGroup>
    <PackageReference Include="sqlite-net-pcl" Version="1.8.116" />
    </ItemGroup>
#### questo perchè abbiamo aggiunto l'estensione e dando il comando, rifacendo "dotnet run" vediamo che ora riesce a leggere i dati del nostro database.
#### 8) Adesso finiamo il nostro programma aggiungendo altra parte di codice :
#### 
     var temporanea = tblArtists.OrderByDescending(x => x.Name);
     tblArtists = temporanea.ToList(); // => è una landa expression

    foreach( var artista in tblArtists )
    {
      Console.WriteLine($"{artista.Name}");
    }
    //-------------
    public class Artist                 
    {
      public int ArtistId { get; set; } 
      public string Name { get; set; }
    }
#### ArtistId e Name sono gli attributi presi dalla classe Artist.
#### 9) Adesso rifacciamo il test sul terminale per vedere se il programma legge gli artisti sul database
#### 
    dotnet run
    
![programma funziona](https://user-images.githubusercontent.com/116793076/236860188-2446cc65-81f2-4941-83d2-f87d0e38a361.png)

#### Vediamo che il programma riesce a leggere gli artisti in ordine decrescente e l'obbiettivo è stato raggiunto con successo.
### Ti ringrazio se hai seguito la mia spiegazione.
## Programma scritto da Ghinelli Johan Valentino, alunno di Conti M. e Sartini M.
