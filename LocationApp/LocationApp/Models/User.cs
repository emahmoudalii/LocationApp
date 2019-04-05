using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace LocationApp.Models
{
    public class User
    { /// <summary>
      /// 
      /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }
    }


    [XmlRoot("response")]
    public class ResponseObject
    {
        [XmlElement("session")]
        public string Session { get; set; }

        [XmlElement("status")]
        public string Status { get; set; }

        [XmlElement("message")]
        public string Message { get; set; }
    }

    public class RootObject
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
