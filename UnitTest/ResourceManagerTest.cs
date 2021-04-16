using BaiDuResourceUpLoad;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class ResourceManagerTest
    {
        [TestMethod]
        public void GetAccessTokenTest()
        {
            ResourceManager.GetAccessToken();
        }
        [TestMethod]
        public void CreateFolderTest()
        {
            ResourceManager.CreateFolder("/apps/资源存储");
        }
        [TestMethod]
        public void QueryQuotaTest()
        {
            ResourceManager.QueryQuota();
        }
    }
}
