﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// This method gets all the objects in the database  
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();

        /// <summary>
        /// This method is a database delete operation that takes an integer ID parameter and returns a Task of a boolean value indicating whether the operation was successful.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// This method is a database update operation that takes an integer ID parameter and returns a Task of a boolean value indicating whether the operation was successful.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Update(T entity, int id);

        /// <summary>
        /// This method is a database create operation that takes an entity as a parameter and returns a boolean value indicating whether the operation was successful.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Create(T entity);

        /// <summary>
        /// This is a method that gets one entity from the database only when the id specified in the params appears in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(int id);
    }
}
