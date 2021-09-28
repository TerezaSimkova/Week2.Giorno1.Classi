using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Giorno1.GestioneEsami.Core.Entities;
using Week2.Giorno1.GestioneEsami.Core.RepositoryInterfaces;

namespace Week2.Giorno1.GestioneEsami.Core
{
    public class BusinessLayer : IBusinessLayer
    {

        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryCorsiLaurea corsiDiLaureaRepo;
        private readonly IRepositoryImmatricolazione immatricolazioneRepo;
        private readonly IRepositoryStudente studenteRepo;
        private readonly IRepositoryEsame esameRepo;
        //costruttore
        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiLaurea corsiLaurea, IRepositoryImmatricolazione immatricolazione, IRepositoryStudente studente, IRepositoryEsame repositoryEsame)
        {
            corsiRepo = corsi;
            corsiDiLaureaRepo = corsiLaurea;
            immatricolazioneRepo = immatricolazione;
            studenteRepo = studente;
            esameRepo = repositoryEsame;
        }

        public Studente AccediConNomeECognome(string nome, string cognome)
        {
            Studente studenteTrovato = studenteRepo.FetchByNomeECognome(nome, cognome);

            studenteTrovato._Immatricolazione = immatricolazioneRepo.FindImm(studenteTrovato._Immatricolazione.Id);
            studenteTrovato.Esami = esameRepo.GetEsamiStudente(studenteTrovato.Id);
            // if (studenteTrovato == null)
            // {
            //     Console.WriteLine("Studente con questo nome e cognome non esiste!");
            //     return false;
            // }
            //else
            // {

            //     return true;
            // }
            return studenteTrovato;
        }

        public Esame AggiungiEsame(Esame esameDaSostenere)
        {
            return esameRepo.AddToListEsami(esameDaSostenere);
        }

        public bool ControllaEsame(Esame esameDaSostenere, Studente s)
        {
            var esamiReccuperati = esameRepo.CheckEsameEsiste(esameDaSostenere);

            esamiReccuperati.Find(s => s.Nome == esameDaSostenere.Nome);

            foreach (var item in esamiReccuperati)
            {
                if (item.Nome == esameDaSostenere.Nome && item.Passato == true)
                {
                    return false; // TODO 
                }
            }
            return true;
        }

        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInizio = DateTime.Now;
            imm._corsoDiLaurea = GetCorsi(cdl);

            int ore = imm.DataInizio.Hour;
            int minuti = imm.DataInizio.Minute;
            var secondi = imm.DataInizio.Second;
            var matricola = String.Concat(ore, minuti, secondi);

            imm.Matricola = Convert.ToInt32(matricola);

            immatricolazioneRepo.Insert(imm);
            immatricolazioneRepo.GetIdByDate(imm);

            s.IdImmatricolazione = imm.Id;
            s._Immatricolazione = imm;

            studenteRepo.Insert(s);
            //get id e settarlo
            return s;
        }

        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRepo.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRepo.GetCorsiByCorsoDiLaurea(cdl);
            cdl.Corsi = corsi;
            var cfuTotali = corsi.Sum(c => c.CreditiFormativi);
            cdl.Cfu = cfuTotali;

            return cdl;
        }

        public bool RandomEsamePassato(Esame esameDaSostenere,Studente s)
        {
            List<Corso> corsi = corsiRepo.Fetch();
            var cfuPerCorso = 0;
            foreach (var c in corsi)
            {                
                if (c.Nome == esameDaSostenere.Nome)
                {
                    cfuPerCorso = c.CreditiFormativi;
                }
            }
            var si = s._Immatricolazione.CfuAccumulati += cfuPerCorso;
            if (si == s._Immatricolazione._corsoDiLaurea.Cfu)
            {
                s.LaureaRichiesta = true;
            }
            return true;
        }

  

        public bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s)
        {
            var cfuOk = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi <= s._Immatricolazione._corsoDiLaurea.Cfu;
            if (cfuOk && !s.LaureaRichiesta)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
