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
            var eventDataTable = helper.GetDataTable("GetEvents", CommandType.StoredProcedure);
            var events = new List<Event>();

            foreach (DataRow row in eventDataTable.Rows)
            {
                var eventInst = new Event
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    RecordId = Convert.ToInt32(row["RecordId"])
                };

                events.Add(eventInst);
            }

            return events;
        }

        public Event GetById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var eventDataTable = helper.GetDataTable("GetEventById", CommandType.StoredProcedure, parameters.ToArray());
            var events = new List<Event>();

            //make 1 return point
            if (eventDataTable.Rows.Count == 0)
            {
                return null;
            }

            var eventInst = new Event
            {
                Id = Convert.ToInt32(eventDataTable.Rows[0]["Id"]),
                Name = eventDataTable.Rows[0]["Name"].ToString(),
                RecordId = Convert.ToInt32(eventDataTable.Rows[0]["RecordId"])
            };

            return eventInst;
        }

        public IEnumerable<Event> GetEventsByRecordId(int recordId)
        {
            var eventDataTable = helper.GetDataTable("GetEvents", CommandType.StoredProcedure);
            var events = new List<Event>();

            foreach (DataRow row in eventDataTable.Rows)
            {
                var eventInst = new Event
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    RecordId = Convert.ToInt32(row["RecordId"])
                };
                if (eventInst.RecordId == recordId)
                {
                    events.Add(eventInst);
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
