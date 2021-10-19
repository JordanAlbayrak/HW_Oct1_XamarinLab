using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HW_Oct1_XamarinLab
{
    public class DBEmployee
    {
        readonly SQLiteAsyncConnection _database;
        public DBEmployee(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>().Wait();
        }
        public Task<List<Employee>> GetPeopleAsync()
        {
            return
            _database.Table<Employee>().ToListAsync();
        }
        public Task<int> SavePersonAsync(Employee
        employee)
        {
            return _database.InsertAsync(employee);
        }
        public Task<Employee> GetItemAsync(int id)
        {
            return _database.Table<Employee>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> DeleteItemAsync(Employee employee)
        {
            return _database.DeleteAsync(employee);
        }
        public Task<int> UpdatePersonAsync(Employee student)
        {
            if (student.ID != 0)
            {
                return _database.UpdateAsync(student);
            }
            else
            {
                return _database.InsertAsync(student);
            }
        }

    }
}
