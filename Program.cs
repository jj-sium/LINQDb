using SQLite;

// 27/4/2023

Console.WriteLine("Hello, DBWorld!");
// Connessione al db
SQLiteConnection cn1 = new SQLiteConnection("chinook.db");
var tblArtists = cn1.Query<Artist>("select * from artists");
Console.WriteLine($"In questa tabella ci sono {tblArtists.Count} record!");

// Language INtegrate Query
// LINQ

// 4/5/2023
/*
non va bene
int x = 0;
Artist[] vect = new Artist[tblArtists.Count];
while( x < tblArtists.Count )
{
    vect[x] = tblArtists[x].Name;
    x++;
}
*/
var temporanea = tblArtists.OrderByDescending(x => x.Name);
tblArtists = temporanea.ToList(); // => è una landa expression

/* fluent - puoi aggiungere i metodi all'infinito perchè 
dopo la creazione di uno si genera una sorte di lista
esempio del libro che con i metodi riesci a dare un ordine
Comandi tipo al posto di .ToList:
As.Parallel - Distinct - First - Last - Max - Min
per far eseguire la media, la somma e tutte le funzioni metti sotto al foreach 
Console.WriteLine($"{temporanea}");

*/
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