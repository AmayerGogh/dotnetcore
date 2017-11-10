using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
    public class BaseService<T> where T:BaseEntity
    {
        private ZSZDbContext context;
        public BaseService(ZSZDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 查询数据库中所有的数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return context.Set<T>().Where(c => c.IsDeleted==false);
        }

        /// <summary>
        /// 获得数据库中的总条数
        /// </summary>
        /// <returns></returns>
        public long GetCount()
        {
            //return GetAll().Count();
            return GetAll().LongCount();
        }

        /// <summary>
        /// 根据用户传入的Id查询数据，若为null则表示数据不存在这条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  T GetById(long id)
        {
            return GetAll().Where(e => e.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// 获取分页数据，从第startIndex条开始取count条数据
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<T> GetPagedData(int startIndex, int count)
        {
            return GetAll().OrderBy(e => e.CreateDateTime).Skip(startIndex-1).Take(count);
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        public void MarkDeleted(long id)
        {
            var data = GetById(id);
            if (data == null)
            {
                return;
            }
            data.IsDeleted = true;
            context.SaveChanges();
        }

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="id"></param>
        public void RealDeleted(long id)
        {
            var data = GetById(id);
            if (data == null)
            {
                return;
            }
            context.Set<T>().Remove(data);
            context.SaveChanges();
        }
    }
}
