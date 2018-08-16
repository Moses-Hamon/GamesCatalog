using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SQLite;

namespace GamesCatalog
{
    public class Game
    {
        // add one property for each field in the table
        //spell them the same - not case sensitive
        public long Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public decimal Cost { get; set; }
        public DateTime Released { get; set; }

        public static List<Game> SelectAll()
        {
            //method is static because select all isn't specific to an instance.
            var query = "SELECT * FROM games";
            var db = Database.GetConnection();
            //adds entries from database to a list.
            return db.Query<Game>(query).ToList();
        }
        public static Game SelectOne(string id)
        {
            //this is a paramaterised query
            // query parameters are not treated as SQL syntax
            // this means if a user gives us poisoned SQL, it won't be executed.
            var query = "SELECT * FROM games WHERE id = @id";

            // when using a parameterised query with dapper, the convention is
            // to package the parameters into an anonymous object
            // make the query parameters have the same name as the variables with their date
            // eg, id is @id because it will be sourced from the if method argument.
            var param = new { id };
            var db = Database.GetConnection();
            //make sure all parameters are included.
            return db.QuerySingle<Game>(query, param);
        }

        public bool save()
        {
            if (Id == 0) return Insert();
            else return Update();
        }

        private bool Insert()
        {
            var query = "INSERT INTO games (name, platform, cost, released) VALUES (@Name, @Platform, @Cost, @Released)";
            var db = Database.GetConnection().OpenAndReturn();

            //start the database transaction like this
            var trans = db.BeginTransaction();
            var outcome = false;

            try
            {
                // if we supply the THIS keyword for the dapper parameter, it will
                // look to this instance for the parameters
                // and when you're in a transaction, you must also include the transaction
                // object, or it will crash.
                var results = db.Execute(query, this, trans);

                //what happened in the transaction won't be permanently saved in the database
                // until you COMMIT the transaction
                trans.Commit();

                //using this variable to say wether or not the operation worked.
                outcome = true;

                // LastInsertRowId will be the primary key generated for this record.
                this.Id = db.LastInsertRowId;
            }
            catch
            {
                //if the query fails, it will trigger an exception
                // the standard in this context is to roll back the transaction
                // (basically a big un-do)
                // when only running one query, the effect isn't huge - but running lots of
                // queries is where this shines
                trans.Rollback();
            }

            db.Close();
            return outcome;
        }

        private bool Update()
        {
            var query = "UPDATE games SET name=@Name, platform=@Platform, releasedate=@Released, cost=@Cost WHERE id=@Id";
            var db = Database.GetConnection();
            var trans = db.BeginTransaction();
            var outcome = false;
            try
            {
                db.Execute(query, this, trans);
                trans.Commit();
                outcome = true;
                //don't need to grab lastinsertrowid
            }
            catch
            {
                trans.Rollback();
            }
            db.Close();
            return outcome;
        }
    }
}