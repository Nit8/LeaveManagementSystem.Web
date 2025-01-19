using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using LeaveManagementSystem.Web.Services;
using Microsoft.AspNetCore.Authorization;


namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeServices _leaveTypeServices;
        private static readonly string NameExistsValidationMessage = "This Leave type already Exists";

        public LeaveTypesController(ILeaveTypeServices leaveTypeServices)
        {
            _leaveTypeServices = leaveTypeServices;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData = await _leaveTypeServices.GetAll();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypeServices.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreateVM)
        {
            // adding validation through Model
            if (await _leaveTypeServices.CheckIfLeaveTypeExists(leaveTypeCreateVM.LeaveTypeName))
            {
                ModelState.AddModelError(nameof(leaveTypeCreateVM.LeaveTypeName), NameExistsValidationMessage);
            }
            if (leaveTypeCreateVM.LeaveTypeName.Contains("Chill"))
            {
                ModelState.AddModelError(nameof(leaveTypeCreateVM.LeaveTypeName), "Chilling is not a valid Leave Type");
            }
            if (ModelState.IsValid)
            {
                await _leaveTypeServices.Create(leaveTypeCreateVM);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreateVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeServices.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.LeaveTypeId)
            {
                return NotFound();
            }
            // adding validation through Model
            if (await _leaveTypeServices.CheckIfLeaveTypeExistsForEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.LeaveTypeName), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypeServices.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _leaveTypeServices.LeaveTypeExists(leaveTypeEdit.LeaveTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypeServices.Get<LeaveType>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypeServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
