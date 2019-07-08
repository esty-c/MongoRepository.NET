using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository.Infrastructure.Model
{
    public class ReturnData
    {

        public long ID;
        public Boolean Flag;
        public String MSG;
        public String Extra1;
        public String Extra2 { get; set; }

        public ReturnData(Boolean Flag, String MSG)
        {
            this.Flag = Flag;
            this.MSG = MSG;

        }
        public ReturnData(Boolean Flag, String MSG,string Extra1)
        {
            this.Flag = Flag;
            this.MSG = MSG;
            this.Extra1 = Extra1;

        }
        public ReturnData(long ID, Boolean Flag, String MSG)
        {
            this.ID = ID;
            this.Flag = Flag;
            this.MSG = MSG;

        }

        public ReturnData(long ID, Boolean Flag, String MSG, String Extra1)
        {
            this.ID = ID;
            this.Flag = Flag;
            this.MSG = MSG;
            this.Extra1 = Extra1;

        }
        //public ReturnData(long ID, Boolean Flag, String MSG, String Extra1,long Type)
        //{
        //    this.ID = ID;
        //    this.Flag = Flag;
        //    this.MSG = MSG;
        //  ;
        //}

    }
}
