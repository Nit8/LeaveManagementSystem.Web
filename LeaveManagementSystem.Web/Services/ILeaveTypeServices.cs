﻿using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeaveTypeServices
    {
        Task<bool> CheckIfLeaveTypeExists(string leaveTypeName);
        Task<bool> CheckIfLeaveTypeExistsForEdit(LeaveTypeEditVM leaveTypeEditVM);
        Task Create(LeaveTypeCreateVM model);
        Task Edit(LeaveTypeEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAll();
        Task<bool> LeaveTypeExists(int id);
        Task Remove(int id);
    }
}