using MongoDB.Entities;
using NUnit.Framework;
using ProductService.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace ProductService.Application.Tests.Unit
{
    public abstract class BaseProductTest
    {
        const string databaseName = "ProductService-Application-Unit-Tests";

        [OneTimeSetUp]
        public void Setup() => new DB(databaseName);

        [TearDown]
        public void TearDown() => DB.Delete<Product>(x => true);

    }
}
