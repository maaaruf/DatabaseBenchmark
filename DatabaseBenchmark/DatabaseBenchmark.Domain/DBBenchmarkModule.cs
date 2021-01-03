using Autofac;
using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories;
using DatabaseBenchmark.Domain.Service;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain
{
    public class DBBenchmarkModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DBBenchmarkMongoSession>()
                .WithParameter("database", "dbb")
                .InstancePerLifetimeScope();
            builder.RegisterType<DBBenchmarkMySqlSession>()
                .WithParameter("connectionStringName", "DBBenchmarkMySqlConnection")
                .InstancePerLifetimeScope();
            builder.RegisterType<LoadTestMySqlSession>()
                .InstancePerLifetimeScope();


            //builder.RegisterType<ProductsObjectMongoRepository>().As<IProductsObjectRepository>()
            //    .WithParameter("tableName", "productscopy")
            //    .InstancePerLifetimeScope();

            builder.RegisterType<ProductsObjectRepository>().As<IProductsObjectRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductKeyRepository>().As<IProductKeyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ObjectToJsonConverterService>().As<IObjectToJsonConverterService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RandomDataGeneratorService>().As<IRandomDataGeneratorService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<JsonToObjectConverterService<Product>>().As<IJsonToObjectConverterService<Product>>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
