﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TemperaturRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TemperaturService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TemperaturService.svc or TemperaturService.svc.cs at the Solution Explorer and start debugging.
    public class TemperaturService : ITemperaturService
    {
        public List<Temperatur> GetTemperatur()
        {
            return Temperaturer.Instance.TemperaturTabel;
        }
    }
}
