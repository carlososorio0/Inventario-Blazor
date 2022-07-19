using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;
using System.Linq;

namespace Business
{
    public class B_InputOutput
    {

        public static List<InputOutputEntity> OutputList()
        {
            using (var db = new InventaryContext())
            {
                return db.InOuts.ToList();

            }
        }
        public static void CreateOutput(InputOutputEntity oOutput)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Add(oOutput);
                db.SaveChanges();

            }

        }
        public void updateOutput(InputOutputEntity oOutput)
        {
            using (var db = new InventaryContext())
            {
                db.InOuts.Add(oOutput);
                db.SaveChanges();

            }
        }

    }
}



