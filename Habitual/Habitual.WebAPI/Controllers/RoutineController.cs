using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Habitual.Core.Entities;
using Habitual.WebAPI.Controllers;

namespace Habitual.WebAPI.Controllers
{
    [RoutePrefix("api/routine")]
    public class RoutineController : BaseController
    {
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateRoutine(string routineJson)
        {
            var routine = JsonConvert.DeserializeObject<Routine>(routineJson);
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();

                string rtn = "create_routine_procedure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", routine.ID);
                cmd.Parameters.AddWithValue("@description", routine.Description);
                cmd.Parameters.AddWithValue("@difficulty", routine.Difficulty.ToString());
                cmd.Parameters.AddWithValue("@username", routine.Username);

                cmd.ExecuteNonQuery();
                return base.BuildSuccessResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, "Error creating routine!");
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpDelete]
        [Route("delete/{routineId}")]
        public HttpResponseMessage DeleteRoutine(string routineId)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();

                string rtn = "delete_routine_procedure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", routineId);

                cmd.ExecuteNonQuery();
                return base.BuildSuccessResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, "Error deleting routine!");
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpGet]
        [Route("getall/{username}")]
        public HttpResponseMessage GetAllRoutines(string username)
        {
            var routineList = new List<Routine>();
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();

                string rtn = "get_all_routines_procedure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", username);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var routine = new Routine();
                    //routine.ID = Guid.Parse(reader.GetChar("id").ToString());
                    routine.ID = Guid.NewGuid();
                    routine.Description = reader.GetString("description");
                    routine.Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), reader.GetString("difficulty"));
                    routine.Username = reader.GetString("username");
                    routineList.Add(routine);
                    Console.Write("Got to here");
                }
                reader.Close();
                var json = JsonConvert.SerializeObject(routineList);
                return base.BuildSuccessResult(HttpStatusCode.OK, json);
            }
            catch (Exception ex)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, "Error getting all routines!");
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpGet]
        [Route("getalllogs/{id}/{dateString}")]
        public HttpResponseMessage GetAllRoutineLogs(string id, string dateString)
        { 
            var routineLogList = new List<RoutineLog>();
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();

                string rtn = "get_all_routine_logs_procedure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@dateRequested", dateString);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var routineLog = new RoutineLog();
                    //routineLog.ID = Guid.Parse(reader.GetChar("id").ToString());
                    routineLog.ID = Guid.NewGuid();
                    routineLog.Timestamp = reader.GetDateTime("time_stamp");
                    //routineLog.RoutineID = Guid.Parse(reader.GetChar("routine_id").ToString());
                    routineLog.RoutineID = Guid.NewGuid();
                    routineLogList.Add(routineLog);
                    Console.Write("Got to here");
                }
                reader.Close();
                var json = JsonConvert.SerializeObject(routineLogList);
                return base.BuildSuccessResult(HttpStatusCode.OK, json);
            }
            catch (Exception ex)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, "Error getting all routines!");
            }
            finally
            {
                conn.Close();
            }
        }

        [HttpPost]
        [Route("log")]
        public HttpResponseMessage Logroutine(RoutineLog routineLog)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            try
            {
                conn.Open();

                string rtn = "log_routine_procedure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", routineLog.ID);
                cmd.Parameters.AddWithValue("@routineId", routineLog.RoutineID);
                cmd.Parameters.AddWithValue("@routineTimeStamp", routineLog.Timestamp);


                cmd.ExecuteNonQuery();
                return base.BuildSuccessResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, "Error creating routine!");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

