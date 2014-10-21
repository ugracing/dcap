using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCAP
{
    class BespokeTable
    {

        public DataTable BespokeData = new DataTable();

        public BespokeTable(DataTable MasterTable, List<string> DesiredSensors)
        {
            this.BespokeData.Columns.Add("name", typeof(string));
            this.BespokeData.Columns.Add("value", typeof(double)); 
            this.BespokeData.Columns.Add("timestamp", typeof(double));

            foreach (string desiredSensor in DesiredSensors)
            {
                foreach (DataRow sensorEntry in MasterTable.Rows)
                {
                    if (sensorEntry["name"].Equals(desiredSensor.ToString()))
                    {
                        this.BespokeData.Rows.Add(sensorEntry["name"].ToString(), 
                                                Convert.ToDouble(sensorEntry["value"]), 
                                                Convert.ToDouble(sensorEntry["timestamp"]));
                    }
                }
            }

        }

    }
}
