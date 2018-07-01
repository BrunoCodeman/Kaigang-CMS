using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Kaigang.Models.Services;
using Kaigang.Models.Entities;
using Kaigang.Models;
using System;

namespace Kaigang.Tests.Integration 
{
    [TestFixture]
    public class DALServiceTest
    {

        const string _content = "<b>some content</b>";
        const string _name = "My Page";
        private Guid id;

        [SetUp]
        public void SetUp()
        {
            using (var ctx = new KaigangDbContext())
            {
                var _page = new Page(){ Content =_content, Name = _name };
                ctx.Add<Page>(_page);
                ctx.SaveChanges();
                id = _page.ID;
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            using(var ctx = new KaigangDbContext())
            {
                    ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE Pages;");
            }
        }

        [Test]
        public void MustInsertEntity()
        {
            var _page = new Page(){ Content = _content, Name = _name };
            var res = DALService<Page>.Add(_page).Result;
            Assert.IsNotNull(res);
            Assert.IsNotEmpty(res.ID.ToString());
        }

        [Test]
        public void MustUpdateEntity()
        {
            const string newContent = "<i>updated content</i>";
            var _pageToUpdate = DALService<Page>.Get(id).Result;
            _pageToUpdate.Content = newContent;
            
            var updateRes = DALService<Page>.Update(_pageToUpdate).Result;
            Assert.IsTrue(updateRes);

            var _pageAfterUpdate = DALService<Page>.Get(id).Result;
            Assert.AreEqual(newContent, _pageAfterUpdate.Content);
            Assert.AreEqual(_pageToUpdate.Name, _pageAfterUpdate.Name);
            Assert.AreEqual(_pageToUpdate.ID, _pageAfterUpdate.ID);
        }

        [Test]
        public void MustDeleteEntity()
        {
            var _page = DALService<Page>.Get(id).Result;
            var deleteRes = DALService<Page>.Delete(_page).Result;
            var _deletedPage = DALService<Page>.Get(id).Result;

            Assert.IsTrue(deleteRes);
            Assert.IsNull(_deletedPage);

        }

        [Test]
        public void MustGetEntity()
        {
            var _savedPage = DALService<Page>.Get(id).Result;
            
            Assert.IsNotNull(_savedPage);
            Assert.AreEqual(_name, _savedPage.Name);
            Assert.AreEqual(_content, _savedPage.Content);
        }

        [Test]
        public void MustGetManyEntities()
        {
            
        }
    }
}