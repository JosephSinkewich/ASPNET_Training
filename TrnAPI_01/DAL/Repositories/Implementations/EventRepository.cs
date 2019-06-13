using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class EventRepository : IEventRepository
    {

        private ISQLHelper helper;

        public EventRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(Event item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", item.Name, DbType.String),
                helper.CreateParameter("@RecordId", item.RecordId, DbType.Int32)
            };

            helper.Insert("CreateEvent", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            helper.Delete("DeleteEvent", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Event> GetAll()
        {
            var events = new List<Event>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetEvents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var eventInst = new Event
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                RecordId = Convert.ToInt32(reader["RecordId"])
                            };

                            events.Add(eventInst);
                        }
                    }

                    reader.Close();
                }
            }

            return events;
        }

        public Event GetById(int id)
        {
            Event eventInst = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetEventById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        eventInst = new Event
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            RecordId = Convert.ToInt32(reader["RecordId"])
                        };
                    }

                    reader.Close();
                }
            }

            return eventInst;
        }

        public IEnumerable<Event> GetEventsByRecordId(int recordId)
        {
            var events = new List<Event>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetEventsByRecordId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var eventInst = new Event
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                RecordId = Convert.ToInt32(reader["RecordId"])
                            };

                            events.Add(eventInst);
                        }
                    }

                    reader.Close();
                }
            }

            return events;
        }

        public void Update(Event item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Name", item.Name, DbType.String),
                helper.CreateParameter("@RecordId", item.RecordId, DbType.String)
            };

            helper.Update("UpdateEvent", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
