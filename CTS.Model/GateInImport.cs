using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTS.Models
{
    public class BulkInImportList
    {
        public List<GateInImport> GateInImport { get; set; }
    }
    public class GateInImport
    {

        public string CONTAINERNO { get; set; }
        public string LINE { get; set; }
        public string SIZE { get; set; }
        public string VESSEL { get; set; }
        public string VOYAGE { get; set; }
        public string INDATE { get; set; }
        public string INTIME { get; set; }
        public string POD { get; set; }
        public string DESTINATION { get; set; }
        public string DOVALIDITY { get; set; }

        public string TRAILERNO { get; set; }

        public string DRIVERNAME { get; set; }
        public string CONTACT { get; set; }

        public string ERODATE { get; set; }
        public string MOVETYPE { get; set; }
        public string TIREWT { get; set; }

    }
}
