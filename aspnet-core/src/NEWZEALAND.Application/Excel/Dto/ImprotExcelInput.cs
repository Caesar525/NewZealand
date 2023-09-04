using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Dto
{
    //ImprotExcelInput.cs
    /// <summary>
    /// 导入excel
    /// </summary>
    public class ImprotExcelInput
    {
        /// <summary>
        /// 上传的excel文件名称
        /// </summary>
        public string Name { get; set; }

        public ResponsePR Response { get; set; }
    }

    public class ResponsePR
    {
        public string Result { get; set; }
    }

}
