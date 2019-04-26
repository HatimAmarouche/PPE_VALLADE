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

            string strQuery = "SELECT Id, Niveau, Nom FROM formation";
            connexion.Open();
            var formations = connexion.Query<Formation>(strQuery).ToList();
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
            String strQuery = "SELECT * FROM PARTICIPANT";
            connexion.Open();
            var participants = connexion.Query<Participant>(strQuery).ToList();
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

        public List<Utilisateur> MesUtilisateurs()
        {
            String strQuery = "SELECT * FROM utilisateur";
            connexion.Open();
            var utilisateurs = connexion.Query<Utilisateur>(strQuery).ToList();
            connexion.Close();

            return utilisateurs;

        }


        /*     public List<Incident> MesIncidents()
             {
                 String strQuery = "SELECT id, resolu, date_incident, description FROM incident";
                 connexion.Open();
                 var incidents = connexion.Query<Incident>(strQuery).ToList();
                 connexion.Close();
                 return incidents;
             } */



        public string Connexion(String ndc, String mdp)
        {

            String strQuery = "SELECT id, ndc, mdp, level FROM utilisateur WHERE ndc = @_ndc AND mdp = @_mdp";

            var parameters = new DynamicParameters();
            parameters.Add("_ndc", ndc);
            parameters.Add("_mdp", mdp);
            connexion.Open();
            dynamic maconnexion = connexion.Query<Utilisateur>(strQuery, parameters);
            connexion.Close();

            if (maconnexion != null)
            {
                return maconnexion[0].level;
            }

            else
            {
                return "Connexion échouée";
            }

        }

        public void CreateUser(string ndc, string mdp, string level)
        {
            String strQuery = "INSERT INTO utilisateur(id, ndc, mdp, level) VALUES (NULL, @_ndc, @_mdp, @_level)";
            var parameters = new DynamicParameters();
            parameters.Add("_ndc", ndc);
            parameters.Add("_mdp", mdp);
            parameters.Add("_level", level);
            connexion.Open();
            connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();
        }

        public void CreateParticipant(string nom, string prenom)
        {
            String strQuery = "INSERT INTO participant(id, nom, prenom) VALUES (NULL, @_nom, @_prenom)";
            var parameters = new DynamicParameters();
            parameters.Add("_nom", nom);
            parameters.Add("_prenom", prenom);
            connexion.Open();
            connexion.Query<Participant>(strQuery, parameters).ToList();
            connexion.Close();
        }

        public void CreateFormation(int niveau, string nom)
        {
            String strQuery = "INSERT INTO formation(id, niveau, nom) VALUES (NULL, @_niveau, @_nom)";
            var parameters = new DynamicParameters();
            parameters.Add("_niveau", niveau);
            parameters.Add("_nom", nom);
            connexion.Open();
            connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();
        }

        public List<Utilisateur> NdcUtilisateur(string ndc)
        {
            connexion.Open();
            String strQuery = "select * from utilisateur where ndc  = @_ndc";
            var parameters = new DynamicParameters();
            parameters.Add("@_ndc", ndc);
            var monuser = connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();
            return monuser;


        }

    }

}
