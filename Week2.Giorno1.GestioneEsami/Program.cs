using System;
using System.Collections.Generic;
using System.Linq;
using Week2.Giorno1.GestioneEsami.Core;
using Week2.Giorno1.GestioneEsami.Core.Entities;
using Week2.Giorno1.GestioneEsami.Mock;

namespace Week2.Giorno1.GestioneEsami
{
    class Program
    {
        //Creare una Console App che gestisca l’iscrizione ad un esame di uno Studente.

        //Lo studente è definito con:

        //• Nome ->stringa
        //• Cognome ->stringa
        //• AnnoDiNascita -> int
        //• Immatricolazione -> definita da un altra classe
        //• Esami -> List<corsi>
        //• RichiestaLaurea -> bool

        //L’immatricolazione ha le seguenti caratteristiche:

        //• Matricola -> int/string
        //• DataInizio -> DateTime
        //• CorsoDiLaurea -> un altra classe 
        //• FuoriCorso -> bool
        //• CFUAccumulati -> int

        //Un Corso di laurea è dato da un

        //Nome, ->string
        //AnniDiCorso, ->int
        //i cfu per ottenere la laurea e ->int
        //una lista di corsi
        //associati.


        //Un Corso ha un

        //nome -> string
        //e dei CFU. ->int

        //Un Esame si riferisce ad un corso e tiene conto se esso è stato passato.

        //I possibili nomi dei Corsi di Laurea possono essere solo i seguenti:
        //Matematica,
        //Fisica,
        //Informatica,
        //Ingegneria,
        //Lettere.

        //La matricola dello studente deve essere univoca, autogenerata e read-only.
        //Uno studente può richiedere un esame solo se esso è presente nel Corso di Laurea associato allo studente,
        //se i CFU del corso associato all’esame non superino i CFU massimi del Corso di laurea e se non ha il flag
        //RichiestaLaurea assegnato a vero.

        //Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla lista Esami.
        //Scrivere inoltre un metodo EsamePassato che, dato un esame, vada ad aggiornare i CFU accumulati dallo
        //studente, metta il flag Passato sull’esame e verifichi se con tale esame sono stati raggiunti i CFU necessari
        //per richiedere la laurea (e quindi metta il flag Richiestalaurea a true);

        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCorsi(), new RepositoryCorsiDiLaurea(),new RepositoryImmatricolazione(), new ReposiotryStudente(), new RepositoryEsame());
        static void Main(string[] args)
        {
            bool continua = true;
            int scelta;
            bool uscita = true;

            Studente s = new Studente();
            do
            {
                do
                {
                    Console.WriteLine("Scegli cose vuoi fare:");
                    Console.WriteLine("Premi 1 per immatricolarti");
                    Console.WriteLine("Premi 2 per accedere");
                    Console.WriteLine("Premi 3 per iscriverti ad un esame");
                    Console.WriteLine("Premi 0 per uscire");

                    continua = int.TryParse(Console.ReadLine(), out scelta);
                } while (!continua);


                switch (scelta)
                {
                    case 1:
                        s = Immatricolazione();
                        break;
                    case 2:
                        s = Accedi();
                        break;
                    case 3:
                        Iscriviti(s);
                        break;
                    case 0:
                        uscita = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non corretta!");
                        break;
                }
            } while (uscita);


        }

        private static Studente Accedi()
        {
            string nome;
            string cognome;
           
            Console.WriteLine("***Per accedere inserisce il tuo nome e cognome***\n");
            do
            {
                Console.WriteLine("Inserisci il nome:\n");
                nome = Console.ReadLine();
            } while (string.IsNullOrEmpty(nome));
            do
            {
                Console.WriteLine("Inserisci il cognome:\n");
                cognome = Console.ReadLine();
            } while (string.IsNullOrEmpty(cognome));

            var s = bl.AccediConNomeECognome(nome, cognome);

            return s;
        }

        private static void Iscriviti(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._corsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }
            string esame = String.Empty;
            Corso corsoScelto;
            do
            {
                Console.WriteLine("A quale esame vuoi iscriverti? ");
                esame = Console.ReadLine();
                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();

            } while (corsoScelto == null);

            bool possibileIscriversi = bl.VerificaCfuPerIscrizioneEsame(corsoScelto, s);
            if (possibileIscriversi)
            {
                Esame esameDaSostenere = new Esame();
                esameDaSostenere.Nome = corsoScelto.Nome;
                esameDaSostenere.Passato = false;
                esameDaSostenere.IdStudente = s.Id;

                esameDaSostenere = bl.AggiungiEsame(esameDaSostenere); //Insert + return con ID
                                                                       //passato di default = false
                bool esamePassato = bl.RandomEsamePassato(esameDaSostenere,s); //  0 o 1
                if (esamePassato)
                {
                    var controllo = bl.ControllaEsame(esameDaSostenere, s);

                    if (controllo == true)
                    {
                        esameDaSostenere.Passato = true;
                    }
                    
                }
            }          
        }

        private static Studente Immatricolazione()
        {

            string cognome;
            string nome;
            int annoNascita;

            bool continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo nome:");
                nome = Console.ReadLine();
                if (!string.IsNullOrEmpty(nome))
                {
                    continuare = false;
                }
            } while (continuare);

            continuare = true;
            do
            {
                Console.WriteLine("Inserisci il tuo cognome:");
                cognome = Console.ReadLine();
                if (!string.IsNullOrEmpty(cognome))
                {
                    continuare = false;
                }
            } while (continuare);

            continuare = true;
            do
            {
                Console.WriteLine("Inserisci anno di nascita:");
                continuare = int.TryParse(Console.ReadLine(), out annoNascita);

            } while (!continuare);

            Studente s = new Studente(nome, cognome, annoNascita);

            List<CorsoDiLaurea> corsiDiLaurea = bl.FetchCorsiDiLaurea();
            foreach (var c in corsiDiLaurea)
            {
                Console.WriteLine(c.Print());
            }

            var nomeCdl = Console.ReadLine();

            //passo intero corso di laurea percvhe sopra faccio gia fetch
            CorsoDiLaurea cdl = corsiDiLaurea.Where(c => c.Nome == nomeCdl).SingleOrDefault();

            //bl.GetCorsi(cdl); //potevo farlo anche cosi 

            s = bl.CreaImmatricolazione(s, cdl);
            return s;

        }
    }
}
