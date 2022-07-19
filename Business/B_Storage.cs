using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class B_Storage
    {

        public static List<StorageEntity> StorageList()
        {
            using (var db = new InventaryContext())
            {
                return db.Storages.ToList();

            }
        }
        public static void CreateStorage(StorageEntity oStorage)
        {
            using (var db = new InventaryContext())
            {
                db.Storages.Add(oStorage);
                db.SaveChanges();

            }

        }
        public static bool IsProductInWarehouse(string idStorage)
        {
            using (var db = new InventaryContext())
            {
                var product = db.Storages.ToList()
                    .Where(s => s.StorageId == idStorage);

                var x = product.Any();
                return x;


            }
        }

        public static List<StorageEntity> StorageListByWarehouse(string idwarehouse)
        {
            using (var db = new InventaryContext())
            {
                return db.Storages
                    .Include(s=>s.Product)
                    .Include(s => s.Warehouse)
                    .Where(s=>s.WarehouseId== idwarehouse)
                    .ToList();

            }
        }
        public static void updateStorage(StorageEntity oStorage)
        {
            oStorage.LastUpdate = DateTime.Now;

            using (var db = new InventaryContext())
            {
                db.Storages.Update(oStorage);
                db.SaveChanges();

            }
        }

    }
}

