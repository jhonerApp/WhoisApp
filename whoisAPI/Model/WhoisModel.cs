using System.Xml.Serialization;

namespace whoisAPI.Model
{
    public class WhoisModel
    {
        [XmlRoot("WhoisRecord")]
        public class WhoisResponse
        {
            [XmlElement("domainName")]
            public string DomainName { get; set; }

            [XmlElement("registrarName")]
            public string RegistrarName { get; set; }

            [XmlElement("createdDate")]
            public string CreatedDate { get; set; }

            [XmlElement("expiresDate")]
            public string ExpiresDate { get; set; }


            [XmlElement("nameServers")]
            public NameServers NameServers { get; set; }

            [XmlElement("registrant")]
            public ContactInfo Registrant { get; set; }

            [XmlElement("technicalContact")]
            public ContactInfo TechnicalContact { get; set; }

            [XmlElement("administrativeContact")]
            public ContactInfo AdministrativeContact { get; set; }
        }

        public class ContactInfo
        {
            [XmlElement("organization")]
            public string Name { get; set; }

            [XmlElement("rawText")]
            public string Email { get; set; }
        }

        public class WhoisInfoResponse
        {
            public string Domain { get; set; }
            public string Registrar { get; set; }
            public string RegistrationDate { get; set; }
            public string ExpirationDate { get; set; }
            public int EstimatedDomainAge { get; set; }
            public string Hostnames { get; set; }
        }

        public class WhoisContactResponse
        {
            public string RegistrantName { get; set; }
            public string TechnicalContactName { get; set; }
            public string AdministrativeContactName { get; set; }
            public string ContactEmail { get; set; }
        }


        public class NameServers
        {
            [XmlElement("rawText")]
            public string RawText { get; set; }

            [XmlElement("hostNames")]
            public HostNames HostNames { get; set; }

            [XmlElement("ips")]
            public object Ips { get; set; } // You can replace with a class if needed
        }

        public class HostNames
        {
            [XmlElement("Address")]
            public List<string> Addresses { get; set; }
        }
    }

}
