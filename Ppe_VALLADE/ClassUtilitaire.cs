using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace Ppe_VALLADE
{
    public class DatabaseFormation
    {

        private MySqlConnection connexion;

        public void ConnectDB()
        {
            String connect = "Server='127.0.0.1'; User='root'; Password=''; Database='ppe_vallade'";

            connexion = new MySqlConnection(connect);
        }

        //ICI LES REQUETES SQL POUR RECUPERER FORMATION / SESSIONS / PARTICIPANT / CANDIDAT

        public List<Formation> MesFormations()
        {

            string Marequete = "SELECT * FROM FORMATION";
            connexion.Open();
            var formations = connexion.Query<Formation>(Marequete).ToList();
            connexion.Close();

            return formations;
        }

        public List<Session> MesSessions(String id_formation)
        {
            string StrQuery = "SELECT id, DateDebut, DateFin, Lieux FROM session WHERE Id_Formation = @idformation";
            var parameters = new DynamicParameters();
            parameters.Add("idformation", id_formation);
            connexion.Open();
            List<Session> sessions = connexion.Query<Session>(StrQuery, parameters).ToList();
            connexion.Close();
            return sessions;

        }

        public List<Participant> MesParticipants()
        {
            String Marequete = "SELECT * FROM PARTICIPANT";
            connexion.Open();
            var participants = connexion.Query<Participant>(Marequete).ToList();
            connexion.Close();

            return participants;

        }

        public List<Participant> MesInscrits(String masession)
        {

            String strQuery = "SELECT * FROM candidater WHERE id_session = @idSession";
            var parameters = new DynamicParameters();
            parameters.Add("idSession", masession);
            connexion.Open();
            List<Participant> inscrits = connexion.Query<Participant>(strQuery, parameters).ToList();
            connexion.Close();

            return inscrits;

        }

        public string Connexion(String ndc, String mdp)
        {

            String strQuery = "SELECT * FROM utilisateur WHERE ndc = @_ndc AND mdp = @_mdp";

            var parameters = new DynamicParameters();
            parameters.Add("_ndc", ndc);
            parameters.Add("_mdp", mdp);
            connexion.Open();
            dynamic maconnexion = connexion.Query<Utilisateur>(strQuery, parameters);
            connexion.Close();

            return maconnexion;

        }


    }

}
