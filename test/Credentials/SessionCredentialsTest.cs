﻿/*
 * Copyright 2017 Intacct Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Intacct.Sdk.Tests.Helpers;
using Intacct.Sdk.Credentials;

namespace Intacct.Sdk.Tests.Credentials
{

    [TestClass()]
    public class SessionCredentialsTest
    {

        protected SenderCredentials senderCreds;

        [TestInitialize()]
        public void Initialize()
        {
            ClientConfig config = new ClientConfig
            {
                SenderId = "testsenderid",
                SenderPassword = "pass123!"
            };
            this.senderCreds = new SenderCredentials(config);
        }

        [TestMethod()]
        public void CredsFromArrayTest()
        {
            ClientConfig config = new ClientConfig
            {
                SessionId = "faKEsesSiOnId..",
                EndpointUrl = "https://p1.intacct.com/ia/xml/xmlgw.phtml"
            };

            SessionCredentials sessionCreds = new SessionCredentials(config, this.senderCreds);

            Assert.AreEqual("faKEsesSiOnId..", sessionCreds.SessionId);
            StringAssert.Equals("https://p1.intacct.com/ia/xml/xmlgw.phtml", sessionCreds.Endpoint);
            Assert.IsInstanceOfType(sessionCreds.SenderCredentials, typeof(SenderCredentials));
        }

        [TestMethod()]
        public void CredsFromArrayNoEndpointTest()
        {
            ClientConfig config = new ClientConfig
            {
                SessionId = "faKEsesSiOnId..",
                EndpointUrl = ""
            };

            SessionCredentials sessionCreds = new SessionCredentials(config, this.senderCreds);

            Assert.AreEqual("faKEsesSiOnId..", sessionCreds.SessionId);
            StringAssert.Equals("https://api.intacct.com/ia/xml/xmlgw.phtml", sessionCreds.Endpoint);
        }

        [TestMethod()]
        [ExpectedExceptionWithMessage(typeof(ArgumentException), "Required Session ID not supplied in config")]
        public void CredsFromArrayNoSessionTest()
        {
            ClientConfig config = new ClientConfig
            {
                SessionId = ""
            };
            SessionCredentials sessionCreds = new SessionCredentials(config, this.senderCreds);
        }
    }

}