using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEWZEALAND.Interface
{
    public interface INEWZEALANDAppService<TEntityDto, TPrimaryKey, TPagedRequestDto, TNoPagedRequetDto>:IApplicationService 
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TPagedRequestDto : IPagedAndSortedResultRequest
    {
        /// <summary>
        /// 获取全部符合条件的数据并分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<TEntityDto>> GetAll(TPagedRequestDto input);

        /// <summary>
        /// 获取全部符合条件数据，不分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<TEntityDto>> GetAllNoPaged(TNoPagedRequetDto input);

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TEntityDto> GetEntityForEdit(TPrimaryKey id);

        /// <summary>
        /// 创建或者编辑数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TPrimaryKey> CreateOrEdit(TEntityDto input);

        /// <summary>
        /// 根据id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(TPrimaryKey id);
    }
}
