﻿using System.Collections.Generic;

namespace VitriniDigital.Domain.Models.Login
{
    public class KeyCloackGetUser
    {
        public string id { get; set; }
        public object createdTimestamp { get; set; }
        public string username { get; set; }
        public bool enabled { get; set; }
        public bool totp { get; set; }
        public bool emailVerified { get; set; }
        public string email { get; set; }
        public List<object> disableableCredentialTypes { get; set; }
        public List<object> requiredActions { get; set; }
        public int notBefore { get; set; }
        public Access access { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    public class Access
    {
        public bool manageGroupMembership { get; set; }
        public bool view { get; set; }
        public bool mapRoles { get; set; }
        public bool impersonate { get; set; }
        public bool manage { get; set; }
    }
}
