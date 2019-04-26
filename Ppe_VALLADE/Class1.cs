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
        private Session laSessionChoisie;

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Session LaSessionChoisie { get; set; }

        public Participant(int Id, string Nom, string Prenom)
        {
            id = Id;
            nom = Nom;
            prenom = Prenom;
        }
    }

    public class Utilisateur
    {
        private int id;
        private string ndc;
        private string mdp;
        private string level;

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
     
        public string Level
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


        public Utilisateur(int Id, string Ndc, string Mdp, string Level)
        {
            id = Id;
            ndc = Ndc;
            mdp = Mdp;
            level = Level;
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



}



   




