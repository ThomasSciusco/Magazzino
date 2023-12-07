using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazzino
{
    public class Articolo
{
    public string Codice { get; set; }
    public string Descrizione { get; set; }
    public decimal Prezzo { get; set; }
    public decimal Sconto { get; set; }

    public Articolo(string codice, string descrizione, decimal prezzo)
    {
        Codice = codice;
        Descrizione = descrizione;
        Prezzo = prezzo;
        Sconto = 0;
    }

    public virtual void Sconta()
    {
        if (Sconto == 0)
        {
            Sconto = 5;
        }
    }
}

public class ArticoloAlimentare : Articolo
{
    public int AnnoScadenza { get; set; }

    public ArticoloAlimentare(string codice, string descrizione, decimal prezzo, int annoScadenza) : base(codice, descrizione, prezzo)
    {
        AnnoScadenza = annoScadenza;
    }

    public override void Sconta()
    {
        base.Sconta();

        if (AnnoScadenza == DateTime.Now.Year)
        {
            Sconto += 20;
        }
    }
}

public class ArticoloNonAlimentare : Articolo
{
    public string Materiale { get; set; }
    public bool Riciclabile { get; set; }

    public ArticoloNonAlimentare(string codice, string descrizione, decimal prezzo, string materiale, bool riciclabile) : base(codice, descrizione, prezzo)
    {
        Materiale = materiale;
        Riciclabile = riciclabile;
    }

    public override void Sconta()
    {
        base.Sconta();

        if (Riciclabile)
        {
            Sconto += 10;
        }
    }
}

public class AlimentareFresco : ArticoloAlimentare
{
    public int GiorniConsumo { get; set; }

    public AlimentareFresco(string codice, string descrizione, decimal prezzo, int annoScadenza, int giorniConsumo) : base(codice, descrizione, prezzo, annoScadenza)
    {
        GiorniConsumo = giorniConsumo;
    }

    public override void Sconta()
    {
        base.Sconta();

        int giorniRimanenti = 5 - GiorniConsumo;
        if (giorniRimanenti >= 1 && giorniRimanenti <= 5)
        {
            Sconto += giorniRimanenti * 2;
        }
    }
}
}
