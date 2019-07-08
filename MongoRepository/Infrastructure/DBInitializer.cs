using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MongoRepository.Infrastructure.Configuration;
using MongoRepository.Infrastructure.Model;
using MongoRepository.Models;
using MongoDB.Driver;

namespace MongoRepository.Infrastructure
{
    public abstract class Initializer
    {
        private IContext context;

        public Initializer(IContext context)
        {
            this.context = context;
            CreateCollections();
        }

        private void CreateCollections()
        {
            var list = new Hierarchies2<IEntity>().Childs();
            foreach (var r in list)
            {
                string targetCollection = r;
                bool alreadyExists = context.database.ListCollections().ToList().Any(x => x.GetElement("name").Value.ToString() == targetCollection);

                if (!alreadyExists)
                {
                    context.database.CreateCollection(targetCollection);
                }
            }
        }

        public abstract void CreateIndex();

        public abstract void Seed();



        // {
        // var collection = new UnitOfWork().database.GetCollection<BsonDocument>(collectionName);

        /// collection.Indexes.CreateOne("index-text", new CreateIndexOptions() { Background = true, Sparse = true });

        // var index = Builders<Distributer>.IndexKeys.Geo2DSphere("Location");
        //   new UnitOfWork().database.GetCollection<Distributer>("Distributer").Indexes.CreateOne(index);

        // var notificationLogBuilder = Builders<Distributer>.IndexKeys;
        // var indexModel = new CreateIndexModel<Distributer>(notificationLogBuilder.Geo2DSphere(x => x.Location));
        // new UnitOfWork().database.GetCollection<Distributer>("Distributer").Indexes.CreateOneAsync(indexModel).ConfigureAwait(false);
        // }
    }

    public class DBInitializer : Initializer
    {
        public Context context;
        public DBInitializer(Context context)
            : base(context)
        {
            this.context = context;
        }

        public override void CreateIndex()
        {
            //var indexModel = new CreateIndexModel<Distributer>(Builders<Distributer>.IndexKeys.Geo2DSphere(x => x.Location));
            //new Context().database.GetCollection<Distributer>("Distributer").Indexes.CreateOneAsync(indexModel).ConfigureAwait(false);

            //  var l = context.database.GetCollection<Distributer>("Distributer").Indexes.t

            // context.database.GetCollection<Distributer>("Distributer")
        }

        public override void Seed()
        {
            //List<Brand> list = new List<Brand>();
            //Brand totalgas = new Brand();
            //totalgas.BrandID = 1;
            //totalgas.BrandName = "Total Gas";
            //list.Add(totalgas);

            //Brand titasGas = new Brand();
            //titasGas.BrandID = 2;
            //titasGas.BrandName = "Titas Gas";
            //list.Add(titasGas);

            //Brand basundhara = new Brand();
            //basundhara.BrandID = 3;
            //basundhara.BrandName = "Basundhara";
            //list.Add(basundhara);
            //new Context().database.GetCollection<Brand>("Brand").InsertMany(list);

            //List<Product> productList = new List<Product>();
            //Product product1 = new Product();
            //product1.BrandID = 1;
            //product1.ProductName = "12 kg cylinders";
            //product1.Price = 1920;
            //product1.IsDeleted = false;
            //product1.CreatedOn = DateTime.Now;
            //productList.Add(product1);

            //Product product2 = new Product();
            //product2.BrandID = 1;
            //product2.ProductName = "12 kg cylinders";
            //product2.Price = 1920;
            //product2.IsDeleted = false;
            //product2.CreatedOn = DateTime.Now;
            //productList.Add(product2);

            //new Context().database.GetCollection<Product>("Product").InsertMany(productList);
        }
    }
}