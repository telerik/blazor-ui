using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcClientUsers;
using GrpcUsers;

namespace GrpcInBlazor.Services
{
    public class GrpcUsersService
    {
        public async Task<List<User>> GetUsersAsync(string deptName)
        {
            List<User> data = await DepartmentUsers.GetUsersAsync(deptName);
            return await Task.FromResult(data);
        }
    }
}
