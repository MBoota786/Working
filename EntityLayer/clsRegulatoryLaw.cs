﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsRegulatoryLaw : clsMain
    { 
        public int id { get; set; }
        public int appId { get; set; }
        public int clientSiteId { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public string regulatoryLaw { get; set; }
       
    }
}
