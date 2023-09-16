using System;
using System.Collections.Generic;
using System.Data;
using MyBBSWebApi.Model;

namespace MyBBSWebApi.BLL.Interfaces
{
     public interface IPostsBLL
    {
        void DeleteRecord();
        void DeleteRecordByGuid(Guid Id);
        void DeleteRecordById(int Id);
        DataTable GetAll();
        DataTable GetAllOfDistinct(string tbColumn);
        DataTable GetAllOfPage(int? pageIndex, int? pageSize);
        Posts[] GetAllToArray();
        DataTable GetByCustom(string SearchType, string SearchContent);
        DataTable GetByGuid(Guid Id);
        Posts GetByGuidToAttribute(Guid Id);
        DataTable GetById(int Id);
        Posts GetByIdToAttribute(int Id);
        void InsertRecord(Posts md);
        IEnumerable<Posts> ListAll();
        IEnumerable<Posts> ListAllOfPage(int? pageIndex, int? pageSize);
        IEnumerable<Posts> ListByCustom(string SearchType, string SearchContent);
        IEnumerable<Posts> ListByCustomUseWhereIn(string SearchType, string[] SearchContent);
        IEnumerable<Posts> ListByGuid(Guid Id);
        IEnumerable<Posts> ListById(int Id);
        void UpdateRecord(Posts md);
    }
}