using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;

namespace Week2.Giorno1.GestioneEsami.Core
{
    public interface IBusinessLayer
    {
        List<CorsoDiLaurea> FetchCorsiDiLaurea();
        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl);
        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl);
        bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s);
        public Esame AggiungiEsame(Esame esameDaSostenere);
        bool RandomEsamePassato(Esame esameDaSostenere,Studente s);
        public Studente AccediConNomeECognome(string nome, string cognome);
        bool ControllaEsame(Esame esameDaSostenere, Studente s);
    }
}
