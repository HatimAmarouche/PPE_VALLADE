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

        private int _Id;
        private DateTime _DateDebut;
        private DateTime _DateFin;
        private string _Lieu;
        private Formation _LaFormation;
        private List<Participant> _LesParticipants;

        public int id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }
        public DateTime datedebut
        {
            get
            {
                return _DateDebut;

            }
            set
            {
                _DateDebut = value;
            }
        }

        public DateTime datefin
        {
            get
            {
                return _DateFin;

            }
            set
            {
                _DateFin = value;
            }
        }

        public string lieu
        {
            get
            {
                return _Lieu;

            }
            set
            {
                _Lieu = value;
            }
        }

        public Session(int Id, DateTime DateDebut, DateTime DateFin, string Lieux)
        {
            _Id = Id;
            _DateDebut = DateDebut;
            _DateFin = DateFin;
            _Lieu = Lieux;
        }
        public Formation LaFormation { get; set; }
        public List<Participant> LesParticipants { get; set; }
    }

    public class Formation
    {

        private int _id;
        private string _Nom;
        private int _Niveau;
        private List<Session> lesSessions = new List<Session>();



        public int id { get; set; }
        public string Nom { get; set; }
        public int Niveau { get; set; }
        public Session LesSessions { get; set; }

    }

    public class Participant
    {

        private int _id;
        private string _Nom;
        private string _Prenom;
        private Session _LaSessionChoisie;

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Session LaSessionChoisie { get; set; }
    }

    public class Utilisateur
    {
        private int _id;
        private string _ndc;
        private string _mdp;
        private string level;

        public int Id { get; set; }
        public string Ndc { get; set; }
        public string Mdp { get; set; }
        public string Level { get; set; }


    }

}



   




