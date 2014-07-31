﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 7/22/2014
 * Time: 3:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx.Server.Tests.Modules
{
    using System;
    using System.Management.Automation;
	using Gallio.Model.Filters;
    using Nancy;
    using Nancy.Testing;
    using MbUnit.Framework;
    using NUnit.Framework;
	using TMX.Interfaces.Server;
	using Tmx.Interfaces;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.TestStructure;
	using Tmx.Interfaces.Types.Remoting;
    using Xunit;
    using PSTestLib;
    
	/// <summary>
	/// Description of TestTasksModuleTestFixture.
	/// </summary>
	[MbUnit.Framework.TestFixture][NUnit.Framework.TestFixture]
	public class TestTasksModuleTestFixture
	{
		public TestTasksModuleTestFixture()
		{
		    TestSettings.PrepareModuleTests();
		}
        
    	[MbUnit.Framework.SetUp][NUnit.Framework.SetUp]
    	public void SetUp()
    	{
    	    TestSettings.PrepareModuleTests();
    	}
    	
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_a_task_to_test_client_if_the_client_matches_the_rule()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testClientHostnameExpected = "testhost";
            var testClientUsernameExpected = "aaa";
            var clientInformation = new TestClientInformation { Hostname = testClientHostnameExpected, Username = testClientUsernameExpected };
            var task = new TestTask {
            	Id = 5,
            	Name = "task name",
            	Completed = false,
            	IsActive = true,
            	Status = TestTaskStatuses.New,
            	Rule = testClientHostnameExpected
            };
			TaskPool.Tasks.Add(task);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, with => with.JsonBody<IClientInformation>(clientInformation));
            var testClient = response.Body.DeserializeJson<TestClientInformation>();
            response = browser.Get(UrnList.TestTasks_Root + "/" + testClient.Id);
            var loadedTask = response.Body.DeserializeJson<TestTask>();
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Xunit.Assert.Equal(task.Id, loadedTask.Id);
            Xunit.Assert.Equal(task.Name, loadedTask.Name);
            Xunit.Assert.Equal(task.Status, loadedTask.Status);
            Xunit.Assert.Equal(task.Completed, loadedTask.Completed);
            Xunit.Assert.Equal(task.IsActive, loadedTask.IsActive);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_no_task_to_test_client_if_the_client_does_not_match_the_rule()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var testClientHostnameExpected = "testhost";
            var testClientUsernameExpected = "aaa";
            var clientInformation = new TestClientInformation { Hostname = testClientHostnameExpected, Username = testClientUsernameExpected };
            var task = new TestTask {
            	Id = 5,
            	Name = "task name",
            	Completed = false,
            	IsActive = true,
            	Status = TestTaskStatuses.New,
            	Rule = "no matches"
            };
			TaskPool.Tasks.Add(task);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, with => with.JsonBody<IClientInformation>(clientInformation));
            var testClient = response.Body.DeserializeJson<TestClientInformation>();
            response = browser.Get(UrnList.TestTasks_Root + "/" + testClient.Id);
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_the_second_task_if_the_client_matches_the_rule()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var clientInformation = new TestClientInformation {
                Hostname = "h",
                OsVersion = "w",
                Username = "u"
            };
            var testTask01 = new TestTask {
                Id = 1,
                IsActive = true,
                Completed = false,
                Name = "task name",
                Rule = ".*h.*"
            };
            TaskPool.Tasks.Add(testTask01);
            var testTask02 = new TestTask {
                Id = 2,
                IsActive = true,
                Completed = false,
                Name = "task name 02",
                Rule = "u"
            };
            TaskPool.Tasks.Add(testTask02);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, with => with.JsonBody<IClientInformation>(clientInformation));
            var registeredClient = response.Body.DeserializeJson<TestClientInformation>();
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id);
            var task = response.Body.DeserializeJson<TestTask>();
            task.Completed = true;
            response = browser.Put(UrnList.TestTasks_Root + "/" + task.Id, with => with.JsonBody<ITestTask>(task));
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id);
            task = response.Body.DeserializeJson<TestTask>();
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Xunit.Assert.Equal(testTask02.Id, task.Id);
            Xunit.Assert.Equal(testTask02.IsActive, task.IsActive);
            Xunit.Assert.Equal(testTask02.Completed, task.Completed);
            Xunit.Assert.Equal(testTask02.Name, task.Name);
            // Xunit.Assert.Equal(testTask.Name, clientsetting
        }
        
        [MbUnit.Framework.Test][NUnit.Framework.Test][Fact]
        public void Should_provide_the_second_task_if_the_client_does_not_match_the_rule()
        {
        	// Given
            var browser = new Browser(new DefaultNancyBootstrapper());
            var clientInformation = new TestClientInformation {
                Hostname = "h",
                OsVersion = "w",
                Username = "u"
            };
            var testTask01 = new TestTask {
                Id = 1,
                IsActive = true,
                Completed = false,
                Name = "task name",
                Rule = ".*h.*"
            };
            TaskPool.Tasks.Add(testTask01);
            var testTask02 = new TestTask {
                Id = 2,
                IsActive = true,
                Completed = false,
                Name = "task name 02",
                Rule = "aaa"
            };
            TaskPool.Tasks.Add(testTask02);
            
            // When
            var response = browser.Post(UrnList.TestClients_Root + UrnList.TestClients_Clients, with => with.JsonBody<IClientInformation>(clientInformation));
            var registeredClient = response.Body.DeserializeJson<TestClientInformation>();
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id);
            var task = response.Body.DeserializeJson<TestTask>();
            task.Completed = true;
            response = browser.Put(UrnList.TestTasks_Root + "/" + task.Id, with => with.JsonBody<ITestTask>(task));
            response = browser.Get(UrnList.TestTasks_Root + "/" + registeredClient.Id);
            
            // Then
            Xunit.Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            // Xunit.Assert.Equal(testTask.Name, clientsetting
        }
	}
}