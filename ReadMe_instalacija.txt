Stvari potrebne za pokretanje projekta:

1. potrebno je imati instaliran .NET 5.0 SDK na svom računalu
    - ukoliko nemate, možete ga preuzeti na sljedećoj poveznici: https://dotnet.microsoft.com/en-us/download/dotnet/5.0
2. potrebno je imati instaliran Visual Studio ili Visual Studio Code na svom računalu
3. potrebno je imati instaliran SQL Server i Microsoft SQL Server Management Studio na svom računalu


Ukoliko imate sve potrebne programe instalirane, potrebno je pokrenuti SQL Server na svom računalu i importati bazu podataka "LutaliceInfoSustav.bacpac" (koju možete preuzeti na linku: https://github.com/zlopy99/Lutalice-Info), na način da kliknete desni klik na folder "Databases" i izaberete opciju "Import Data-tier Application", zatim kliknete "Next", te izaberete datoteku koju želite importati tj. datoteku "LutaliceInfoSustav.bacpac".
Ako želite možete promijeniti ime baze, zatim kliknuti "Next" pa "Finish"

Nakon što ste importali bazu na svoj lokalni SQL Server, potrebno je u projektu izmijeniti ConnectionStrings, kako bi se mogli povezati na bazu koju ste importali.
ConnectionStrings možete naći u datoteci "appsettings.json" (link: https://github.com/zlopy99/Lutalice-Info/blob/main/PIS_projekt/PIS_projekt/appsettings.json)

ConnectionStrings treba biti oblika:

"ConnectionStrings": {
    "DefaultConnection": "ImeVasegServera;Database=ImeBazePodatka;Trusted_Connection=true;MultipleActiveResultSets=True"
  },

ili

"ConnectionStrings": {
    "DefaultConnection": "Data Source=ImeVasegServera;Initial Catalog=ImeBazePodataka;Trusted_Connection=True"
  },


Nakon što ste ovo odradili trebali biste biti u mogućnosti pokrenuti aplikaciju putem Visual Studia ili Visual Studio Codea