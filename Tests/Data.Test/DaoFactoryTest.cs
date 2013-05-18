using NUnit.Framework;

namespace Data.Test
{

	[TestFixture]
	public class DaoFactoryTest
	{
		//private BaseDao _dao;

		//[SetUp]
		//public void SetUp()
		//{
		//    _dao = new BaseDao();
		//    Assert.IsNotNull(_dao);
		//}

		//[Test]
		//public void SelectAllUserRole()
		//{
		//    var entityBases = _dao.SaveOrUpdate(new UserRole());
		//    Assert.IsNotNull(entityBases);
		//}

		//[Test]
		//public void SelectAllUserRole()
		//{
		//    var userRoles = _dao.SelectAll<UserRole>();
		//    Assert.IsNotNull(userRoles);
		//}

		//[Test]
		//public void SaveOrUpdateUserRole()
		//{
		//    var role = new UserRole { Id = Guid.NewGuid(), Name = "Name", Version = 1 };
		//    var userRoles = _dao.SaveOrUpdate(role);
		//    Assert.IsNotNull(userRoles);
		//}

		[TearDown]
		public void Dispose()
		{
		}
	}
}
