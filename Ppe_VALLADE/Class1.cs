using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;


namespace Ppe_VALLADE
{

    public class Session
    {

        private int id;
        private DateTime dateDebut;
        private DateTime dateFin;
        private string lieu;
        private Formation laFormation;
        private List<Participant> lesParticipants;

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

        public Session(int Id, DateTime DateDebut, DateTime DateFin, string Lieux)
        {
            id = Id;
            dateDebut = DateDebut;
            dateFin = DateFin;
            lieu = Lieux;
        }

     
        public Formation LaFormation { get; set; }
        public List<Participant> LesParticipants { get; set; }
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

        public Participant(int Id, string Nom, string Prenom, int Idsession)
        {
            id = Id;
            nom = Nom;
            prenom = Prenom;
            idsession = Idsession;
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


        public Utilisateur(int Id, string Ndc, string Mdp, int Level, DateTime Date_co, int Nbtentative)
        {
            id = Id;
            ndc = Ndc;
            mdp = Mdp;
            level = Level;
            date_co = Date_co;
            nbtentative = Nbtentative;
        }

        public Utilisateur()
        {

        }

        

    }

    public class Incident
    {
        private int _id;
        private DateTime _date_incident;
        private string _resolu;
        private string _description;

        
        public int Id { get; set; }
        public DateTime Date_incident { get; set; }
        private string Resolu { get; set; }
        private string Description { get; set; }

    }

    public class Tentative
    {
        private int _id;
        private int _id_user;
        private DateTime _date_tentative;

        public int Id { get; set; }
        public int Id_user { get; set; }
        public int Date_tentative { get; set; }
    }



}



   




