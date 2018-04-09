using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace OOP_1_Lab.Model
{
    [DataContract]
    class DriverTransportContext : Base<DriverTransportContext>
    {
        [DataMember]
        private Guid _driver;
        [DataMember]
        private Guid _transport;

        public DriverTransportContext()
        {

        }

        public DriverTransportContext(Driver dr, Transport tr)
        {
            _driver = dr.Id;
            _transport = tr.Id;
        }

        public Driver Driver
        {
            get
            {
                return (Driver)Driver.Items.Values.First(dr => dr.Id == _driver);
            }

            set
            {
                _driver = value.Id;
            }
        }

        public Transport Transport
        {
            get
            {
                return Transport.Items.Values.First(tr => tr.Id == _transport);
            }

            set
            {
                _transport = value.Id;
            }
        }
    }
}
