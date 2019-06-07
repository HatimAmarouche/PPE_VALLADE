using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using System.Configuration;
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

        //FORMATIONS
        public List<Formation> MesFormations()
        {

            string strQuery = "SELECT Id, Niveau, Nom FROM formation";
            connexion.Open();
            var formations = connexion.Query<Formation>(strQuery).ToList();
            connexion.Close();

            return formations;
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

        public void UpdateFormation(int id, int niveau, string nom)
        {
            String strQuery = "UPDATE formation SET niveau = @_niveau, nom = @_nom WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            parameters.Add("_ndc", niveau);
            parameters.Add("_level", nom);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

        public void SuppFormation(int id)
        {
            String strQuery = "DELETE FROM formation WHERE Id = @_id";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("_id", id);
            connexion.Open();
            connexion.Query(strQuery, dynamicParameters);
            connexion.Close();
        } 

            //SESSIONS
            public List<Session> MesSessions(String id_formation)
        {
            string StrQuery = "SELECT Id, DateDebut, DateFin, Id_Formation, Lieux FROM session WHERE Id_Formation = @idformation";
            var parameters = new DynamicParameters();
            parameters.Add("idformation", id_formation);
            connexion.Open();
            List<Session> sessions = connexion.Query<Session>(StrQuery, parameters).ToList();
            connexion.Close();
            return sessions;

        }

        public void CreateSession(DateTime Datedebut, DateTime DateFin, int idformation, string Lieu)
        {
            string StrQuery = "INSERT INTO session(id, DateDebut, DateFin, Id_Formation, Lieux) VALUES (NULL, @_datedebut, @_datefin, @_idformation, @_lieu)";
            var parameters = new DynamicParameters();
            parameters.Add("_datedebut", Datedebut);
            parameters.Add("_datefin", DateFin);
            parameters.Add("_idformation", idformation);
            parameters.Add("_lieu", Lieu);
            connexion.Open();
            connexion.Query<Session>(StrQuery, parameters).ToList();
            connexion.Close();
        }

        public void UpdateSession(int id, DateTime Datedebut, DateTime Datefin, string Lieu)
        {
            String strQuery = "UPDATE session SET DateDebut = @_datedebut, DateFin = @_datefin, Lieux = @_lieu WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            parameters.Add("_datedebut", Datedebut);
            parameters.Add("_datefin", Datefin);
            parameters.Add("_lieu", Lieu);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

        public void SuppSession(int id)
        {
            String strQuery = "DELETE FROM session WHERE Id = @_id";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("_id", id);
            connexion.Open();
            connexion.Query(strQuery, dynamicParameters);
            connexion.Close();
        }

            //PARTICIPANTS
            public List<Participant> MesParticipants()
        {
            String strQuery = "SELECT * FROM PARTICIPANT WHERE idsession IS NULL";
            connexion.Open();
            var participants = connexion.Query<Participant>(strQuery).ToList();
            connexion.Close();

            return participants;

        }


        public List<Participant> MesInscrits(String masession)
        {

            String strQuery = "SELECT * FROM participant WHERE idsession = @idSession";
            var parameters = new DynamicParameters();
            parameters.Add("idSession", masession);
            connexion.Open();
            List<Participant> inscrits = connexion.Query<Participant>(strQuery, parameters).ToList();
            connexion.Close();

            return inscrits;

        }

         public void CreateParticipant(string nom, string prenom, string numero)
       {
           String strQuery = "INSERT INTO participant(id, Nom, Prenom, idsession, Numero) VALUES (NULL, @_nom, @_prenom, NULL, @_numero)";
           var parameters = new DynamicParameters();
           parameters.Add("_nom", nom);
           parameters.Add("_prenom", prenom);
           parameters.Add("_numero", numero);
           connexion.Open();
           connexion.Query<Participant>(strQuery, parameters).ToList();
           connexion.Close();
       }

        public void UpdateIdSessionParticipant(int id)
        {
            String strQuery = "UPDATE participant SET idsession = NULL WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

        //UTILISATEUR
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

      

        public List<Utilisateur> Connexion(String ndc, String mdp)
        {

            List<Utilisateur> monutilisateur = new List<Utilisateur>();
            String strQuery = "SELECT id, ndc, mdp, level, date_co, nbtentative, etat FROM utilisateur WHERE ndc = @_ndc AND mdp = @_mdp";
            var parameters = new DynamicParameters();
            parameters.Add("_ndc", ndc);
            parameters.Add("_mdp", mdp);
            connexion.Open();
            monutilisateur = connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();

            return monutilisateur;
        }

        public void CreateUser(string ndc, string mdp, int level)
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

       public List<Utilisateur> NdcUtilisateur(string ndc)
        {
            connexion.Open();
            String strQuery = "SELECT * from utilisateur WHERE ndc  = @_ndc";
            var parameters = new DynamicParameters();
            parameters.Add("@_ndc", ndc);
            var monuser = connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();
            return monuser;


        }


        public void UpdateUser(int id,string ndc, int level, int etat)
        {
            String strQuery = "UPDATE utilisateur SET ndc = @_ndc, level = @_level, etat = @_etat WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            parameters.Add("_ndc", ndc);
            parameters.Add("_level", level);
            parameters.Add("_etat", etat);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }


        public void SuppUtilisateur(int id)
        {
            String strQuery = "DELETE FROM utilisateur WHERE Id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }
        public void IncrementationNbTentative(string ndc)
        {
            String strQuery = "UPDATE utilisateur SET nbtentative = nbtentative + 1 WHERE ndc = @_ndc";
            var parameters = new DynamicParameters();
            parameters.Add("_ndc", ndc);

            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

        public void InsertDateCo(int id, DateTime date_co)
        {
            String strQuery = "UPDATE utilisateur set date_co = @_date_co, nbtentative = 0 WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            parameters.Add("_date_co", date_co);
            connexion.Open();
            connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();
        }

        public void UpdateMdp(int id, string mdp)
        {
            String strQuery = "UPDATE utilisateur SET mdp = @_mdp WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            parameters.Add("_mdp", mdp);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

        public void UpdateEtat(int id, int etat)
        {
            String strQuery = "UPDATE utilisateur SET etat = @_etat WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            parameters.Add("_etat", etat);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

        //SOUHAIT

        public List<Souhait> MesSouhaits()
        {

            String strQuery = "SELECT * FROM souhait WHERE accepter = 0";
            connexion.Open();
            var souhaits = connexion.Query<Souhait>(strQuery).ToList();
            connexion.Close();
            return souhaits;

        }
       public void InsertSouhait(int id_participant, int id_session)
        {
            String strQuery = "INSERT INTO souhait(id, id_participant, id_session, accepter) VALUES (NULL, @_id_participant, @_id_session, 0)";
            var parameters = new DynamicParameters();
            parameters.Add("_id_participant", id_participant);
            parameters.Add("_id_session", id_session);
            connexion.Open();
            connexion.Query<Utilisateur>(strQuery, parameters).ToList();
            connexion.Close();
        }

        public void SuppSouhait(int id_participant)
        {
            String strQuery = "DELETE FROM souhait WHERE id_participant = @_id_participant";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("_id_participant", id_participant);
            connexion.Open();
            connexion.Query(strQuery, dynamicParameters);
            connexion.Close();
        }

        public void UpdateSouhait(int id)
        {
            String strQuery = "UPDATE souhait SET accepter = 1 WHERE id = @_id";
            var parameters = new DynamicParameters();
            parameters.Add("_id", id);
            connexion.Open();
            connexion.Query(strQuery, parameters);
            connexion.Close();
        }

       



        //PROCEDURES STOCKEES

        public void RenseignerIdSession(int idparticipant, int idsession)
        {
            using(MySqlCommand cmd = new MySqlCommand("RenseignerIdSession", connexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("?id_participant", idparticipant);
                cmd.Parameters["?id_participant"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("?id_session", idsession);
                cmd.Parameters["?id_session"].Direction = ParameterDirection.Input;

                connexion.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                connexion.Close();
            }
        }


    }

}
