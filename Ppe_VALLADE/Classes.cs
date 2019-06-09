using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;


namespace Ppe_VALLADE
{

    public class Session
    {

        private int id;
        private DateTime dateDebut;
        private DateTime dateFin;
        private string lieu;
        private int idformation;
        

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public DateTime Datedebut
        {
            get
            {
                return dateDebut;

            }
            set
            {
                dateDebut = value;
            }
        }

        public DateTime Datefin
        {
            get
            {
                return dateFin;

            }
            set
            {
                dateFin = value;
            }
        }

        public string Lieu
        {
            get
            {
                return lieu;

            }
            set
            {
                lieu = value;
            }
        }

        public int Id_Formation
        {
            get
            {
                return idformation;
            }

            set
            {
                idformation = value;
            }
        }

        public Session(int Id, DateTime DateDebut, DateTime DateFin, int Id_Formation, string Lieux)
        {
            id = Id;
            dateDebut = DateDebut;
            dateFin = DateFin;
            idformation = Id_Formation;
            lieu = Lieux;
         
        }

     

    }

    public class Formation
    {

  
        private int id;
        private string nom;
        private int niveau;
        private List<Session> lesSessions = new List<Session>();

        
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }
        public int Niveau
        {
            get
            {
                return niveau;
            }

            set
            {
                niveau = value;
            }
        }
        public Session LesSessions { get; set; }

        public Formation(int Id, int Niveau, string Nom)
        {
            id = Id;
            niveau = Niveau;
            nom = Nom;
        }

    }

    public class Participant
    {

        private int id;
        private string nom;
        private string prenom;
        private int idsession;
        private string numero;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public int IdSession
        {
            get
            {
                return idsession;
            }

            set
            {
                idsession = value;
            }
        }

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public Participant(int Id, string Nom, string Prenom, int Idsession, string Numero)
        {
            id = Id;
            nom = Nom;
            prenom = Prenom;
            idsession = Idsession;
            numero = Numero;
        }
    }

    public class Utilisateur
    {
        private int id;
        private string ndc;
        private string mdp;
        private int level;
        private DateTime date_co;
        private int nbtentative;
        private int etat;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public string Ndc
        {
            get
            {
                return ndc;
            }

            set
            {
                ndc = value;
            }
        }

        public string Mdp
        {
            get
            {
                return mdp;
            }

            set
            {
                mdp = value;
            }
        }
     
        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }
        public DateTime Date_co
        {
            get
            {
                return date_co;
            }

            set
            {
                date_co = value;
            }
        }

        public int Nbtentative
        {
            get
            {
                return nbtentative;
            }

            set
            {
                nbtentative = value;
            }
        }

        public int Etat
        {
            get
            {
                return etat;
            }

            set
            {
                etat = value;
            }
        }


        public Utilisateur(int Id, string Ndc, string Mdp, int Level, DateTime Date_co, int Nbtentative, int etat)
        {
            id = Id;
            ndc = Ndc;
            mdp = Mdp;
            level = Level;
            date_co = Date_co;
            nbtentative = Nbtentative;
            etat = Etat;
        }

        public Utilisateur()
        {

        }

        

    }

    public static class Sms
    {
          public static void Send(String msg, String numero)
        {
            
            string sURL;
            sURL = "https://SMStoB.com/http.php?email=accueil@agecif.com&pass=ZJ3R2Z&numero=$$num$$&message=$$msg$$";
            sURL = sURL.Replace("$$num$$", numero);
            sURL = sURL.Replace("$$msg$$", msg);
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            WebResponse response = wrGETURL.GetResponse();
        }
    }

    public class Souhait
    {
        private int id;
        private int id_participant;
        private int id_session;
        private int accepter;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Id_participant
        {
            get
            {
                return id_participant;
            }

            set
            {
                id_participant = value;
            }
        }
        public int Id_session
        {
            get
            {
                return id_session;
            }

            set
            {
                id_session = value;
            }
        }

        public int Accepter
        {
            get
            {
                return accepter;
            }

            set
            {
                accepter = value;
            }
        }
    }



}



   




