using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace OOP_1_Lab.Model
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(TransportRoute))]
    [KnownType(typeof(Stop))]
    public abstract class Base<T> : Object
        where T : Base<T>
    {
        static public Dictionary<Guid, T> Items = new Dictionary<Guid, T>();
        [DataMember]
        public Guid Id { get; private set; }

        public Base()
        {
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
        }

        static DataContractSerializer dcs = new DataContractSerializer(typeof(Dictionary<Guid, T>));
        static string path = typeof(T).Name + ".xml";

        public static void Save()
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                dcs.WriteObject(fs, Items);
            }
        }

        public static void Load()
        {
            //try
            //{
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Items = (Dictionary<Guid, T>)dcs.ReadObject(fs);
                }
            //}
            //catch (Exception)
            //{
                
            //}
        }
    }
}
