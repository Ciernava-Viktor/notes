using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dědičnost_a_polymorfismus_csharp
{
    internal class Poznamka
    {
        public string nID { get; protected set; } = Guid.NewGuid().ToString();
        public string Nadpis { get; protected set; } = "Untitled";
        public string Obsah { get; protected set; } = "";

        public Poznamka() {}
        public Poznamka(string nId, string nadpis, string obsah)
        {
            nID = nId;
            Nadpis = nadpis;
            Obsah = obsah;
        }
    }

    internal class Poznamky : Poznamka
    {
        public List<Poznamka> listPoznamek = new List<Poznamka>();

        public Poznamky() {}
        public void VytvoritPozmanku()
        {
            Console.WriteLine($"Poznámka: {base.Nadpis} ({base.nID})");
            Console.Write("Napiš nadpis pro svou poznámku: ");
            string _nadpis = Console.ReadLine();
            Console.Write("Napiš obsah pro svou poznámku: ");
            string _obsah = Console.ReadLine();
            
            listPoznamek.Add(new Poznamka(base.nID, _nadpis, _obsah));
        }

        public void VypisPoznamek()
        {
            listPoznamek.ForEach(poznamka =>
            {
                Console.WriteLine($"\n{poznamka.nID}\n");
            });
        }
    }
}