using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.model
{
    class Cdr
    {
        /// <summary>
        /// 数据id
        /// </summary>
        private string dataId;
        /// <summary>
        /// 病历名称
        /// </summary>
        private string recordName;
        /// <summary>
        /// 大字段
        /// </summary>
        private string dataClob;
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createDate;
        /// <summary>
        /// 病历ID
        /// </summary>
        private string recordId;

        public string DataId
        {
            get
            {
                return dataId;
            }

            set
            {
                dataId = value;
            }
        }

        public string RecordName
        {
            get
            {
                return recordName;
            }

            set
            {
                recordName = value;
            }
        }

        public string DataClob
        {
            get
            {
                return dataClob;
            }

            set
            {
                dataClob = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }

            set
            {
                createDate = value;
            }
        }

        public string RecordId
        {
            get
            {
                return recordId;
            }

            set
            {
                recordId = value;
            }
        }
    }
}
