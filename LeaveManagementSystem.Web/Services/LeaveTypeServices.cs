﻿using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services
{
    public class LeaveTypeServices : ILeaveTypeServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LeaveTypeServices(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            //return View(await _context.LeaveTypes.ToListAsync()); Converting DataModel to ViewModel
            var data = await _context.LeaveTypes.ToListAsync();
            //var viewData = data.Select(p => new IndexVM
            //{
            //    LeaveTypeId = p.LeaveTypeId,
            //    LeaveTypeName = p.LeaveTypeName,
            //    NumberOfDays = p.NumberOfDays
            //});
            //Using Automapper to convert DataModel to ViewModel
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            return viewData;
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.LeaveTypeId == id);
            if (data == null) { return null; }
            var viewData = _mapper.Map<T>(data);
            return viewData;
        }

        public async Task Remove(int id)
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.LeaveTypeId == id);
            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Edit(LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }
        public async Task Create(LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.LeaveTypeId == id);
        }
        public async Task<bool> CheckIfLeaveTypeExists(string leaveTypeName)
        {
            var lowerCaseLeaveTypeName = leaveTypeName.ToLower();
            return await _context.LeaveTypes.AnyAsync(p => p.LeaveTypeName.ToLower().Equals(lowerCaseLeaveTypeName));
        }
        public async Task<bool> CheckIfLeaveTypeExistsForEdit(LeaveTypeEditVM leaveTypeEditVM)
        {
            var lowerCaseLeaveTypeName = leaveTypeEditVM.LeaveTypeName.ToLower();
            return await _context.LeaveTypes.AnyAsync(p => p.LeaveTypeName.ToLower().Equals(lowerCaseLeaveTypeName) && p.LeaveTypeId != leaveTypeEditVM.LeaveTypeId);
        }
    }
}
