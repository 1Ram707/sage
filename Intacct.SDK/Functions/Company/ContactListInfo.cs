﻿/*
 * Copyright 2022 Sage Intacct, Inc.
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

using Intacct.SDK.Xml;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intacct.SDK.Functions.Company
{
    public class ContactListInfo
    {
        public string CategoryName;

        public string Contact;

        public void WriteXmlContactListInfo(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("CONTACT_LIST_INFO");

            xml.WriteElement("CATEGORYNAME", this.CategoryName);

            xml.WriteStartElement("CONTACT");
            xml.WriteElement("NAME", this.Contact);
            xml.WriteEndElement();

            xml.WriteEndElement();
        }
    }
}
