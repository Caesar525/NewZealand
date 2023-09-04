using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEWZEALAND.Dto;
using NEWZEALAND.Excel.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NEWZEALAND.Excel
{
    public class UploadExcelFileAppService : NEWZEALANDAppServiceBase
    {
        private const string FileDir = "/File/ExcelTemp";
        private readonly IImporter _importer=new ExcelImporter();
        public UploadExcelFileAppService()
        {
        }
        //ExcelAppService.cs
        /// <summary>
        /// 接收上传文件方法
        /// </summary>
        /// <param name="file">文件内容</param>
        /// <returns>文件名称</returns>
        public async Task<string> UploadFile(IFormFile file)
        {
            //FileDir是存储临时文件的目录，相对路径
            string url = await WriteFile(file, FileDir);

            string fullpath = Path.GetFullPath($"{Environment.CurrentDirectory}" + url);

            return Path.GetFileName(url);
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="avatar"></param>
        /// <param name="reDir"></param>
        /// <returns></returns>
        public async Task<string> WriteFile(IFormFile avatar, string reDir)
        {
            string reName = Guid.NewGuid() + Path.GetExtension(avatar.FileName);
            string dir = await this.GetDirPath(reDir);
            string path = $"{dir}\\{reName}";
            Stream stream = avatar.OpenReadStream();
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await avatar.CopyToAsync(fileStream);
            }
            return $"{reDir}/{reName}";
        }
        public Task<string> GetDirPath(string reDir)
        {
            string dir = $"{Environment.CurrentDirectory}/{reDir}";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return Task.FromResult(Path.GetFullPath(dir));
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="input">导入excel参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task ImportExcel(ImprotExcelInput input)
        {
            var data = await this.GetData<AliPayImprotExcelDto>(input.Response.Result);
            if (!data.Any())
            {
                return;
            }
            //你的逻辑
        }
        //ExcelAppService.cs
        /// <summary>
        /// 解析excel数据
        /// </summary>
        /// <typeparam name="T">要解析的数据类型</typeparam>
        /// <param name="fileName">excel文件名称，不含路径</param>
        /// <returns></returns>
        internal async Task<IEnumerable<T>> GetData<T>(string fileName) where T : class, new()
        {
            var fullpath = GetFullPath(fileName);
            var result = await _importer.Import<T>(fullpath);
            if (result.HasError)
            {
                var errFile = Path.GetFileNameWithoutExtension(fileName) + "_" + Path.GetExtension(fileName);
                //如果excel文件内容不符合要求（格式错误、必填数据未填、数据类型错误），则弹出错误提示并给出下载链接
                throw new UserFriendlyException("导入错误", GetErrorExcelDownLoadUrl(errFile));
            }
            return result.Data;
            //return null;
        }
        /// <summary>
        /// 下载excel文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<FileContentResult> DownLoadFile(string fileName)
        {
            var fullPath = GetFullPath(fileName);
            byte[] fileBytes = await File.ReadAllBytesAsync(fullPath);
            return new FileContentResult(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = fileName
            };
        }
        /// <summary>
        /// 获取文件全路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetFullPath(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            var fullpath = Path.GetFullPath(Environment.CurrentDirectory.EnsureEndsWith('/') + FileDir.EnsureEndsWith('/') + fileName);
            return fullpath;
        }
        /// <summary>
        /// 获取excel下载链接
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetErrorExcelDownLoadUrl(string fileName)
        {
            return $"请按照excel文件内的错误提示修改后再次导入，<a href='{GetHost()}/api/services/app/Excel/DownLoadFile?fileName={fileName}' target='_blank'>点击下载excel</a>"
                ;
        }
        /// <summary>
        /// 获取当前域名地址
        /// </summary>
        /// <returns></returns>
        private string GetHost()
        {
            //var req = httpContextAccessor.HttpContext.Request;
            //return $"{req.Scheme}://{req.Host}";
            return "";
        }
    }
}
